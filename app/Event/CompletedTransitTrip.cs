using System;
using System.Data.SQLite;
using Database;

namespace Event
{
    class CompletedTransitTrip
    {

        public void Validate(DateTime date)
        {
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM travel WHERE ";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int capacity = reader.GetInt32(2);

                        }
                    }
                }
            }
        }
    }
}
