using Database;
using System;
using System.Data;
using System.Data.SQLite;

namespace Model
{
    public class Permission
    {
        public int permission_id { get; private set; }
        public string permission_name { get; set; }
        private Boolean deleted;

        public Permission(int permission_id, string permission_name)
        {
            this.permission_id = permission_id;
            this.permission_name = permission_name;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfPermissionExists(this.permission_id);

                if (!exist)
                {
                    string query = "INSERT INTO permission(permission_id, permission_name) values (" + this.permission_id + "," + this.permission_name + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE permission SET permission_id = " + this.permission_id + ", permission_name=" + this.permission_name + ") WHERE permission_id=" + this.permission_id;
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

                return new Permission(id, permission_name);
            }
            connection.Close();
            return null;
        }

        public static DataSet All()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT permission_id, permission_name FROM permission";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(db);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                return dataset;
            }
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