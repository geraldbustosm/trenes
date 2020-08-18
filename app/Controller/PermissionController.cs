using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Model;
using Database;
using System.Data.SQLite;

namespace Controller
{
    public class PermissionController
    {
        public static void FillComboBox(ComboBox c)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseUtility.Path))
            {
                connection.Open();
                SQLiteCommand db = new SQLiteCommand(connection);
                db.CommandText = "SELECT permission_name FROM permission";
                using (SQLiteDataReader reader = db.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        c.Items.Insert(i,reader.GetString(0));
                        i++;
                    }
                    reader.Close();
                }
                connection.Close();
                c.SelectedIndex = 0;
            }
        }
    }
}
