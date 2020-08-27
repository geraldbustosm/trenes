using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Database;

namespace Event
{
    class CompletedSectionAction
    {
        struct Item
        {
            public int id;
            public int station_id;
        };
        public static void AddLocomotive()
        {
            List<int> list = new List<int>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.locomotive_id " +
                        "FROM section_action sa, action a, travel_section ts, locomotive l " +
                        "WHERE l.in_transit = 0 AND " +
                        "l.locomotive_id = sa.locomotive_id AND " +
                        "sa.action_id = a.action_id AND " +
                        "a.description LIKE('Agregar locomotora') AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.init_time <= datetime('now','localtime') AND " +
                        "ts.arrival_time > datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);

                            list.Add(id);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (int id in list)
                    {
                        command.CommandText = "UPDATE locomotive SET in_transit = 1, station_id = null  WHERE locomotive_id=  @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Update add locomotive {0:N}",id);
                    }
                }
            }
        }

        public static void AddWagon()
        {
            List<int> list = new List<int>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.wagon_id " +
                        "FROM section_action sa, action a, travel_section ts, wagon w " +
                        "WHERE w.in_transit = 0 AND " +
                        "w.wagon_id = sa.wagon_id AND " +
                        "sa.action_id = a.action_id AND " +
                        "a.description LIKE('Agregar carro') AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.init_time <= datetime('now','localtime') AND " +
                        "ts.arrival_time > datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);

                            list.Add(id);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (int id in list)
                    {
                        command.CommandText = "UPDATE wagon SET in_transit = 1, station_id = null  WHERE wagon_id=  @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Update add wagon {0:N}", id);
                    }
                }
            }
        }

        public static void RemoveLocomotive()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.locomotive_id, ts.destination_station_id " +
                        "FROM section_action sa, action a, travel_section ts, locomotive l " +
                        "WHERE l.in_transit = 1 AND " +
                        "l.locomotive_id = sa.locomotive_id AND " +
                        "sa.action_id = a.action_id AND " +
                        "a.description LIKE('Agregar Locomotora')  AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.arrival_time <= datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item;

                            int id = reader.GetInt32(0);
                            int station_id = reader.GetInt32(1);

                            item.id = id;
                            item.station_id = station_id;
                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE locomotive SET in_transit = 0, station_id = @station_id  WHERE locomotive_id=  @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        command.Parameters.AddWithValue("@station_id", item.station_id);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Update remove locomotive {0:N}", item.id);
                    }
                }
            }
        }

        public static void RemoveWagon()
        {
            List<Item> list = new List<Item>();
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT sa.wagon_id, ts.destination_station_id " +
                        "FROM section_action sa, action a, travel_section ts, wagon w " +
                        "WHERE w.in_transit = 1 AND " +
                        "w.wagon_id = sa.wagon_id AND " +
                        "sa.action_id = a.action_id AND " +
                        "a.description LIKE('Quitar carro') AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.arrival_time <= datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item;

                            int id = reader.GetInt32(0);
                            int station_id = reader.GetInt32(1);

                            item.id = id;
                            item.station_id = station_id;
                            list.Add(item);
                        }
                    }
                    if (list.Count == 0) return;
                    foreach (Item item in list)
                    {
                        command.CommandText = "UPDATE wagon SET in_transit = 0, station_id = @station_id  WHERE wagon_id=  @id";
                        command.Parameters.AddWithValue("@id", item.id);
                        command.Parameters.AddWithValue("@station_id", item.station_id);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Update remove wagon {0:N}", item.id);
                    }
                }
            }
        }
    }
}
