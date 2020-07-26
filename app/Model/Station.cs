﻿using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Station
    {
        private int station_id;
        private string name;
        private int capacity;
        private Boolean deleted;

        public Station(int station_id, string name, int capacity)
        {
            this.station_id = station_id;
            this.name = name;
            this.capacity = capacity;
            this.deleted = false;
        }

        // Public methods

        public int GetId() { return station_id; }
        public string GetName() { return name; }
        public int GetCapacity() { return capacity; }
        public void SetName(string name) { this.name = name; }
        public void SetCapacity(int capacity) { this.capacity = capacity; }
        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfStationExists(this.station_id);

                if (!exist)
                {
                    string query = "INSERT INTO station(station_id, name, capacity) values (" + this.station_id + "," + this.name + "," + this.capacity + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE station SET station_id = " + this.station_id + ",name = " + this.name + ",capacity = " + this.capacity + ") WHERE station_id=" + this.station_id;
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
            string query = "DELETE FROM station WHERE station_id = " + this.station_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Station Find(int id)
        {

            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM station WHERE station_id = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                int capacity = reader.GetInt32(2);

                return new Station(id, name, capacity);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfStationExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM station WHERE station_id=" + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            if (count > 0) { return true; } else { return false; }
        }
    }
}
