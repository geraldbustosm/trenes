using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Locomotive
    {
        public int locomotive_id { get; private set; }
        public string model { get; set; }
        public int drag_capacity { get; set; }
        public int in_transit { get; set; }
        public int train_id { get; set;  }
        public int station_id { get; set;  }
        public Boolean deleted;

        public Locomotive(string model, int drag_capacity, int in_transit, int train_id, int station_id)
        {
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
                Boolean exist = this.CheckIfExists(this.locomotive_id);

                db.Parameters.AddWithValue("@model", this.model);
                db.Parameters.AddWithValue("@drag_capacity", this.drag_capacity);
                db.Parameters.AddWithValue("@in_transit", this.in_transit);
                db.Parameters.AddWithValue("@train_id", this.train_id);
                db.Parameters.AddWithValue("@station_id", this.station_id);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO locomotive(model, drag_capicity, in_transit, train_id, station_id) values (@model, @drag_capacity, @train_id, @station_id )";
                    this.locomotive_id = Convert.ToInt32(db.ExecuteScalar());
                }
                else
                {
                    db.CommandText = "UPDATE locomotive SET ( model =  @model, drag_capacity = @drag_capacity, in_transit = @in_transit, train_id = @train_id, station_id = @station_id) WHERE locomotive_id = @locomotive_id";
                    db.Parameters.AddWithValue("@locomotive_id", this.locomotive_id);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "DELETE FROM locomotive WHERE locomotive_id = @locomotive_id";
            db.Parameters.AddWithValue("@locomotive_id", this.locomotive_id);
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Locomotive Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT * FROM locomotive WHERE locomotive_id = @locomotive_id";
            db.Parameters.AddWithValue("@locomotive_id",id);
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string model = reader.GetString(1);
                int drag_capacity = reader.GetInt32(2);
                int in_transit = reader.GetInt32(3);
                int train_id = reader.GetInt32(4);
                int station_id = reader.GetInt32(5);

                Locomotive l = new Locomotive(model, drag_capacity, in_transit, train_id, station_id);
                l.locomotive_id = id;
                return l;
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
            db.CommandText = "SELECT COUNT(*) FROM locomotive WHERE locomotive_id = @locomotive_id";
            db.Parameters.AddWithValue("@locomotive_id", id);
            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();
            return count > 0;
        }
    }
}