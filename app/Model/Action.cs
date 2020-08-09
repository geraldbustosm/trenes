using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Action
    {
        public int action_id { get; private set; }
        public string description { get; set; }
        public int minutes { get; set; }
        private Boolean deleted;

        public Action( string description, int minutes)
        {
            this.description = description;
            this.minutes = minutes;
            this.deleted = false;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfExists(this.action_id);

                db.Parameters.AddWithValue("@description", this.description);
                db.Parameters.AddWithValue("@minutes", this.minutes);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO action( description, minutes) values ( @description, @minutes )";
                    this.action_id = Convert.ToInt32(db.ExecuteScalar());
                }
                else
                {
                    db.CommandText = "UPDATE action SET ( description = @description, minutes = @minutes ) WHERE action_id = @action_id";
                    db.Parameters.AddWithValue("@action_id", this.action_id);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "DELETE FROM action WHERE action_id = @action_id";
            db.Parameters.AddWithValue("@action_id", this.action_id);

            db.ExecuteNonQuery();

            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Action Find(int action_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT * FROM action WHERE action_id = @action_id";
            db.Parameters.AddWithValue("@action_id", action_id);

            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string description = reader.GetString(1);
                int minutes = reader.GetInt32(2);

                Action action = new Action(description, minutes);
                action.action_id = action_id;
                return action;
            }

            reader.Close();
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfExists(int action_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT COUNT(*) FROM action WHERE action_id = @action_id";
            db.Parameters.AddWithValue("@action_id", action_id);

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