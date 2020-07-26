using System;
using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class DatabaseUtility
    {
        static private string db_file = Path.GetFullPath(@"..\\..\\..\\..\\Database\\database.db");
        static private string db_script = Path.GetFullPath(@"..\\..\\..\\..\\Database\\database.sql");

        // Metodo para iniciar la conexión con la base de datos
        static public SQLiteConnection InitConnection()
        {
            SQLiteConnection.CreateFile(db_file);
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
                sqlite.CommandText = File.ReadAllText(db_script);
                sqlite.ExecuteNonQuery();
                Console.WriteLine("database created!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    };
}
