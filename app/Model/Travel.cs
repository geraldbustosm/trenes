using Database;
using System;
using System.Data;
using System.Data.SQLite;

namespace Model
{
    public class Travel
    {
        public int travel_id { get; private set; }
        public string state { get; set; }
        public Boolean deleted;

        public Travel()
        {
            this.state = "Preparado";
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
                            string state = reader.GetString(1);
   
                            travel = new Travel();
                            travel.state = state;
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
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.Parameters.AddWithValue("@state", this.state);
                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO travel(state) VALUES (@state)";
                            this.travel_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE travel SET(state= @this.state) WHERE travel_id= @travel_id";
                            command.Parameters.AddWithValue("@travel_id", this.travel_id);
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
                    command.CommandText = "SELECT COUNT(*) FROM travel WHERE travel_id =  @travel_id";
                    command.Parameters.AddWithValue("@travel_id", this.travel_id);
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
        public static DataSet GetScheduledTravels()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT DISTINCT t.travel_id, t.state, ts.arrival_time, ts.priority, ts.origin_station_id, ts.destination_station_id FROM travel t, travel_section ts INNER JOIN travel_section ON t.travel_id = ts.travel_id WHERE state like 'Preparado' AND (ts.priority = 1 OR ts.priority = (SELECT MAX(priority) FROM travel_section WHERE travel_id = t.travel_id))";
                db.Parameters.AddWithValue("@state", "Preparado");
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(db);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset;
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