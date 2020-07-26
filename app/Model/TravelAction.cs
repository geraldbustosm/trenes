using Database;
using System;
using System.Data.SQLite;


namespace Model
{
    class TravelAction
    {
        private int id;
        private string arrival_time;
        private int travel_id;
        private int order;
        private int action;
        private int origin_station_id;
        private int destination_station_id;
        private Boolean deleted;

        public TravelAction (int id, string arrival_time, int travel_id, int order, int action, int origin_station_id, int destination_station_id)
        {
            this.id = id;
            this.arrival_time = arrival_time;
            this.travel_id = travel_id;
            this.order = order;
            this.action = action;
            this.origin_station_id = origin_station_id;
            this.destination_station_id = destination_station_id;

        }

        // Public Methods

        public int getId() { return this.id; }
        public string getArrival_time() { return this.arrival_time; }
        public int getTravel_id() { return this.travel_id; }
        public int getOrder() { return this.order; }
        public int getAction() { return this.action; }
        public int getOrigin_station_id() { return this.origin_station_id; }
        public int getDestination_station() { return this.destination_station_id; }

        public void setArrival_time(string arrival_time) { this.arrival_time = arrival_time; }
        public void setTravel_id(int travel_id) { this.travel_id = travel_id; }
        public void setOrder(int order) { this.order = order; }
        public void setAction(int action) { this.action = action; }
        public void setOrigin_station_id(int origin_station_id) { this.origin_station_id = origin_station_id; }
        public void setDestination_station_id(int destination_station_id) { this.destination_station_id = destination_station_id; }

        public void save()
        {
            if (!this.deleted)
            {
                SQLiteConnection connection = DatabaseUtility.connection();
                SQLiteCommand db = new SQLiteCommand(connection);
                Boolean exist = this.checkIfExist(this.id);

                if (!exist)
                {
                    string query = "INSERT INTO travel_section(id, arrival_time, travel_id, order, action, origin_station_id, destination_station_id) values (" + this.id + "," + this.arrival_time + "," + this.travel_id + "," + this.order + "," + this.action + "," + this.origin_station_id + "," + this.destination_station_id + ")";
                    db.CommandText = query;
                    db.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE travel_section SET id = " + this.id + ", arrival_time = " + this.arrival_time + ", travel_id =" + this.travel_id + ",order =" + this.order + ", action =" + this.action + ",origin_station_id =" + this.origin_station_id + ",destination_station_id =" + this.destination_station_id + ") WHERE ID=" + this.id;
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
            string query = "DELETE FROM travel_section WHERE ID = " + this.id;
            db.CommandText = query;
            db.ExecuteNonQuery();
            this.deleted = true;
            return true;
        }

        // Static Methods

        public static TravelAction find(int id)
        {

            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT * FROM travel_section WHERE ID = " + id;
            db.CommandText = query;
            SQLiteDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                string arrival_time = reader.GetString(1);
                int travel_id = reader.GetInt32(2);
                int order = reader.GetInt32(3);
                int action = reader.GetInt32(4);
                int origin_station_id = reader.GetInt32(5);
                int destination_station_id = reader.GetInt32(6);

                return new TravelAction(id, arrival_time, travel_id, order, action, origin_station_id, destination_station_id);
            }
            connection.Close();
            return null;
        }

        private Boolean checkIfExist(int id)
        {
            SQLiteConnection connection = DatabaseUtility.connection();
            SQLiteCommand db = new SQLiteCommand(connection);
            string query = "SELECT COUNT(*) FROM travel_section WHERE ID=" + id;
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
