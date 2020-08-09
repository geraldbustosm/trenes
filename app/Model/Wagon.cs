using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Wagon
    {
        private int wagon_id { get; set; }
        private string shipload_type { get; set; }
        private int shipload_weight { get; set; }
        private int wagon_weight { get; set; }
        private int in_transit { get; set; }
        private int train_id { get; }
        private int station_id { get; }
        private Boolean deleted;

        public Wagon(int wagon_id, string shipload_type, int shipload_weight, int wagon_weight, int in_transit, int train_id, int station_id)
        {
            this.wagon_id = wagon_id;
            this.shipload_type = shipload_type;
            this.shipload_weight = shipload_weight;
            this.wagon_weight = wagon_weight;
            this.in_transit = in_transit;
            this.train_id = train_id;
            this.station_id = station_id;
            this.deleted = false;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfUserExists(this.wagon_id);

                if (!exist)
                {
                    string query = "INSERT INTO wagon(wagon_id, shipload_type, shipload_weight, wagon_weight, in_transit, train_id, station_id) values (" + this.wagon_id + "," + this.shipload_type + "," + this.shipload_weight + "," + this.wagon_weight + "," + this.in_transit + "," + this.train_id + "," + this.station_id + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE wagon SET wagon_id = " + this.wagon_id + ", shipload_type = " + this.shipload_type + ", shipload_weight = " + this.shipload_weight + ",wagon_weight = " + this.wagon_weight + ", in_transit = " + this.in_transit + ", train_id = " + this.train_id + ", station_id = " + this.station_id + ") WHERE wagon_id=" + this.wagon_id;
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
            string query = "DELETE FROM wagon WHERE wagon_id = " + this.wagon_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Wagon Find(int id)
        {

            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM wagon WHERE wagon_id = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string shipload_type = reader.GetString(1);
                int shipload_weight = reader.GetInt32(2);
                int wagon_weight = reader.GetInt32(3);
                int in_transit = reader.GetInt32(4);
                int train_id = reader.GetInt32(5);
                int station_id = reader.GetInt32(6);

                return new Wagon(id, shipload_type, shipload_weight, wagon_weight, in_transit,train_id,station_id);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfUserExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM wagon WHERE wagon_id = " + id;
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