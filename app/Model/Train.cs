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
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
                {
                    connection.Open();
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
        }
        public Boolean Delete()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "DELETE FROM train WHERE train_id = @train_id";
                db.Parameters.AddWithValue("@train_id", this.train_id);
                db.ExecuteNonQuery();
                connection.Close();
                this.deleted = true;
            }
            return true;
        }

        // Static methods
        public static Train Find(int id)
        {
            Train train = null;
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT * FROM train WHERE train_id = @train_id";
                db.Parameters.AddWithValue("@train_id", id);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int train_id = reader.GetInt32(0);

                        train = new Train();
                        train.train_id = train_id;
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return train; ;
        }

        // Private methods
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT COUNT(*) FROM train WHERE train_id = @train_id";
                db.Parameters.AddWithValue("@train_id", this.train_id)

                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return count > 0;
        }
    }
}