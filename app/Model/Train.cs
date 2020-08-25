
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
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {

                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO train()";
                            this.train_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE train SET() WHERE train_id= @train_id";
                            command.Parameters.AddWithValue("@train_id", this.train_id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        /*
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
        */
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM train WHERE train_id = @train_id";
                    command.Parameters.AddWithValue("@train_id", this.train_id);
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