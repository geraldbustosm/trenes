using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Wagon
    {
        private int wagon_id;
        private string shipload_type;
        private int shipload_weight;
        private int wagon_weight;
        private int in_transit;
        private int train_id;
        private Boolean deleted;

        public Wagon(int wagon_id, string shipload_type, int shipload_weight, int wagon_weight, int in_transit, int train_id)
        {
            this.wagon_id = wagon_id;
            this.shipload_type = shipload_type;
            this.shipload_weight = shipload_weight;
            this.wagon_weight = wagon_weight;
            this.in_transit = in_transit;
            this.train_id = train_id;
            this.deleted = false;
        }

        // Public methods

        public int GetId() { return wagon_id; }
        public string GetShiploadType() { return shipload_type; }
        public int GetShiploadWeight() { return shipload_weight; }
        public int GetWagonWeight() { return wagon_weight; }
        public int GetInTransit() { return in_transit; }
        public int GetTrainId() { return train_id; }


        public void SetShiploadType(string shipload_type) { this.shipload_type = shipload_type; }
        public void SetShiploadWeight(int shipload_weight) { this.shipload_weight = shipload_weight; }
        public void SetWagonWeight(int wagon_weight) { this.wagon_weight = wagon_weight; }
        public void SetInTransit(int in_transit) { this.in_transit = in_transit; }
        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfUserExists(this.wagon_id);

                if (!exist)
                {
                    string query = "INSERT INTO wagon(wagon_id, shipload_type, shipload_weight, wagon_weight, in_transit, train_id) values (" + this.wagon_id + "," + this.shipload_type + "," + this.shipload_weight + "," + this.wagon_weight + "," + this.in_transit + "," + this.train_id +  ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE wagon SET wagon_id = " + this.wagon_id + ", shipload_type" + this.shipload_type + ", shipload_weight" + this.shipload_weight + ",wagon_weight" + this.wagon_weight + ", in_transit" + this.in_transit + ", train_id" + this.train_id + ") WHERE wagon_id=" + this.wagon_id;
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
            string query = "DELETE FROM wagon WHERE wagon_id = " + this.wagon_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Wagon Find(int id)
        {

            SQLiteConnection connection = DatabaseUtility.connection();
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

                return new Wagon(id, shipload_type, shipload_weight, wagon_weight, in_transit,train_id);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfUserExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM wagon WHERE wagon_id=" + id;
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