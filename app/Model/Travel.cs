using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Travel
    {
        public int travel_id { get; private set; }
        public int total_time { get; set; }
        public string state { get; set; }
        public Boolean deleted;

        public Travel(int total_time, string state)
        {
            this.total_time = total_time;
            this.state = state;
            this.deleted = false;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
                {
                    SQLiteCommand db = new SQLiteCommand(connection);
                    Boolean exist = this.CheckIfExists(this.travel_id);

                    db.Parameters.AddWithValue("@total_time", this.total_time);
                    db.Parameters.AddWithValue("@state", this.state);

                    if (!exist)
                    {
                        db.CommandText = "INSERT INTO travel(total_time, state) values (@total_time,@state)";
                        this.travel_id = Convert.ToInt32(db.ExecuteScalar());
                    }
                    else
                    {
                        db.CommandText = "UPDATE travel SET(total_time = @total_time, state = @this.state) WHERE travel_id = @travel_id";
                        db.Parameters.AddWithValue("@travel_id", this.travel_id);
                        db.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "DELETE FROM travel WHERE travel_id = @travel_id";
            db.Parameters.AddWithValue("@travel_id", this.travel_id);
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Travel Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT * FROM travel WHERE travel_id = @travel_id";
            db.Parameters.AddWithValue("@travel_id", id);
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                int total_time = reader.GetInt32(1);
                string state = reader.GetString(2);

                Travel t = new Travel(total_time, state);
                t.travel_id = id;
                return t;
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
            db.CommandText = "SELECT COUNT(*) FROM travel WHERE travel_id =  @travel_id";
            db.Parameters.AddWithValue("@travel_id", id);
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