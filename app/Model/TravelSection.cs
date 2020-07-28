using Database;
using System;
using System.Data.SQLite;


namespace Model
{
    class TravelSection
    {
        private int id;
        private string arrival_time;
        private int travel_id;
        private int priority;
        private int action;
        private int origin_station_id;
        private int destination_station_id;
        private Boolean deleted;

        public TravelSection (int id, string arrival_time, int travel_id, int priority, int action, int origin_station_id, int destination_station_id)
        {
            this.id = id;
            this.arrival_time = arrival_time;
            this.travel_id = travel_id;
            this.priority = priority;
            this.action = action;
            this.origin_station_id = origin_station_id;
            this.destination_station_id = destination_station_id;

        }

        // Public Methods
        public int GetId() { return this.id; }
        public string GetArrivalTime() { return this.arrival_time; }
        public int GetTravelId() { return this.travel_id; }
        public int GetPriority() { return this.priority; }
        public int GetAction() { return this.action; }
        public int GetOriginStationId() { return this.origin_station_id; }
        public int GetDestinationStation() { return this.destination_station_id; }

        public void SetArrivalTime(string arrival_time) { this.arrival_time = arrival_time; }
        public void SetPriority(int priority) { this.priority = priority; }
        public void SetAction(int action) { this.action = action; }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfExist(this.id);

                if (!exist)
                {
                    string query = "INSERT INTO travel_section(id, arrival_time, travel_id, priority, action, origin_station_id, destination_station_id) values (" + this.id + "," + this.arrival_time + "," + this.travel_id + "," + this.priority + "," + this.action + "," + this.origin_station_id + "," + this.destination_station_id + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE travel_section SET id = " + this.id + ", arrival_time = " + this.arrival_time + ", travel_id =" + this.travel_id + ",priority =" + this.priority + ", action =" + this.action + ",origin_station_id =" + this.origin_station_id + ",destination_station_id =" + this.destination_station_id + ") WHERE ID=" + this.id;
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "DELETE FROM travel_section WHERE ID = " + this.id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static Methods
        public static TravelSection Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM travel_section WHERE ID = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string arrival_time = reader.GetString(1);
                int travel_id = reader.GetInt32(2);
                int priority = reader.GetInt32(3);
                int action = reader.GetInt32(4);
                int origin_station_id = reader.GetInt32(5);
                int destination_station_id = reader.GetInt32(6);

                return new TravelSection(id, arrival_time, travel_id, priority, action, origin_station_id, destination_station_id);
            }
            connection.Close();
            return null;
        }

        private Boolean CheckIfExist(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM travel_section WHERE ID=" + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            connection.Close();
            if (count > 0) { return true; } else { return false; }
        }
    }
}
