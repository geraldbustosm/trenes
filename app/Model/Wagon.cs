using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Wagon
    {
        public int wagon_id { get; private set; }
        public string shipload_type { get; set; }
        public int shipload_weight { get; set; }
        public int wagon_weight { get; set; }
        public int in_transit { get; set; }
        public int train_id { get; }
        public int station_id { get; }
        public Boolean deleted;

        public Wagon(string shipload_type, int shipload_weight, int wagon_weight, int in_transit, int train_id, int station_id)
        {
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
                Boolean exist = this.CheckIfExists(this.wagon_id);

                db.Parameters.AddWithValue("@shipload_type", this.shipload_type);
                db.Parameters.AddWithValue("@shipload_weight", this.shipload_weight);
                db.Parameters.AddWithValue("@wagon_weight", this.wagon_weight);
                db.Parameters.AddWithValue("@in_transit", this.in_transit);
                db.Parameters.AddWithValue("@train_id", this.train_id);
                db.Parameters.AddWithValue("@station_id", this.station_id);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO wagon(shipload_type, shipload_weight, wagon_weight, in_transit, train_id, station_id) values (@shipload_type, @shipload_weight, @wagon_weight, @in_transit, @train_id, @station_id)";
                    this.wagon_id = Convert.ToInt32(db.ExecuteScalar());
                }
                else
                {
                    db.CommandText = "UPDATE wagon SET(shipload_type = @shipload_type, shipload_weight =  @shipload_weight, wagon_weight = @wagon_weight, in_transit = @in_transit, train_id = @train_id, station_id = @station_id ) WHERE wagon_id = @wagon_id";
                    db.Parameters.AddWithValue("@wagon_id", this.wagon_id);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "DELETE FROM wagon WHERE wagon_id = @wagon_id";
            db.Parameters.AddWithValue("@wagon_id", this.wagon_id);
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
            db.CommandText = "SELECT * FROM wagon WHERE wagon_id = @wagon_id";
            db.Parameters.AddWithValue("@wagon_id", id);
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string shipload_type = reader.GetString(1);
                int shipload_weight = reader.GetInt32(2);
                int wagon_weight = reader.GetInt32(3);
                int in_transit = reader.GetInt32(4);
                int train_id = reader.GetInt32(5);
                int station_id = reader.GetInt32(6);

                Wagon wagon = new Wagon(shipload_type, shipload_weight, wagon_weight, in_transit, train_id, station_id);
                wagon.wagon_id = id;
                return wagon;
            }
            reader.Close();
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT COUNT(*) FROM wagon WHERE wagon_id = @wagon_id";
            db.Parameters.AddWithValue("@wagon_id", id);
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