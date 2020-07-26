using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Train
    {
        private int train_id;
        private Boolean deleted;

        public Train(int train_id)
        {
            this.train_id = train_id;
            this.deleted = false;
        }

        // Public methods
        public int GetId() { return train_id; }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfTrainExists(this.train_id);

                if (!exist)
                {
                    string query = "INSERT INTO train(train_id) values (" + this.train_id + ")";
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
            string query = "DELETE FROM train WHERE train_id = " + this.train_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Train Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM train WHERE train_id = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                int train_id = reader.GetInt32(0);

                return new Train(train_id);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfTrainExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM train WHERE train_id=" + id;
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