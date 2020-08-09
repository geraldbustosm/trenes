using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class BorderStation
    {
        public int border_station_id { get; private set; }
        public int station_one_id { get; set; }
        public int station_two_id { get; set; }
        private Boolean deleted;

        public BorderStation(int station_one_id, int station_two_id)
        {
            this.station_one_id = station_one_id;
            this.station_two_id = station_two_id;
            this.deleted = false;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfBorderStationExists(this.border_station_id);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO border_station( station_one_id, station_two_id) VALUES ( @station_one_id , @station_two_id )";
                    db.Parameters.AddWithValue("@action_id", this.station_one_id);
                    db.Parameters.AddWithValue("@action_id", this.station_two_id);

                    this.border_station_id = Convert.ToInt32(db.ExecuteScalar());
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "DELETE FROM border_station WHERE border_station_id = @border_station_id";
            db.Parameters.AddWithValue("@border_station_id", border_station_id);

            db.ExecuteNonQuery();

            this.deleted = true;

            connection.Close();
            return true;
        }

        // Static methods
        public static BorderStation Find(int border_station_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT * FROM border_station WHERE border_station_id = @border_station_id";
            db.Parameters.AddWithValue("@border_station_id", border_station_id);

            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                int station_one_id = reader.GetInt32(1);
                int station_two_id = reader.GetInt32(2);

                return new BorderStation(station_one_id, station_two_id);
            }
            reader.Close();
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfBorderStationExists(int border_station_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT COUNT(*) FROM border_station WHERE border_station_id= @border_station_id";
            db.Parameters.AddWithValue("@border_station_id", border_station_id);

            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            reader.Close();
            connection.Close();

            if (count > 0) { return true; } else { return false; }
        }
    }
}