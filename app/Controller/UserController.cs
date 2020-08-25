using System;
using Model;
using Helper;
using System.Windows.Forms;
using System.Data;

namespace Controller
{
    public static class UserController
    {
        public static void fillDataGridView(DataGridView dgv)
        {
            DataSet dataset = User.All();
            dgv.DataSource = dataset.Tables[0];
        }
        public static User Authenticate(string email, string password)
        {
            if (Validation.IsEmail(email))
            {
                User user = User.Find(email);
                if (user != null && Validation.VerifyPassword(user.password, password))
                {
                    return user;
                }
            }
            return null;
        }

        public static bool CreateUser(string username, string email, string password, int permission_id)
        {
            string hashing_password = Validation.GenerateHash(password);
            User user = new User(username, email, hashing_password, permission_id);
            return user.Save();
        }
        public static bool EditUser(int id, string username, string email, string password, int permission_id)
        {
            string hashing_password = Validation.GenerateHash(password);
            User user = User.Find(id);
            user.name = username;
            user.email = email;
            user.password = hashing_password;
            user.permission_id = permission_id;
            return user.Save();
        }
        public static void AddDeleteLinkColumn(DataGridView dgv)
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            link.UseColumnTextForLinkValue = true;
            link.Name = "Eliminar";
            link.Text = "Eliminar";
            dgv.Columns.Add(link);
        }
        public static void AddEditLinkColumn(DataGridView dgv)
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            link.UseColumnTextForLinkValue = true;
            link.Name = "Editar";
            link.Text = "Editar";
            dgv.Columns.Add(link);
        }
        public static void RemoveUserFromDGV(DataGridView dgv, int id, int row)
        {
            User u = User.Find(id);
            u.Delete();
            dgv.Rows.RemoveAt(row);
        }
    }
}