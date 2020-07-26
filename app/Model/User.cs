using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class User
    {
        private int id;
        private string name;
        private string lastName;
        private string email;
        private Boolean deleted;

        public User(int id, string name, string lastName, string email)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.deleted = false;
        }

        // Public methods

        public int getId() { return id; }
        public string getName() { return name; }
        public string getLastName() { return lastName; }
        public string getEmail() { return email; }

        public void setName(string name) { this.name = name; }
        public void setLastName(string lastName) { this.lastName = lastName; }
        public void setEmail(string email) { this.email = email; }
        public void save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.checkIfUserExist(this.id);

                if (!exist)
                {
                    string query = "INSERT INTO USER(id, name, lastname, email, password) values (" + this.id + "," + this.name + "," + this.lastName + "," + this.email + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE USER SET id = " + this.id + ", name" + this.name + ", lastname" + this.lastName + ",email" + this.email + ") WHERE ID=" + this.id;
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public Boolean delete()
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "DELETE FROM USER WHERE ID = " + this.id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static User find(int id)
        {

            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM USER WHERE ID = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                string lastName = reader.GetString(2);
                string email = reader.GetString(3);

                return new User(id, name, lastName, email);
            }
            connection.Close();
            return null;
        }

        // Private methods
        private Boolean checkIfUserExist(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM USER WHERE ID=" + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            if(count > 0) {return true; } else { return false; }
        }
    }
}
