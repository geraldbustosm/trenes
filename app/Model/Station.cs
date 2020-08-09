using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Station
    {
        public int station_id { get; private set; }
        public string name { get; set; }
        public int capacity { get; set; }
        private Boolean deleted;

        public Station(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            this.deleted = false;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfExists(this.station_id);

                db.Parameters.AddWithValue("@name", this.name);
                db.Parameters.AddWithValue("@capacity", this.capacity);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO station(name, capacity) values (@name, @capacity)";
                    this.station_id = Convert.ToInt32(db.ExecuteScalar());
                }
                else
                {
                    db.CommandText = "UPDATE station SET(name = @name, capacity = @capacity) WHERE station_id= @station_id";
                    db.Parameters.AddWithValue("@station_id", this.station_id);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "DELETE FROM station WHERE station_id = @station_id";
            db.Parameters.AddWithValue("@station_id", station_id);
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Station Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT * FROM station WHERE station_id = @station_id";
            db.Parameters.AddWithValue("@station_id", id);
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                int capacity = reader.GetInt32(2);

                Station station = new Station(name, capacity);
                station.station_id = id;
                return station;
            }
            reader.Close();
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT COUNT(*) FROM station WHERE station_id = @station_id";
            db.Parameters.AddWithValue("@station_id", id);
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