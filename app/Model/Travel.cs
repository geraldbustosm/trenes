﻿using Database;
using System;
using System.Data;
using System.Data.SQLite;

namespace Model
{
    public class Travel
    {
        public int travel_id { get; private set; }
        public string state { get; set; }
        public DateTime init_time { get; set; }
        public DateTime arrival_time { get; set; }
        public Boolean deleted;

        public Travel(DateTime init_time, DateTime arrival_time, string state)
        {
            this.state = state;
            this.init_time = init_time;
            this.arrival_time = arrival_time;
            this.deleted = false;
        }

        public Travel(int id, DateTime init_time, DateTime arrival_time, string state)
        {
            this.state = state;
            this.init_time = init_time;
            this.arrival_time = arrival_time;
            this.travel_id = id;
            this.deleted = false;
        }

        public static Travel GetLastTravel()
        {
            Travel travel = null;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM travel ORDER BY travel_id DESC LIMIT 1";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime init_time = reader.GetDateTime(1);
                            DateTime arrival_time = reader.GetDateTime(2);
                            string state = reader.GetString(3);

                            travel = new Travel(id, init_time, arrival_time, state);
                        }
                    }
                }
            }
            return travel;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.Parameters.AddWithValue("@state", this.state);
                        command.Parameters.AddWithValue("@init_time", this.init_time);
                        command.Parameters.AddWithValue("@arrival_time", this.arrival_time);
                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO travel(init_time, arrival_time, state) VALUES (@init_time, @arrival_time, @state)";
                            this.travel_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE travel SET(init_time = @init_time, arrival_time = @arrival_time, state = @state) WHERE travel_id= @travel_id";
                            command.Parameters.AddWithValue("@travel_id", this.travel_id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM travel WHERE travel_id =  @travel_id";
                    command.Parameters.AddWithValue("@travel_id", this.travel_id);
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
        public static DataSet GetScheduledTravels()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT DISTINCT t.travel_id, t.state, ts.init_time ,ts.arrival_time, ts.priority, s.name, s_d.name FROM travel t INNER JOIN travel_section AS ts ON t.travel_id = ts.travel_id INNER JOIN STATION AS s ON ts.origin_station_id = s.station_id INNER JOIN STATION AS s_d ON ts.destination_station_id = s_d.station_id WHERE state like @state AND (ts.priority = 1 OR ts.priority = (SELECT MAX(priority) FROM travel_section WHERE travel_id = t.travel_id))";
                db.Parameters.AddWithValue("@state", "Programado");
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(db);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset;
            }
        }

        /*
        // Static methods
        public static Travel Find(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT * FROM travel WHERE travel_id = @travel_id";
                db.Parameters.AddWithValue("@travel_id", id);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int total_time = reader.GetInt32(1);
                        string state = reader.GetString(2);

                        Travel t = new Travel(total_time, state);
                        t.travel_id = id;
                        return t;
                    }
                    reader.Close();
                }
                connection.Close();
                return null;
            }
        }
        */
    }
}