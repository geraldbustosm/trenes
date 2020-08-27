
using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Train
    {
        public int train_id { get; private set; }
        public int travel_id { get; set; }
        public int drag_locomotive { get; set; }

        private Boolean deleted;

        public Train(int travel_id, int drag_locomotive)
        {
            this.drag_locomotive = drag_locomotive;
            this.travel_id = travel_id;
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
                        command.Parameters.AddWithValue("@travel_id", this.travel_id);
                        command.Parameters.AddWithValue("@drag_locomotive", this.drag_locomotive);

                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO train(travel_id, drag_locomotive) VALUES (@travel_id, @drag_locomotive)";
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            command.CommandText = "UPDATE train SET(travel_id = @travel_id, drag_locomotive = @drag_locomotive) WHERE train_id= @train_id";
                            command.Parameters.AddWithValue("@train_id", this.train_id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
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