using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Train
    {
        public int train_id { get; private set; }
        private Boolean deleted;

        public Train()
        {
            this.deleted = false;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfExists(this.train_id);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO train(train_id)";
                    this.train_id = Convert.ToInt32(db.ExecuteScalar());
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "DELETE FROM train WHERE train_id = " + this.train_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Train Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM train WHERE train_id = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                int train_id = reader.GetInt32(0);

                Train train = new Train();
                train.train_id = train_id;
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
            string query = "SELECT COUNT(*) FROM train WHERE train_id=" + id;
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