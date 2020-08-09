﻿using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Travel
    {
        private int travel_id { get; }
        private int total_time { get; set; }
        private string state { get; set; }
        private Boolean deleted;

        public Travel(int travel_id, int total_time, string state)
        {
            this.travel_id = travel_id;
            this.total_time = total_time;
            this.state = state;
            this.deleted = false;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfTravelExists(this.travel_id);

                if (!exist)
                {
                    string query = "INSERT INTO travel(travel_id, total_time, state) values (" + this.travel_id + "," + this.total_time + "," + this.state + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE travel SET travel_id = " + this.travel_id + ", total_time = " + this.total_time + ", state = " + this.state + ") WHERE travel_id=" + this.travel_id;
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "DELETE FROM travel WHERE travel_id = " + this.travel_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Travel Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM travel WHERE travel_id = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                int total_time = reader.GetInt32(1);
                string state = reader.GetString(2);

                return new Travel(id, total_time, state);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfTravelExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM travel WHERE travel_id=" + id;
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