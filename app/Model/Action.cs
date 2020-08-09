using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Action
    {
        private string description;
        private int minutes;
        private Boolean deleted;

        public Action(string description, int minutes)
        {
            this.description = description;
            this.minutes = minutes;
            this.deleted = false;
        }

        // Public methods
        public string GetDescription() { return description; }
        public int GetMinutes() { return minutes; }
        public void SetDescription(string description) { this.description = description; }
        public void SetMinutes(int minutes) { this.minutes = minutes; }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfActionExists(this.description);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO action(description, minutes) VALUES (@description, @minutes)";
                    db.Parameters.AddWithValue("@description", this.description);
                    db.Parameters.AddWithValue("@minutes", this.minutes);

                    try
                    {
                        Int32 row = db.ExecuteNonQuery();
                        Console.WriteLine("Row affected: {0}", row);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    db.CommandText = "UPDATE action SET ( minutes = @minutes ) WHERE description= @description";
                    db.Parameters.AddWithValue("@minutes", this.minutes);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "DELETE FROM action WHERE description = @.description";
            db.Parameters.AddWithValue("@description", this.description);
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Action Find(string description)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT * FROM action WHERE description = @description";
            db.Parameters.AddWithValue("@description", description);

            SQLiteDataReader reader = db.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int minutes = reader.GetInt32(2);

                    return new Action(description, minutes);
                }
            }
            else
            {
                Console.WriteLine("No row found.");
            }

            reader.Close();
            connection.Close();

            return null;
        }

        // Private methods
        private Boolean CheckIfActionExists(string description)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            db.CommandText = "SELECT COUNT(*) FROM action WHERE description= @description";
            db.Parameters.AddWithValue("@description", this.description);

            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }
            else
            {
                Console.WriteLine("No row found.");
            }

            reader.Close();
            connection.Close();

            if (count > 0) { return true; } else { return false; }
        }
    }
}