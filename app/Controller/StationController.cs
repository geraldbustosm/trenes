using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;


namespace Controller
{
    public class StationController
    {
        private List<Station> list_border_station;
        public StationController()
        {
            this.list_border_station = new List<Station>();
        }

        public void ClearList()
        {
            this.list_border_station.Clear();
        }

        public void Insert(string name, string capacity)
        {
            int cap = Convert.ToInt32(capacity);
            Station origin_station = new Station(name, cap);
            try
            {
                origin_station.Save();
                foreach (Station border_station in this.list_border_station)
                {
                    BorderStation item= new BorderStation(origin_station.station_id, border_station.station_id);
                    item.Save();
                }
                MessageBox.Show("Correcto");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de ingreso");
                Console.WriteLine(ex);
            }
        }

        public void DeleteBorderStation(string res)
        {
            int id = Convert.ToInt32(res);
            Station result = this.list_border_station.Find(delegate (Station item) {
                return item.station_id == id;
            });
            this.list_border_station.Remove(result);
        }

        public void FeedDataBorderStation(DataGridView data)
        {
            var source = new BindingSource(this.list_border_station, null);
            data.DataSource = source;
        }

        public void AddToBorderStationList(ComboBox combo_box)
        {
            int id = Convert.ToInt32(combo_box.SelectedValue);
            Station station = Station.Find(id);
            Station result = this.list_border_station.Find(delegate (Station item) {
                return item.station_id == id;
            });
            if (result != null) { MessageBox.Show("Error, estación ingresada"); }
            else { this.list_border_station.Add(station); }
        }

        // Static Metod
        public static bool IsNumberCapacity(string capacity)
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

        public static void FeedComboBox(ComboBox combo_box)
        {
            List<Station> list = Station.All();

            combo_box.DataSource = list;
            combo_box.DisplayMember = "name";
            combo_box.ValueMember = "station_id";
        }

    }
}

