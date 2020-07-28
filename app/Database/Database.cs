using System;
using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class DatabaseUtility
    {
        static private string db_file = Path.GetFullPath(@"..\\..\\..\\Database\\database.db");
        static private string db_script = Path.GetFullPath(@"..\\..\\..\\Database\\database.sql");

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

        // Metodo para restablecer la base de datos
        static public void ResetDatabase()
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
    };
}
