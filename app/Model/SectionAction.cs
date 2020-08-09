using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    class SectionAction
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
                SQLiteConnection connection = DatabaseUtility.GetConnection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.CheckIfExist(this.section_action_id);

                db.Parameters.AddWithValue("@action_id", this.action_id);
                db.Parameters.AddWithValue("@travel_section_id", this.travel_section_id);
                db.Parameters.AddWithValue("@locomotive_id", this.locomotive_id);
                db.Parameters.AddWithValue("@wagon_id", this.wagon_id);

                if (!exist)
                {
                    db.CommandText = "INSERT INTO section_action (action_id, travel_section_id, locomotive_id, wagon_id) values ( @action_id, @travel_section_id, @locomotive_id, @wagon_id )";

                    this.section_action_id = Convert.ToInt32(db.ExecuteScalar());
                }
                else
                {
                    db.CommandText = "UPDATE section_action SET ( action_id = @action_id, travel_section_id = @travel_section_id, locomotive_id = @locomotive_id, wagon_id = @wagon_id ) WHERE section_action_id = @section_action_id";
                    db.Parameters.AddWithValue("@section_action_id", this.section_action_id);
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Boolean Delete()
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "DELETE FROM section_action WHERE sectionAction_id = @sectionAction_id";
            db.Parameters.AddWithValue("@section_action_id", this.section_action_id);

            db.ExecuteNonQuery();

            connection.Close();

            this.deleted = true;
            return true;
        }

        // Static Methods
        public static SectionAction Find(int sectionAction_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT * FROM section_action WHERE sectionAction_id = @sectionAction_id";
            db.Parameters.AddWithValue("@section_action_id", sectionAction_id);

            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {

                int action_id = reader.GetInt32(1);
                int travel_section_id = reader.GetInt32(2);
                int locomotive_id = reader.GetInt32(3);
                int wagon_id = reader.GetInt32(4);

                SectionAction sectionAction = new SectionAction(action_id, travel_section_id, locomotive_id, wagon_id);
                sectionAction.section_action_id = sectionAction_id;
                return sectionAction;
            }

            reader.Close();
            connection.Close();
            return null;
        }

        // Private Methods

        private Boolean CheckIfExist(int sectionAction_id)
        {
            SQLiteConnection connection = DatabaseUtility.GetConnection();
            SQLiteCommand db = new SQLiteCommand(connection);

            db.CommandText = "SELECT COUNT(*) FROM section_action WHERE sectionAction_id = @sectionAction_id";
            db.Parameters.AddWithValue("@section_action_id", sectionAction_id);

            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            reader.Close();
            connection.Close();
            if (count > 0) { return true; } else { return false; }
        }

    }
}