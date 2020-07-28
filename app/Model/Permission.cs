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
                SQLiteConnection connection = DatabaseUtility.GetConnection();
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
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "DELETE FROM permission WHERE permission_id = " + this.permission_id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Permission Find(int id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM permission WHERE permission_id = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string permission_name = reader.GetString(1);
                int user_id = reader.GetInt32(2);

                return new Permission(id, permission_name, user_id);
            }
            connection.Close();
            return null;
        }
        // Private methods
        private Boolean CheckIfPermissionExists(int permission_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM permission WHERE permission_id=" + permission_id;
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