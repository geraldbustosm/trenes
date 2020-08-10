using Database;
using System;
using System.Data.SQLite;
using System.Collections.Generic;

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
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.Parameters.AddWithValue("@name", this.name);
                        command.Parameters.AddWithValue("@capacity", this.capacity);

                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO station(name, capacity) values (@name, @capacity)";
                            this.station_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE station SET(name = @name, capacity = @capacity) WHERE station_id= @station_id";
                            command.Parameters.AddWithValue("@station_id", this.station_id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public static Station Find(int id)
        {
            Station station = new Station(null,0);
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM station WHERE station_id = @station_id";
                    command.Parameters.AddWithValue("@station_id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            station.name = reader.GetString(1);
                            station.capacity = reader.GetInt32(2);
                            station.station_id = id;
                        }
                    }
                }
            }
            if (station.name != null) { return station; } else { return null; }
        }
        public Boolean Delete()
        {
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "DELETE FROM station WHERE station_id = @station_id";
                    command.Parameters.AddWithValue("@station_id", station_id);
                    command.ExecuteNonQuery();
                }
            }
            this.deleted = true;
            return true;
        }

        // Static methods
        public static List<Station> FindAll()
        {
            List<Station> list = new List<Station>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM station";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int capacity = reader.GetInt32(2);

                            Station station = new Station(name, capacity);
                            station.station_id = id;
                            list.Add(station);
                        }
                    }
                }
            }
            return list;
        }
        // Private methods
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM station WHERE station_id = @station_id";
                    command.Parameters.AddWithValue("@station_id", this.station_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                }
            }
            return count > 0;
        }
    }
}