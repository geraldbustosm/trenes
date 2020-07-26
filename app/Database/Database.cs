using System;
using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class DatabaseUtility
    {
        // Metodo para iniciar la conexión con la base de datos
        static public SQLiteConnection InitConnection()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=database.db");
   
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

        // Método para realizar una consulta a la base de datos
        static public SQLiteConnection connection()
        {
            return InitConnection();
        }

        // Metodo para restablecer la base de datos
        static public void ResetDatabase()
        {
            SQLiteConnection connection = InitConnection();
            SQLiteCommand sqlite = new SQLiteCommand(connection);

            try
            {
                // Drop todas las tablas de la base de datos
                string sql_drop_tables = "DROP TABLE IF EXISTS user;" +
                    "DROP TABLE IF EXISTS wagon;";
                sqlite.CommandText = sql_drop_tables;
                sqlite.ExecuteNonQuery();

                // Crear todas las tablas de la base de datos
                string sql_create_tables = "CREATE TABLE user(id INTEGER PRIMARY KEY, email TEXT, password TEXT);" +
                    "CREATE TABLE wagon(id INTEGER PRIMARY KEY, capacity TEXT, code TEXT, material TEXT, origin TEXT, destiny TEXT);";
                sqlite.CommandText = sql_create_tables;
                sqlite.ExecuteNonQuery();

            } 
            catch (Exception ex)
            {
                throw ex;
            }

            Console.WriteLine("database restored!");
        }
    };
}
