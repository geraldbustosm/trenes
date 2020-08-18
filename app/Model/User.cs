using Database;
using System;
using System.Data.SQLite;
namespace Model
{
    public class User
    {
        public int user_id { get; private set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        private Boolean deleted;

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.deleted = false;
        }
        public void Save()
        {
            if (!this.deleted)
            {
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
                {
                    connection.Open();
                    SQLiteCommand db = new SQLiteCommand(connection);
                    Boolean exist = this.CheckIfExists();
                    db.Parameters.AddWithValue("@name", this.name);
                    db.Parameters.AddWithValue("@email", this.email);
                    db.Parameters.AddWithValue("@password", this.password);

                    if (!exist)
                    {
                        db.CommandText = "INSERT INTO user(name, email, password) values (@name, @email, @password)";
                        this.user_id = Convert.ToInt32(db.ExecuteScalar());
                    }
                    else
                    {
                        db.CommandText = "UPDATE user SET name = @name, email = @email, password = @password) WHERE user_id = @user_id";
                        db.Parameters.AddWithValue("@user_id", this.user_id);
                        db.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }
        public Boolean Delete()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "DELETE FROM user WHERE user_id = @user_id";
                db.Parameters.AddWithValue("@user_id", this.user_id);
                db.ExecuteNonQuery();
                connection.Close();
                this.deleted = true;
                return true;
            }
        }

        public Boolean ValidatePassword(string password)
        {
            return this.password == password;
        }

        public static User Find(string username)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT * FROM user WHERE name = @username";
                db.Parameters.AddWithValue("@username", username);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string email = reader.GetString(2);
                        string password = reader.GetString(3);

                        User user = new User(name, email, password);
                        user.user_id = id;
                        return user;
                    }
                    reader.Close();
                }
                connection.Close();
                return null;
            }
        }

        public Boolean CheckIfExists()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT COUNT(*) FROM user WHERE user_id = @user_id";
                db.Parameters.AddWithValue("@user_id", this.user_id);
                int count = 0;
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                connection.Close();

                return count > 0;
            }
        }
    }
}