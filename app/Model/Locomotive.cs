using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Locomotive
    {
        private int locomotive_id { get; }
        private string model { get; set; }
        private int drag_capacity { get; set; }
        private int in_transit { get; set; }
        private int train_id { get; }
        private int station_id { get; }
        private Boolean deleted;

        public Locomotive(int locomotive_id, string model, int drag_capacity, int in_transit, int train_id, int station_id)
        {
            this.locomotive_id = locomotive_id;
            this.model = model;
            this.drag_capacity = drag_capacity;
            this.in_transit = in_transit;
            this.train_id = train_id;
            this.station_id = station_id;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfLocomotiveExists(this.locomotive_id);

                if (!exist)
                {
                    string query = "INSERT INTO locomotive(locomotive_id, model, drag_capicity, in_transit, train_id, station_id) values (" + this.locomotive_id + "," + this.model + "," + this.drag_capacity + this.train_id + this.station_id + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE locomotive SET locomotive_id = " + this.locomotive_id + ", model=" + this.model + ", drag_capacity=" + this.drag_capacity + ",in_transit=" + this.in_transit + ",train_id=" + this.train_id + ",station_id=" + this.station_id + ") WHERE locomotive_id =" + this.locomotive_id;
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
            string query = "DELETE FROM locomotive WHERE locomotive_id = " + this.locomotive_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Locomotive Find(int locomotive_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM locomotive WHERE locomotive_id = " + locomotive_id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string model = reader.GetString(1);
                int drag_capacity = reader.GetInt32(2);
                int in_transit = reader.GetInt32(3);
                int train_id = reader.GetInt32(4);
                int station_id = reader.GetInt32(5);

                return new Locomotive(locomotive_id, model, drag_capacity, in_transit, train_id, station_id);
            }
            connection.Close();
            return null;
        }
        // Private methods
        private Boolean CheckIfLocomotiveExists(int locomotive_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM locomotive WHERE locomotive_id=" + locomotive_id;
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