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

        public Permission(string permission_name)
        {
            this.permission_name = permission_name;
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
                    db.Parameters.AddWithValue("@permission_name", this.permission_name);

                    if (!exist)
                    {
                        db.CommandText = "INSERT INTO permission(permission_id, permission_name) values (@permission_name)";
                        this.permission_id = Convert.ToInt32(db.ExecuteScalar());
                        saved = true;
                    }
                    else if (this.permission_id > 0)
                    {
                        db.CommandText = "UPDATE permission SET permission_name = @permission_name) WHERE permission_id = @permission_id";
                        db.Parameters.AddWithValue("@permission_id", this.permission_id);
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
                db.CommandText = "DELETE FROM permission WHERE permission_id = @permission_id";
                db.ExecuteNonQuery();
                connection.Close();
                this.deleted = true;
            }
            return true;
        }

        // Static methods
        public static Permission Find(int permission_id)
        {
            Permission permission = null;
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT * FROM permission WHERE permission_id = @permission_id";
                db.Parameters.AddWithValue("@permission_id", permission_id);
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string permission_name = reader.GetString(1);

                        permission = new Permission(permission_name);
                        permission.permission_id = permission_id;
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return permission;
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
        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT COUNT(*) FROM permission WHERE permission_id = @permission_id";
                db.Parameters.AddWithValue("@permission_id", this.permission_id);
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