using System;
using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class DatabaseUtility
    {
        private static string db_file = System.IO.Path.GetFullPath(@"..\\..\\..\\Database\\database.db");
        private static string db_script = System.IO.Path.GetFullPath(@"..\\..\\..\\Database\\database.sql");
        public static string Path { get { return "Data Source=" + db_file; } }

        // Metodo para obtener la conexión a la base de datos
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file);

            try
            {
                connection.Open();
                Console.WriteLine("database started!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connection;
        }

        public static SQLiteConnection GetConnectionWithCascadeMode()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_file);

            try
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "PRAGMA foreign_keys = ON";
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("database started with cascade mode");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connection;
        }

        // Metodo para restablecer la base de datos
        public static void ResetDatabase()
        {
            if(!File.Exists(db_file)) 
            {
                SQLiteConnection.CreateFile(db_file);
                SQLiteConnection connection = GetConnection();
                SQLiteCommand sqlite = new SQLiteCommand(connection);

                try
                {
                    sqlite.CommandText = File.ReadAllText(db_script);
                    sqlite.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("database created!");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    };
}
