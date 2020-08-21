using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;


namespace Controller
{
    public class StationController
    {
        private List<Station> listBorderStation;
        public StationController()
        {
            this.listBorderStation = new List<Station>();
        }
        public void Clear()
        {
            this.listBorderStation.Clear();
        }
        // Publics Metods
        public void Insert(string name, string capacity)
        {
            int cap = Convert.ToInt32(capacity);
            Station one = new Station(name, cap);
            one.Save();
            foreach (Station two in this.listBorderStation)
            {
                //BorderStation borderStation = new BorderStation(one.station_id, two.station_id);
                //borderStation.Save();
            }
            MessageBox.Show("Correcto");
        }
        public void DeleteBorderStation(string res)
        {
            int id = Convert.ToInt32(res);
            Station result = this.listBorderStation.Find(delegate (Station s) {
                return s.station_id == id;
            });
            this.listBorderStation.Remove(result);
        }
        public void FeedDataGridView(DataGridView dataGridView)
        {
            var source = new BindingSource(this.listBorderStation, null);
            dataGridView.DataSource = source;
        }
        public void AddListBorderStation(ComboBox comboBox)
        {
            int index = comboBox.SelectedIndex;
            Station station = Station.Find(index + 1);
            Station result = this.listBorderStation.Find(delegate (Station s) {
                return s.station_id == index + 1;
            });
            if (result != null)
            {
                MessageBox.Show("Error, estación ingresada");
            }
            else
            {
                this.listBorderStation.Add(station);
            }
        }
        // Static Metod
        public static bool IsNumber(string capacity)
        {
            try
            {
                int cap = Convert.ToInt32(capacity);
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

