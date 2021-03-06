﻿using Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace Model
{
    public class TravelSection
    {
        public int travel_section_id { get; private set; }
        public DateTime arrival_time { get; set; }
        public DateTime init_time { get; set; }
        public int travel_id { get; }
        public int priority { get; set; }
        public int origin_station_id { get; }
        public int destination_station_id { get; }
        private Boolean deleted;

        public TravelSection(DateTime init_time, DateTime arrival_time, int travel_id, int priority, int origin_station_id, int destination_station_id)
        {
            this.arrival_time = arrival_time;
            this.init_time = init_time;
            this.travel_id = travel_id;
            this.priority = priority;
            this.origin_station_id = origin_station_id;
            this.destination_station_id = destination_station_id;
        }

        public TravelSection(int id, DateTime init_time, DateTime arrival_time, int travel_id, int priority, int origin_station_id, int destination_station_id)
        {
            this.travel_section_id = id;
            this.arrival_time = arrival_time;
            this.init_time = init_time;
            this.travel_id = travel_id;
            this.priority = priority;
            this.origin_station_id = origin_station_id;
            this.destination_station_id = destination_station_id;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.Parameters.AddWithValue("@init_time", this.init_time);
                        command.Parameters.AddWithValue("@arrival_time", this.arrival_time);
                        command.Parameters.AddWithValue("@priority", this.priority);
                        command.Parameters.AddWithValue("@travel_id", this.travel_id);
                        command.Parameters.AddWithValue("@origin_station_id", this.origin_station_id);
                        command.Parameters.AddWithValue("@destination_station_id", this.destination_station_id);

                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO travel_section(init_time, arrival_time, priority, travel_id, origin_station_id, destination_station_id) VALUES (@init_time, @arrival_time, @priority, @travel_id, @origin_station_id, @destination_station_id )";
                            this.travel_section_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE travel_section SET (init_time = @init_time, arrival_time= @arrival_time,priority= @priority,travel_id= @travel_id,origin_station_id= @origin_station_id,destination_station_id= @destination_station_id) WHERE travel_section_id = @travel_section_id";
                            command.Parameters.AddWithValue("@travel_section_id", this.travel_section_id);
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
                    command.CommandText = "DELETE FROM travel_section WHERE travel_section_id = @travel_section_id";
                    command.Parameters.AddWithValue("@travel_section_id", this.travel_section_id);
                    command.ExecuteNonQuery();
                }
            }
            this.deleted = true;
            return true;
        }

        // Static Methods
        
        public static TravelSection GetLastTravelSection()
        {
            TravelSection travel_section = null;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM travel_section ORDER by travel_section_id DESC limit 1";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime init_time = reader.GetDateTime(1);
                            DateTime arrival_time = reader.GetDateTime(2);
                            int priority = reader.GetInt32(3);
                            int travel_id = reader.GetInt32(4);
                            int origin_station_id = reader.GetInt32(5);
                            int destination_station_id = reader.GetInt32(6);

                            travel_section = new TravelSection(id, init_time, arrival_time, travel_id, priority, origin_station_id, destination_station_id);
                        }
                    }

                }
            }
            return travel_section;
        }

        public static List<TravelSection> All()
        {
            List<TravelSection> list = new List<TravelSection>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * " +
                        "FROM travel_section, travel " +
                        "WHERE travel_section.travel_id = travel.travel_id AND " +
                        "travel.state = 'En Transito'";

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime init_time = reader.GetDateTime(1);
                            DateTime arrival_time = reader.GetDateTime(2);
                            int priority = reader.GetInt32(3);
                            int travel_id = reader.GetInt32(4);
                            int origin_station_id = reader.GetInt32(5);
                            int destination_station_id = reader.GetInt32(6);

                            TravelSection travelSection = new TravelSection(id, init_time, arrival_time, travel_id, priority, origin_station_id, destination_station_id);
                            list.Add(travelSection);
                        }
                    }

                }
            }
            return list;
        }
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM travel_section WHERE travel_section_id = @travel_section_id";
                    command.Parameters.AddWithValue("@travel_section_id", travel_section_id);
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