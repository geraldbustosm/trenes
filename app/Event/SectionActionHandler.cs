using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Database;

namespace Event
{
    class SectionActionHandler
    {

        struct Item
        {
            public int id;
            public int station_id;
            public int section_action_id;
        };
        public static void LocomotiveAddedToTrain()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.locomotive_id, sa.section_action_id " +
                        "FROM section_action sa, travel_section ts, locomotive l " +
                        "WHERE l.in_transit = 0 AND " +
                        "sa.executed = 0 AND " +
                        "l.locomotive_id = sa.locomotive_id AND " +
                        "sa.action_id = 2 AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.init_time <= datetime('now','localtime') AND " +
                        "ts.arrival_time > datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.id = reader.GetInt32(0);
                            item.section_action_id = reader.GetInt32(1);

                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;

                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE section_action SET executed = 1 WHERE section_action_id = @section_action_id";
                        command.Parameters.AddWithValue("@section_action_id", item.section_action_id);
                        command.ExecuteNonQuery();
                        
                        command.CommandText = "UPDATE locomotive SET in_transit = 1, station_id = null WHERE locomotive_id = @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine($"Add locomotive {item.id} to train");
                    }
                }
            }
        }

        public static void WagonAddedToTrain()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.wagon_id, sa.section_action_id " +
                        "FROM section_action sa, travel_section ts, wagon w " +
                        "WHERE w.in_transit = 0 AND " +
                        "sa.executed = 0 AND " +
                        "w.wagon_id = sa.wagon_id AND " +
                        "sa.action_id = 1 AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.init_time <= datetime('now','localtime') AND " +
                        "ts.arrival_time > datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.id = reader.GetInt32(0);
                            item.section_action_id = reader.GetInt32(1);
                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE section_action SET executed = 1 WHERE section_action_id = @section_action_id";
                        command.Parameters.AddWithValue("@section_action_id", item.section_action_id);
                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE wagon SET in_transit = 1, station_id = null WHERE wagon_id = @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine($"Add wagon {item.id} to train");
                    }
                }
            }
        }

        public static void LocomotiveTravelCompleted()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.locomotive_id, ts.destination_station_id, sa.section_action_id " +
                        "FROM section_action sa, travel_section ts, locomotive l " +
                        "WHERE l.in_transit = 1 AND " +
                        "sa.executed = 0 AND " +
                        "l.locomotive_id = sa.locomotive_id AND " +
                        "sa.action_id = 6 AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.arrival_time <= datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.id = reader.GetInt32(0);
                            item.station_id = reader.GetInt32(1);
                            item.section_action_id = reader.GetInt32(2);
                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE section_action SET executed = 1 WHERE section_action_id = @section_action_id";
                        command.Parameters.AddWithValue("@section_action_id", item.section_action_id);
                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE locomotive SET in_transit = 0, station_id = @station_id WHERE locomotive_id = @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        command.Parameters.AddWithValue("@station_id", item.station_id);
                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine($"Locomotive {item.id} stored!");
                    }
                }
            }
        }

        public static void LocomotiveRemovedFromTrain()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.locomotive_id, ts.origin_station_id, sa.section_action_id " +
                        "FROM section_action sa, travel_section ts, locomotive l " +
                        "WHERE l.in_transit = 1 AND " +
                        "sa.executed = 0 AND " +
                        "l.locomotive_id = sa.locomotive_id AND " +
                        "sa.action_id = 4 AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.arrival_time <= datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.id = reader.GetInt32(0);
                            item.station_id = reader.GetInt32(1);
                            item.section_action_id = reader.GetInt32(2);
                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE section_action SET executed = 1 WHERE section_action_id = @section_action_id";
                        command.Parameters.AddWithValue("@section_action_id", item.section_action_id);
                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE locomotive SET in_transit = 0, station_id = @station_id WHERE locomotive_id = @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        command.Parameters.AddWithValue("@station_id", item.station_id);
                        if(command.ExecuteNonQuery() > 0)
                            Console.WriteLine($"Remove locomotive {item.id} from train");
                    }
                }
            }
        }

        public static void WagonTravelCompleted()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.wagon_id, ts.destination_station_id, sa.section_action_id " +
                        "FROM section_action sa, travel_section ts, wagon w " +
                        "WHERE w.in_transit = 1 AND " +
                        "sa.executed = 0 AND " +
                        "w.wagon_id = sa.wagon_id AND " +
                        "sa.action_id = 5 AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.arrival_time <= datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.id = reader.GetInt32(0);
                            item.station_id = reader.GetInt32(1);
                            item.section_action_id = reader.GetInt32(2);
                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE section_action SET executed = 1 WHERE section_action_id = @section_action_id";
                        command.Parameters.AddWithValue("@section_action_id", item.section_action_id);
                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE wagon SET in_transit = 0, station_id = @station_id WHERE wagon_id = @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        command.Parameters.AddWithValue("@station_id", item.station_id);
                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine($"Wagon {item.id} stored");
                    }
                }
            }
        }

        public static void WagonRemovedFromTrain()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.wagon_id, ts.origin_station_id, sa.section_action_id " +
                        "FROM section_action sa, action a, travel_section ts, wagon w " +
                        "WHERE w.in_transit = 1 AND " +
                        "sa.executed = 0 AND " +
                        "w.wagon_id = sa.wagon_id AND " +
                        "sa.action_id = 3 AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.init_time <= datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item;
                            item.id = reader.GetInt32(0);
                            item.station_id = reader.GetInt32(1);
                            item.section_action_id = reader.GetInt32(2);
                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE section_action SET executed = 1 WHERE section_action_id = @section_action_id";
                        command.Parameters.AddWithValue("@section_action_id", item.section_action_id);
                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE wagon SET in_transit = 0, station_id = @station_id WHERE wagon_id = @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        command.Parameters.AddWithValue("@station_id", item.station_id);
                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine($"Remove wagon {item.id} from train");
                    }
                }
            }
        }
    }
}
