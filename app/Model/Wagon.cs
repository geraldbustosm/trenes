using Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Interface;

namespace Model
{
    public class Wagon : MachineInterface
    {
        public int wagon_id { get; private set; }
        public string patent { get; set; }
        public string shipload_type { get; set; }
        public int shipload_weight { get; set; }
        public int wagon_weight { get; set; }
        public int in_transit { get; set; }
        public int train_id { get; set; }
        public int station_id { get; set; }
        public Boolean deleted;

        public Wagon(string shipload_type, int shipload_weight, int wagon_weight, int station_id)
        {
            this.shipload_type = shipload_type;
            this.shipload_weight = shipload_weight;
            this.wagon_weight = wagon_weight;
            this.in_transit = 0;
            this.train_id = 0;
            this.station_id = station_id;
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
                        command.Parameters.AddWithValue("@shipload_type", this.shipload_type);
                        command.Parameters.AddWithValue("@shipload_weight", this.shipload_weight);
                        command.Parameters.AddWithValue("@wagon_weight", this.wagon_weight);
                        command.Parameters.AddWithValue("@in_transit", this.in_transit);
                        command.Parameters.AddWithValue("@station_id", this.station_id);

                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO wagon(shipload_type, shipload_weight, wagon_weight, in_transit, station_id) VALUES (@shipload_type, @shipload_weight, @wagon_weight, @in_transit, @station_id)";
                            this.wagon_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE wagon SET(shipload_type = @shipload_type, shipload_weight =  @shipload_weight, wagon_weight = @wagon_weight, in_transit = @in_transit, train_id = @train_id, station_id = @station_id ) WHERE wagon_id = @wagon_id";
                            command.Parameters.AddWithValue("@train_id", this.train_id);
                            command.Parameters.AddWithValue("@wagon_id", this.wagon_id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public Boolean Delete()
        {
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "DELETE FROM wagon WHERE wagon_id = @wagon_id";
                    command.Parameters.AddWithValue("@wagon_id", this.wagon_id);
                    command.ExecuteNonQuery();
                }
            }
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Wagon Find(int id)
        {
            Wagon wagon = new Wagon(null, 0, 0, 0);
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM wagon WHERE wagon_id = @wagon_id";
                    command.Parameters.AddWithValue("@wagon_id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wagon.shipload_type = reader.GetString(1);
                            wagon.shipload_weight = reader.GetInt32(2);
                            wagon.wagon_weight = reader.GetInt32(3);
                            wagon.in_transit = reader.GetInt32(4);
                            wagon.train_id = reader.GetInt32(5);
                            wagon.station_id = reader.GetInt32(6);
                            wagon.wagon_id = id;
                        }
                    }
                }
            }
            if (wagon.shipload_type != null) { return wagon; } else { return null; }
        }

        public static Wagon FindByPatent(string patent)
        {
            Wagon wagon = new Wagon(null, 0, 0, 0);
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM wagon WHERE patent = @patent";
                    command.Parameters.AddWithValue("@patent", patent);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wagon.wagon_id = reader.GetInt32(0);
                            wagon.patent = reader.GetString(1);
                            wagon.shipload_type = reader.GetString(2);
                            wagon.shipload_weight = reader.GetInt32(3);
                            wagon.wagon_weight = reader.GetInt32(4);
                            wagon.in_transit = reader.GetInt32(5);
                            wagon.train_id = reader.GetInt32(6);
                            wagon.station_id = reader.GetInt32(7);
                        }
                    }
                }
            }
            return wagon;
        }

        public static List<Wagon> GetWagonsByStation(int station_id)
        {
            List<Wagon> wagons = new List<Wagon>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM wagon WHERE station_id = @station_id";
                    command.Parameters.AddWithValue("@station_id", station_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Wagon wagon = new Wagon("", 0, 0, 0);
                            wagon.wagon_id = reader.GetInt32(0);
                            wagon.patent = reader.GetString(1);
                            wagon.shipload_type = reader.GetString(2);
                            wagon.shipload_weight = reader.GetInt32(3);
                            wagon.wagon_weight = reader.GetInt32(4);
                            wagon.in_transit = reader.GetInt32(5);
                            wagon.train_id = reader.GetInt32(6);
                            wagon.station_id = reader.GetInt32(7);
                            wagons.Add(wagon);
                        }
                    }
                }
            }
            return wagons ?? null;
        }

        // Private methods
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM wagon WHERE wagon_id = @wagon_id";
                    command.Parameters.AddWithValue("@wagon_id", this.wagon_id);
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