using System.Collections.Generic;
using Model;
using System.Windows.Forms;
using System;

namespace Controller
{
    public class WagonController
    {
        private List<Wagon> list_wagon;
        public WagonController()
        {
            this.list_wagon = new List<Wagon>();
        }
        public bool Insert()
        {
            try
            {
                foreach (Wagon wagon in this.list_wagon)
                {
                    wagon.Save();
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
        public void AddListWagon(string patent, string shipload_weight, string wagon_weight, string shipload_type, ComboBox comboBox)
        {
            int shioload_w = Convert.ToInt32(shipload_weight);
            int wagon_w = Convert.ToInt32(wagon_weight);
            int station_id = Convert.ToInt32(comboBox.SelectedValue);
            Wagon wagon = new Wagon(patent,shipload_type, shioload_w, wagon_w, station_id);
            this.list_wagon.Add(wagon);
        }
        public void FeedDataGrid(DataGridView dataGridView)
        {
            var source = new BindingSource(this.list_wagon, null);
            dataGridView.DataSource = source;
        }
        public void Clear()
        {
            this.list_wagon.Clear();
        }
        public static void FeedComboBox(ComboBox comboBox)
        {
            List<Station> list = Station.All();

            comboBox.DataSource = list;
            comboBox.DisplayMember = "name";
            comboBox.ValueMember = "station_id";
        }
        public void DeleteWagon(string res)
        {
            int id = Convert.ToInt32(res);
            Wagon result = this.list_wagon.Find(delegate (Wagon w) {
                return w.wagon_id == id;
            });
            this.list_wagon.Remove(result);
        }
        public static bool IsNumber(string number)
        {
            try
            {
                int cap = Convert.ToInt32(number);
                if (cap >= 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error, ingrese un valor positivo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, ingrese un valor numerico");
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}
