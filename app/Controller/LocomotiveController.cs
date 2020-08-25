using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace Controller
{
    public class LocomotiveController
    {
        private List<Locomotive> list_locomotive;
        public LocomotiveController()
        {
            this.list_locomotive = new List<Locomotive>();
        }
        public void FeedDataGrid(DataGridView dataGridView)
        {
            var source = new BindingSource(this.list_locomotive, null);
            dataGridView.DataSource = source;
        }
        public void AddLocomotive(ComboBox comboBox, string patetnt, string drag_capacity)
        {
            int station_id = Convert.ToInt32(comboBox.SelectedValue);
            int tons_drag = Convert.ToInt32(drag_capacity);
            Locomotive locomotive = new Locomotive(patetnt, tons_drag, station_id);
            this.list_locomotive.Add(locomotive);
        }
        public void Clear()
        {
            this.list_locomotive.Clear();
        }
        public bool Insert()
        {
            try
            {
                foreach (Locomotive one in this.list_locomotive)
                {
                    one.Save();
                }
                MessageBox.Show("Correcto");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ...");
                Console.WriteLine(ex);
                return false;
            }
        }
        public void DeleteLocomotive(string res)
        {
            int id = Convert.ToInt32(res);
            Locomotive result = this.list_locomotive.Find(delegate (Locomotive l) {
                return l.locomotive_id == id;
            });
            this.list_locomotive.Remove(result);
        }
        public static bool IsNumberCapacity(string drag_capacity)
        {
            try
            {
                int cap = Convert.ToInt32(drag_capacity);
                if (cap >= 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error, ingrese una capacidad positiva");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, ingrese un valor numerico campo capacidad");
                Console.WriteLine(ex);
            }
            return false;
        }
        public static void FeedComboBox(ComboBox comboBox)
        {
            List<Station> list = Station.All();

            comboBox.DataSource = list;
            comboBox.DisplayMember = "name";
            comboBox.ValueMember = "station_id";
        }

    }
}
