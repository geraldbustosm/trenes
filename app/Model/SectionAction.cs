using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    public class SectionAction
    {
        public int section_action_id { get; private set; }
        public int action_id { get; set; }
        public int travel_section_id { get; set; }
        public int locomotive_id { get; set; }
        public int wagon_id { get; set; }
        private Boolean deleted;

        public SectionAction(int action_id, int travel_section_id, int locomotive_id, int wagon_id)
        {
            this.action_id = action_id;
            this.travel_section_id = travel_section_id;
            this.locomotive_id = locomotive_id;
            this.wagon_id = wagon_id;
        }

        public void Save()
        {
            if (!this.deleted)
            {
                using (SQLiteConnection conn = DatabaseUtility.GetConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.Parameters.AddWithValue("@action_id", this.action_id);
                        command.Parameters.AddWithValue("@travel_section_id", this.travel_section_id);
                        command.Parameters.AddWithValue("@locomotive_id", this.locomotive_id);
                        command.Parameters.AddWithValue("@wagon_id", this.wagon_id);

                        if (!this.CheckIfExists())
                        {
                            command.CommandText = "INSERT INTO section_action (action_id,travel_section_id,locomotive_id,wagon_id) VALUES ( @action_id, @travel_section_id, @locomotive_id, @wagon_id )";
                            this.section_action_id = Convert.ToInt32(command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = "UPDATE section_action SET (action_id= @action_id,travel_section_id= @travel_section_id,locomotive_id= @locomotive_id,wagon_id= @wagon_id) WHERE section_action_id = @section_action_id";
                            command.Parameters.AddWithValue("@section_action_id", this.section_action_id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public Boolean Delete()
        {
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "DELETE FROM section_action WHERE section_action_id = @section_action_id";
                    command.Parameters.AddWithValue("@section_action_id", this.section_action_id);
                    command.ExecuteNonQuery();
                }
            }
            this.deleted = true;
            return true;
        }

        // Static Methods

        public static SectionAction Find(int id)
        {
            SectionAction sectionAction = null;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT * FROM section_action WHERE section_action_id = @section_action_id";
                    command.Parameters.AddWithValue("@section_action_id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int action_id = reader.GetInt32(1);
                            int travel_section_id = reader.GetInt32(2);
                            int locomotive_id = reader.GetInt32(3);
                            int wagon_id = reader.GetInt32(4);

                            sectionAction = new SectionAction(action_id, travel_section_id, locomotive_id, wagon_id);
                            sectionAction.section_action_id = id;
                        }
                    }
                }
            }
            return sectionAction ?? null;
        }

        // Private Methods

        private Boolean CheckIfExists()
        {
            int count = 0;
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT COUNT(*) FROM section_action WHERE section_action_id = @section_action_id";
                    command.Parameters.AddWithValue("@section_action_id", this.section_action_id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                }
            }
            return count > 0;
        }

    }
}