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

        public bool RepeatedPatent(String patent)
        {
            try
            {
                if (Wagon.FindByPatent(patent) != null) return true;
                foreach (Wagon wagon in this.list_wagon)
                {
                    if (wagon.patent == patent) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public void AddListWagon(string patent, string shipload_weight, string wagon_weight, string shipload_type, int station_id)
        {
            int shioload_w = Convert.ToInt32(shipload_weight);
            int wagon_w = Convert.ToInt32(wagon_weight);
            Wagon wagon = new Wagon(patent,shipload_type, shioload_w, wagon_w, station_id);
            this.list_wagon.Add(wagon);
        }

        public void FeedDataGrid(DataGridView data)
        {
            var source = new BindingSource(this.list_wagon, null);
            data.DataSource = source;
        }

        public void ClearListWagon()
        {
            this.list_wagon.Clear();
        }

        public static void FeedComboBox(ComboBox combo_box)
        {
            List<Station> list = Station.All();

            combo_box.DataSource = list;
            combo_box.DisplayMember = "name";
            combo_box.ValueMember = "station_id";
        }

        public void DeleteToWagonList(int wagon_id)
        {
            Wagon result = this.list_wagon.Find(delegate (Wagon wagon) {
                return wagon.wagon_id == wagon_id;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public bool IsThereSpace(int station_id)
        {
            Station station = Station.Find(station_id);
            int count = Station.GetCountMachineInStation(station_id);
            foreach (Wagon wagon in this.list_wagon)
            {
                if (wagon.station_id == station_id) count += 1;
            }
            if (station.capacity > count) return true;
            return false;
        }
    }
}
