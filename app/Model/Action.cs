using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Action
    {
        private int action_id;
        private string description;
        private int minutes;
        private Boolean deleted;

        public Action(int action_id, string description, int minutes)
        {
            this.action_id = action_id;
            this.description = description;
            this.minutes = minutes;
            this.deleted = false;
        }

        // Public methods
        public int GetId() { return action_id; }
        public string GetDescription() { return description; }
        public int GetMinutes() { return minutes; }
        public void SetDescription(string description) { this.description = description; }
        public void SetMinutes(int minutes) { this.minutes = minutes; }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfActionExists(this.action_id);

                if (!exist)
                {
                    string query = "INSERT INTO action(action_id, description, minutes) values (" + this.action_id + "," + this.description + "," + this.minutes + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE action SET action_id = " + this.action_id + ", description = " + this.description + ",minutes = " + this.minutes + ") WHERE action_id=" + this.action_id;
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
            string query = "DELETE FROM action WHERE action_id = " + this.action_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Action Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM action WHERE action_id = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string description = reader.GetString(1);
                int minutes = reader.GetInt32(2);

                return new Action(id, description, minutes);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean CheckIfActionExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM action WHERE action_id=" + id;
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