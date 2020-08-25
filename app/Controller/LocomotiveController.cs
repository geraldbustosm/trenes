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

        public bool RepeatedPatent(String patent)
        {
            try
            {
                if (Locomotive.FindByPatent(patent) != null) return true;
                foreach (Locomotive locomotive in this.list_locomotive)
                {
                    if (locomotive.patent == patent) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public void FeedLocomotiveDataGrid(DataGridView data)
        {
            var source = new BindingSource(this.list_locomotive, null);
            data.DataSource = source;
        }

        public void AddToLocomotiveList(ComboBox combo_box, string patent, string drag_capacity)
        {
            int station_id = Convert.ToInt32(combo_box.SelectedValue);
            int tons_drag = Convert.ToInt32(drag_capacity);
            Locomotive locomotive = new Locomotive(patent, tons_drag, station_id);
            this.list_locomotive.Add(locomotive);
        }

        public void ClearLocomotiveList()
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

        public void DeleteToLocomotiveList(int locomotive_id)
        {
            Locomotive result = this.list_locomotive.Find(delegate (Locomotive l) {
                return l.locomotive_id == locomotive_id;
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
            }
            catch (Exception ex)
            {
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
