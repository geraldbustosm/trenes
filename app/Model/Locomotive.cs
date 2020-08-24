using Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Model
{
    public class Locomotive
    {
        public int locomotive_id { get; private set; }
        public string patent { get; set; }
        public string model { get; set; }
        public int tons_drag { get; set; }
        public int in_transit { get; set; }
        public int train_id { get; set; }
        public int station_id { get; set; }
        public Boolean deleted;


        public Locomotive(string model, int tons_drag, int station_id)
        {
            this.model = model;
            this.tons_drag = tons_drag;
            this.in_transit = 0;
            this.train_id = 0;
            this.station_id = station_id;
        }
        public void Save()
        {
            if (!this.deleted)
            {
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.Parameters.AddWithValue("@model", this.model);
                        command.Parameters.AddWithValue("@tons_drag", this.tons_drag);
                        command.Parameters.AddWithValue("@in_transit", this.in_transit);
                        command.Parameters.AddWithValue("@station_id", this.station_id);

                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO locomotive (model,tons_drag,in_transit,station_id) VALUES (@model, @tons_drag, @in_transit, @station_id)";
                            this.locomotive_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE locomotive SET ( model =  @model, tons_drag = @tons_drag, in_transit = @in_transit, train_id = @train_id, station_id = @station_id) WHERE locomotive_id = @locomotive_id";
                            command.Parameters.AddWithValue("@train_id", this.train_id);
                            command.Parameters.AddWithValue("@locomotive_id", this.locomotive_id);
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
                    command.CommandText = "DELETE FROM locomotive WHERE locomotive_id = @locomotive_id";
                    command.Parameters.AddWithValue("@locomotive_id", this.locomotive_id);
                    command.ExecuteNonQuery();
                }
            }
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Locomotive Find(int id)
        {
            Locomotive locomotive = new Locomotive(null, 0, 0);
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM locomotive WHERE locomotive_id = @locomotive_id";
                    command.Parameters.AddWithValue("@locomotive_id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            locomotive.model = reader.GetString(1);
                            locomotive.patent = reader.GetString(2);
                            locomotive.tons_drag = reader.GetInt32(3);
                            locomotive.in_transit = reader.GetInt32(4);
                            locomotive.train_id = reader.GetInt32(5);
                            locomotive.station_id = reader.GetInt32(6);
                            locomotive.locomotive_id = id;
                        }
                    }
                }
            }
            if (locomotive.model != null) { return locomotive; } else { return null; }
        }

        public static List<Locomotive> GetLocomotivesByStation(int station_id)
        {
            List<Locomotive> locomotives = new List<Locomotive>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM locomotive WHERE station_id = @station_id";
                    command.Parameters.AddWithValue("@station_id", station_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Locomotive locomotive = new Locomotive("", 0, 0);
                            locomotive.locomotive_id = reader.GetInt32(0);
                            locomotive.patent = reader.GetString(1);
                            locomotive.tons_drag = reader.GetInt32(2);
                            locomotive.in_transit = reader.GetInt32(3);
                            locomotive.train_id = reader.GetInt32(4);
                            locomotive.station_id = reader.GetInt32(5);
                            locomotives.Add(locomotive);
                        }
                    }
                }
            }
            return locomotives ?? null;
        }
        // Private methods
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM locomotive WHERE locomotive_id = @locomotive_id";
                    command.Parameters.AddWithValue("@locomotive_id", this.locomotive_id);
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