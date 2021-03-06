﻿using System.Collections.Generic;
using System.Data.SQLite;
using Database;

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
            return action;
        }

        public static Action FindByDescription(string description)
        {
            Action action = null;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM action WHERE description = @description";
                    command.Parameters.AddWithValue("@description", description);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int minutes = reader.GetInt32(2);
                            action = new Action(description, minutes);
                            action.action_id = id;
                        }
                    }
                }
            }
            return action;
        }

        public static Action FindById(int id)
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
            return action;
        }

        public static Stack<Action> FindAll()
        {
            Stack<Action> all_actions = new Stack<Action>();
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
                            all_actions.Push(action);
                        }
                    }
                }
            }
            return all_actions;
        }
    }
}