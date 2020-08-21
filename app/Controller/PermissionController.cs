using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Model;
using Database;
using System.Data.SQLite;
using System.Data;

namespace Controller
{
    public class PermissionController
    {
        public static void FillComboBox(ComboBox c)
        {
            DataSet dataset = Permission.All();
            c.DataSource = dataset.Tables[0];
            c.ValueMember = "permission_id";
            c.DisplayMember = "permission_name";
        }
    }
}
