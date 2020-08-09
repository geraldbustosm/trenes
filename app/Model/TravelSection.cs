using Database;
using System;
using System.Data.SQLite;


namespace Model
{
    class TravelSection
    {
        public int travel_section_id { get; private set; }
        public string arrival_time { get; set; }
        public int travel_id { get; }
        public int priority { get; set; }
        public int origin_station_id { get; }
        public int destination_station_id { get; }
        private Boolean deleted;

        public TravelSection (string arrival_time, int travel_id, int priority, int action, int origin_station_id, int destination_station_id)
        {
            this.arrival_time = arrival_time;
            this.travel_id = travel_id;
            this.priority = priority;
            this.origin_station_id = origin_station_id;
            this.destination_station_id = destination_station_id;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfExist(this.travel_section_id);

                db.Parameters.AddWithValue("@arrival_time", this.arrival_time);
                db.Parameters.AddWithValue("@travel_id", this.travel_id);
                db.Parameters.AddWithValue("@priority", this.priority);
                db.Parameters.AddWithValue("@origin_station_id", this.origin_station_id);
                db.Parameters.AddWithValue("@destination_station_id", this.destination_station_id);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO travel_section( arrival_time, travel_id, priority, action, origin_station_id, destination_station_id) values (@arrival_time, @travel_id, @priority, @origin_station_id, @destination_station_id )";
                    
                    this.travel_section_id = Convert.ToInt32(db.ExecuteScalar());
                }
                else
                {
                    db.CommandText = "UPDATE travel_section SET ( arrival_time = @arrival_time, travel_id = @travel_id, priority = @priority, origin_station_id = @origin_station_id, destination_station_id = @destination_station_id ) WHERE travel_section_id = @travel_section_id";
                    db.Parameters.AddWithValue("@travel_section_id", this.travel_section_id);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "DELETE FROM travel_section WHERE travel_section_id = @travel_section_id";
            db.Parameters.AddWithValue("@travel_section_id", this.travel_section_id);
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static Methods
        public static TravelSection Find(int travel_section_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT * FROM travel_section WHERE travel_section_id = @travel_section_id";
            db.Parameters.AddWithValue("@travel_section_id", travel_section_id);

            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string arrival_time = reader.GetString(1);
                int travel_id = reader.GetInt32(2);
                int priority = reader.GetInt32(3);
                int action = reader.GetInt32(4);
                int origin_station_id = reader.GetInt32(5);
                int destination_station_id = reader.GetInt32(6);

                TravelSection travelSection = new TravelSection(arrival_time, travel_id, priority, action, origin_station_id, destination_station_id);
                travelSection.travel_section_id = travel_section_id;
                return travelSection;
            }

            reader.Close();
            connection.Close();
            return null;
        }

        private Boolean CheckIfExist(int travel_section_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT COUNT(*) FROM travel_section WHERE travel_section_id = @travel_section_id";
            db.Parameters.AddWithValue("@travel_section_id", travel_section_id);

            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            reader.Close();
            connection.Close();
            return count > 0;
        }
    }
}
