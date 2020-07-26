using Database;
using System;
using System.Data.SQLite;

namespace Model
{
    class SectionAction
    {
        private int id;
        private int action_id;
        private int travel_section_id;
        private int locomotive_id;
        private int wagon_id;
        private Boolean deleted;

        public SectionAction (int id, int action_id, int travel_section_id, int locomotive_id, int wagon_id)
        {
            this.id = id;
            this.action_id = action_id;
            this.travel_section_id = travel_section_id;
            this.locomotive_id = locomotive_id;
            this.wagon_id = wagon_id;
        }

        // Public Methods

        public int getId() { return id; }
        public int getAction_id() { return action_id; }
        public int getTravel_section_id() { return travel_section_id; }
        public int getLocomotive_id() { return locomotive_id; }
        public int getWagon_id() { return wagon_id; }

        public void setAction_id(int action_id) { this.action_id = action_id; }
        public void setTravel_section_id(int travel_section_id) { this.travel_section_id = travel_section_id; }
        public void setLocomotive_id(int locomotive_id) { this.locomotive_id = locomotive_id; }
        public void setWagon_id(int wagon_id) { this.wagon_id = wagon_id; }

        public void save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.checkIfUserExist(this.id);

                if (!exist)
                {
                    string query = "INSERT INTO section_action (section_action_id, action_id, travel_section_id, locomotive_id, wagon_id) values (" + this.id + "," + this.action_id + "," + this.travel_section_id + "," + this.locomotive_id + "," + this.wagon_id + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE section_action SET section_action_id = " + this.id + ", action_id = " + this.action_id + ", travel_section_id = " + this.travel_section_id + ",locomotive_id = " + this.locomotive_id + ",wagon_id = " + this.wagon_id + ") WHERE ID=" + this.id;
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Boolean delete()
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "DELETE FROM section_action WHERE ID = " + this.id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static Methods

        public static SectionAction find(int id)
        {

            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM section_action WHERE ID = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {

                int action_id = reader.GetInt32(1);
                int travel_section_id = reader.GetInt32(2);
                int locomotive_id = reader.GetInt32(3);
                int wagon_id = reader.GetInt32(4);

                return new SectionAction (id, action_id, travel_section_id, locomotive_id, wagon_id);
            }
            connection.Close();
            return null;
        }

        // Private Methods

        private Boolean checkIfUserExist(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM section_action WHERE ID=" + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            if (count > 0) { return true; } else { return false; }
        }

    }
}
