using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Travel
    {
        public int travel_id { get; private set; }
        public Boolean deleted;

        public Travel()
        {
            this.deleted = false;
        }

        public static Travel GetLastTravel()
        {
            Travel travel = null;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM travel ORDER BY travel_id DESC LIMIT 1";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
   
                            travel = new Travel();
                            travel.travel_id = id;
                        }
                    }
                }
            }
            return travel;
        }
        
        public void Save()
        {
            if (!this.deleted)
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
                {
                    connection.Open();
                    SQLiteCommand db = new SQLiteCommand(connection);
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

        /*
        public Boolean Delete()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "DELETE FROM travel WHERE travel_id = @travel_id";
                db.Parameters.AddWithValue("@travel_id", this.travel_id);
                db.ExecuteNonQuery();
                connection.Close();
                this.deleted = true;
                return true;
            }
        }

        // Static methods
        public static Travel Find(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT * FROM travel WHERE travel_id = @travel_id";
                db.Parameters.AddWithValue("@travel_id", id);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int total_time = reader.GetInt32(1);
                        string state = reader.GetString(2);

                        Travel t = new Travel(total_time, state);
                        t.travel_id = id;
                        return t;
                    }
                    reader.Close();
                }
                connection.Close();
                return null;
            }
        }

        // Private methods
        private Boolean CheckIfExists(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT COUNT(*) FROM travel WHERE travel_id =  @travel_id";
                db.Parameters.AddWithValue("@travel_id", id);
                int count = 0;
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                connection.Close()
                return count > 0;
            }
        }
        */
    }
}