using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Permission
    {
        private int permission_id;
        private string permission_name;
        private int user_id;
        private Boolean deleted;

        public Permission(int permission_id, string permission_name, int user_id)
        {
            this.permission_id = permission_id;
            this.permission_name = permission_name;
            this.user_id = user_id;
        }

        // Public methods

        public int GetId() { return permission_id; }
        public string GetPermissionName() { return permission_name; }
        public int GetUserId() { return user_id; }
        public void SetPermissionName(string permission_name) { this.permission_name = permission_name; }
        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfPermissionExists(this.permission_id);

                if (!exist)
                {
                    string query = "INSERT INTO permission(permission_id, permission_name, user_id) values (" + this.permission_id + "," + this.permission_name + "," + this.user_id + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE permission SET permission_id = " + this.permission_id + ", permission_name=" + this.permission_name + ", user_id=" + this.user_id + ") WHERE permission_id=" + this.permission_id;
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
            string query = "DELETE FROM USER WHERE ID = " + this.user_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static User Find(int id)
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
        private Boolean CheckIfPermissionExists(int permission_id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM permission WHERE permission_id=" + permission_id;
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
