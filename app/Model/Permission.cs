using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class Permission
    {
        public int permission_id { get; private set; }
        public string permission_name { get; set; }
        public int user_id { get; set; }
        private Boolean deleted;

        public Permission(string permission_name, int user_id)
        {
            this.permission_name = permission_name;
            this.user_id = user_id;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfExists(this.permission_id);

                db.Parameters.AddWithValue("@permission_name", this.permission_name);
                db.Parameters.AddWithValue("@user_id", this.user_id);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO permission( permission_name, user_id) VALUES ( @permission_name, @user_id )";
                    this.permission_id = Convert.ToInt32(db.ExecuteScalar());
                }
                else
                {
                    db.CommandText = "UPDATE permission SET ( permission_name = @permission_name, user_id = @user_id ) WHERE permission_id = @permission_id";
                    db.Parameters.AddWithValue("@permission_id", this.permission_id);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "DELETE FROM permission WHERE permission_id = @permission_id";
            db.Parameters.AddWithValue("@permission_id", this.permission_id);

            db.ExecuteNonQuery();
            connection.Close();
            this.deleted = true;
            return true;
        }

        // Static methods
        public static Permission Find(int permission_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT * FROM permission WHERE permission_id = @permission_id";
            db.Parameters.AddWithValue("@permission_id", permission_id);

            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string permission_name = reader.GetString(1);
                int user_id = reader.GetInt32(2);

                Permission permission = new Permission(permission_name, user_id);
                permission.permission_id = permission_id;
                return permission;
            }

            reader.Close();
            connection.Close();
            return null;
        }
        // Private methods
        private Boolean CheckIfExists(int permission_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT COUNT(*) FROM permission WHERE permission_id = @permission_id";
            db.Parameters.AddWithValue("@permission_id", permission_id);

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