using Database;
using System;
using System.Data;
using System.Data.SQLite;
namespace Model
{
    public class User
    {
        public int user_id { get; private set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int permission_id { get; set; }
        private Boolean deleted;

        public User(string name, string email, string password, int permission_id)
        {
            this.user_id = 0;
            this.name = name;
            this.email = email;
            this.password = password;
            this.permission_id = permission_id;
            this.deleted = false;
        }
        public bool Save()
        {
            bool saved = false;
            if (!this.deleted)
            {
                Boolean exist = this.CheckIfExists();
                using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
                {
                    connection.Open();
                    SQLiteCommand db = new SQLiteCommand(connection);
                    db.Parameters.AddWithValue("@name", this.name);
                    db.Parameters.AddWithValue("@email", this.email);
                    db.Parameters.AddWithValue("@password", this.password);
                    db.Parameters.AddWithValue("@permission_id", this.permission_id);

                    if (!exist)
                    {
                        db.CommandText = "INSERT INTO user(name, email, password, permission_id) values (@name, @email, @password, @permission_id)";
                        this.user_id = Convert.ToInt32(db.ExecuteScalar());
                        saved = true;
                    }
                    else if(this.user_id > 0)
                    {
                        db.CommandText = "UPDATE user SET name = @name, email = @email, password = @password, permission_id = @permission_id WHERE user_id = @user_id";
                        db.Parameters.AddWithValue("@user_id", this.user_id);
                        db.ExecuteNonQuery();
                        saved = true;
                    }
                    connection.Close();
                }
            }
            return saved;
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
            }
            return true;
        }

        public static User Find(string email)
        {
            User user = null;
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT * FROM user WHERE email = @email";
                db.Parameters.AddWithValue("@email", email);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string password = reader.GetString(3);
                        int permission_id = reader.GetInt32(4);

                        user = new User(name, email, password, permission_id);
                        user.user_id = id;
                        
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return user;
        }

        public static User Find(int user_id)
        {
            User user = null;
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT * FROM user WHERE user_id = @user_id";
                db.Parameters.AddWithValue("@user_id", user_id);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(1);
                        string email = reader.GetString(2);
                        string password = reader.GetString(3);
                        int permission_id = reader.GetInt32(4);

                        user = new User(name, email, password, permission_id);
                        user.user_id = user_id;

                    }
                    reader.Close();
                }
                connection.Close();
            }
            return user;
        }

        public static DataSet All()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT u.user_id as 'Codigo', u.name as 'Nombre', u.email as 'Correo electrónico', p.permission_name as 'Rol' FROM user u INNER JOIN permission p on u.permission_id = p.permission_id";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(db);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset;
            }
        }

        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT COUNT(*) FROM user WHERE email = @email";
                db.Parameters.AddWithValue("@email", this.email);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return count > 0;
        }
    }
}