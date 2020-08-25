using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Model;
using Database;
using System.Data.SQLite;
using System.Data;
using Helper;

namespace Controller
{
    public class PermissionController
    {
        public static void FeedComboBox(ComboBox c)
        {
            DataSet dataset = Permission.All();
            c.DataSource = dataset.Tables[0];
            c.ValueMember = "permission_id";
            c.DisplayMember = "permission_name";
        }

        public static void FeedComboBoxForEdit(ComboBox c, string permission_name)
        {
            
            DataSet dataset = Permission.All();
            c.DataSource = dataset.Tables[0];
            c.ValueMember = "permission_id";
            c.DisplayMember = "permission_name";
            int index = c.FindString(permission_name);
            c.SelectedIndex = index;
        }
    }
}
