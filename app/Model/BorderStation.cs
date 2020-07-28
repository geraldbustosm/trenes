using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class BorderStation
    {
        private int border_station_id;
        private int station_one_id;
        private int station_two_id;
        private Boolean deleted;

        public BorderStation(int border_station_id, int station_one_id, int station_two_id)
        {
            this.border_station_id = border_station_id;
            this.station_one_id = station_one_id;
            this.station_two_id = station_two_id;
            this.deleted = false;
        }

        // Public methods
        public int GetId() { return border_station_id; }
        public int GetStationOneId() { return station_one_id; }
        public int GetStationTwoId() { return station_two_id; }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfBorderStationExists(this.border_station_id);

                if (!exist)
                {
                    string query = "INSERT INTO border_station(border_station_id, station_one_id, station_two_id) values (" + this.border_station_id + "," + this.station_one_id + "," + this.station_two_id + ")";
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
            string query = "DELETE FROM border_station WHERE border_station_id = " + this.border_station_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            connection.Close();
            return true;
        }

        // Static methods
        public static BorderStation Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM border_station WHERE border_station = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                int station_one_id = reader.GetInt32(1);
                int station_two_id = reader.GetInt32(2);

                return new BorderStation(id, station_one_id, station_two_id);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfBorderStationExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM border_station WHERE border_station_id=" + id;
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