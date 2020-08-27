﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Database;

namespace Event
{
    class CompletedTravel
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
                    command.CommandText = "UPDATE travel SET state = 'En-Transito' WHERE init_time <= datetime('now','localtime') AND arrival_time > datetime('now','localtime') AND state LIKE('Programado')";
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
                    command.CommandText = "UPDATE travel SET state = 'Completado' WHERE arrival_time <= datetime('now','localtime') AND state LIKE('En-Transito')";
                    command.ExecuteNonQuery();
                    Console.WriteLine("En Transito -> Completado");
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