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
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.Parameters.AddWithValue("@station_one_id", this.station_one_id);
                        command.Parameters.AddWithValue("@station_two_id", this.station_two_id);
                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO border_station( station_one_id, station_two_id) VALUES ( @station_one_id , @station_two_id )";
                            this.border_station_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
            }
        }
        // Private methods
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM border_station WHERE border_station_id = @border_station_id";
                    command.Parameters.AddWithValue("@border_station_id", this.border_station_id);
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