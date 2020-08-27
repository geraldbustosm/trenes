using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Database;

namespace Event
{
    class CompletedTravelSection
    {
        struct Item
        {
            public int id;
            public int station_id;
        };
        public static void ProgramToInTransit()
        {
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "UPDATE travel SET state = 'En Transito' WHERE init_time <= datetime('now','localtime') AND arrival_time > datetime('now','localtime') AND state LIKE('Programado')";
                    command.ExecuteNonQuery();
                    Console.WriteLine("Programdo -> En tansito");
                }
            }
        }

        public static void InTransitToCompleted()
        {
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "UPDATE travel SET state = 'Completado' WHERE arrival_time <= datetime('now','localtime') AND state LIKE('En Transito')";
                    command.ExecuteNonQuery();
                    Console.WriteLine("En Transito -> Completado");
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
                    command.CommandText = "SELECT w.wagon_id, ts.destination_station_id " +
                        "FROM section_action sa, travel_section ts, wagon w, travel t " +
                        "WHERE w.in_transit = 1 AND " +
                        "w.wagon_id = sa.wagon_id AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.travel_id = t.travel_id AND " +
                        "t.arrival_time <= datetime('now','localtime')";
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
                        Console.WriteLine("Update travel complete wagon {0:N}", item.id);
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
                    command.CommandText = "SELECT l.locomotive_id, ts.destination_station_id " +
                        "FROM section_action sa, travel_section ts, locomotive l, travel t " +
                        "WHERE l.in_transit = 1 AND " +
                        "l.locomotive_id = sa.locomotive_id AND " +
                        "sa.travel_section_id = ts.travel_section_id AND " +
                        "ts.travel_id = t.travel_id AND " +
                        "t.arrival_time <= datetime('now','localtime')";
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
                        Console.WriteLine("Update travel completed locomotive {0:N}", item.id);
                    }
                }
            }
        }

        public static void TimeNow()
        {
            using (SQLiteConnection conn = DatabaseUtility.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText = "SELECT datetime('now','localtime')";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime fecha = reader.GetDateTime(0);
                            Console.WriteLine(fecha);
                        }
                    }
                }
            }
        }
    }
}
