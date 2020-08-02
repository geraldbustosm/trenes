using Database;
using System;
using System.Data.SQLite;
namespace Model
{
    public class User
    {
        private int user_id;
        private string name;
        private string email;
        private string password;
        private Boolean deleted;

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.deleted = false;
        }

        // Public methods
        public int GetId() { return user_id; }
        public string GetName() { return name; }
        public string GetEmail() { return email; }
        public string GetPassword() { return password; }
        public void SetId(int id) { this.user_id = id; }
        public void SetName(string name) { this.name = name; }
        public void SetEmail(string email) { this.email = email; }
        public void SetPassword(string password) { this.password = password; }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfUserExists(this.user_id);

                if (!exist)
                {
                    string query = "INSERT INTO user(user_id, name, email, password) values (" + this.user_id + "," + this.name + "," + this.email + "," + this.password + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE user SET user_id = " + this.user_id + ", name = " + this.name + ",email = " + this.email + ",password = " + this.password + ") WHERE user_id=" + this.user_id;
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "DELETE FROM user WHERE user_id = " + this.user_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        public Boolean ValidatePassword(string password)
        {
            return this.password == password ? true : false;
        }

        // Static methods
        public static User Find(string _name)
        {
            Console.WriteLine(_name);
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM user WHERE name = '" + _name + "'";
            Console.WriteLine(query);
            db.CommandText = query;
            try
            {
                SQLiteDataReader reader = db.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    string email = reader.GetString(2);
                    string password = reader.GetString(3);
                    return new User(name, email, password);
                }
                connection.Close();
            }
            catch
            {
                Console.WriteLine("no existe el usuario");
            }
            return null;
        }

        // Private methods
        private Boolean CheckIfUserExists(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM user WHERE user_id=" + id;
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