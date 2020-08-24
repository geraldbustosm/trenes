using Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Model
{
    public class Action
    {
        public int action_id { get; private set; }
        public string description { get; set; }
        public int minutes { get; set; }

        public Action(string description, int minutes)
        {
            this.action_id = action_id;
            this.description = description;
            this.minutes = minutes;
        }

        public static Action Find(int id)
        {
            Action action = null;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM action WHERE action_id = @action_id";
                    command.Parameters.AddWithValue("@action_id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string description = reader.GetString(1);
                            int minutes = reader.GetInt32(2);


                            action = new Action(description, minutes);
                            action.action_id = id;
                        }
                    }
                }
            }
            return action ?? null;
        }

        public static List<Action> FindAll()
        {
            List<Action> all_actions = new List<Action>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM action";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string description = reader.GetString(1);
                            int minutes = reader.GetInt32(2);

                            Action action = new Action(description, minutes);
                            action.action_id = id;
                            all_actions.Add(action);
                        }
                    }
                }
            }
            return all_actions ?? null;
        }
    }
}