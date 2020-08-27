using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Interface;
using System.Data;
using System.Linq;

namespace Controller
{
    public class TravelController
    {
        // this will be save on database 
        List<List<SectionAction>> all_actions_by_section;
        List<TravelSection> all_sections;

        // auxiliar variables
        List<SectionAction> actions_list;
        List<Locomotive> locomotive_list;
        List<Wagon> wagon_list;
        int travel_index;
        int section_index;
        int properity;
        DateTime init_time;
        DateTime arrival_time;

        public TravelController()
        {
            all_actions_by_section = new List<List<SectionAction>>();
            all_sections = new List<TravelSection>();
            actions_list = new List<SectionAction>();
            locomotive_list = new List<Locomotive>();
            wagon_list = new List<Wagon>();
            travel_index = this.GetTravelIndex();
            section_index = this.GetLastTravelSection();
            properity = 1;
        }

        public void FeedInitStationComboBox(ComboBox combo_box)
        {
            combo_box.DataSource = Station.All();
            combo_box.DisplayMember = "name";
            combo_box.ValueMember = "station_id";
        }

        public void FeedDestinationStationComboBox(int station_id, ComboBox destination_station_combobox)
        {
            destination_station_combobox.DataSource = Station.GetNearbyStations(station_id);
            destination_station_combobox.DisplayMember = "name";
            destination_station_combobox.ValueMember = "station_id";
        }

        public void FeedMachinesComboBox(int action, int station_id, ComboBox combo_box)
        {
            combo_box.ValueMember = "patent";
            combo_box.DisplayMember = "patent";
            switch (action)
            {
                case 0: // "Agregar carro":
                    combo_box.DataSource = Wagon.GetWagonsByStation(station_id);
                    break;
                case 1: //"Agregar locomotora":
                    combo_box.DataSource = Locomotive.GetLocomotivesByStation(station_id);
                    break;
                case 2: // "Quitar carro":
                    combo_box.DataSource = wagon_list;
                    break;
                case 3: // "Quitar locomotora":
                    combo_box.DataSource = locomotive_list;
                    break;
                case 4: // "Descargar carro":
                    combo_box.DataSource = wagon_list;
                    break;
                default:
                    break;
            }
        }

        public int GetTravelIndex()
        {
            Travel last_travel = Travel.GetLastTravel();
            return (last_travel != null) ? last_travel.travel_id + 1 : 1;
        }

        public int GetLastTravelSection()
        {
            TravelSection last_travel_section = TravelSection.GetLastTravelSection();
            return (last_travel_section != null) ? last_travel_section.travel_id + 1 : 1; 
        }

        public bool AddNewActionToSection(int action_id, string patent, string type)
        {
            int locomotive_id = 0, wagon_id = 0;
            if (type == "locomotive")
                locomotive_id = Locomotive.FindByPatent(patent).locomotive_id;
            else
                wagon_id = Wagon.FindByPatent(patent).wagon_id;

            try
            {
                this.ApplyAction(action_id, locomotive_id, wagon_id);
                SectionAction action = new SectionAction(action_id, section_index, locomotive_id, wagon_id);
                actions_list.Add(action);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void ApplyAction(int action_id, int locomotive_id, int wagon_id)
        {
            switch(action_id)
            {
                case 1:
                    this.AddWagonToSection(wagon_id);
                    break;
                case 2:
                    this.AddLocomotiveToSection(locomotive_id);
                    break;
                case 3:
                    this.RemoveWagon(wagon_id);
                    break;
                case 4:
                    this.RemoveLocomotive(locomotive_id);
                    break;
                case 5:
                    //this.DownloadWagon(wagon_id);
                    break;
                default:
                    break;
            }
        }

        public void RemoveWagon(int wagon_id)
        {
            this.wagon_list.Remove(wagon_list.Find(delegate (Wagon wagon) {
                return wagon.wagon_id == wagon_id;
            }));
        }

        public void RemoveLocomotive(int locomotive_id)
        {
            this.locomotive_list.Remove(locomotive_list.Find(delegate (Locomotive locomotive) {
                return locomotive.locomotive_id == locomotive_id;
            }));
        }

        public void AddLocomotiveToSection(int locomotive_id)
        {
            Locomotive locomotive = Locomotive.FindById(locomotive_id);
            locomotive_list.Add(locomotive);
        }

        public void AddWagonToSection(int wagon_id)
        {
            Wagon wagon = Wagon.Find(wagon_id);
            wagon_list.Add(wagon);
        }

        public void FeedActionsDataGrid(DataGridView dt)
        {
            dt.DataSource = new BindingSource(this.actions_list, null);
        }

        public void FeedTrainStateDataGrid(DataGridView dt)
        {
            List<MachineInterface> machines = this.CombineLists();
            dt.DataSource = new BindingSource(machines, null);
        }

        public List<MachineInterface> CombineLists()
        {
            List<MachineInterface> list = new List<MachineInterface>();
            foreach (Wagon wagon in wagon_list)
            {
                list.Add(new MachineInterface(wagon.wagon_id, wagon.patent, "Carro"));
            }
            foreach (Locomotive locomotive in locomotive_list)
            {
                list.Add(new MachineInterface(locomotive.locomotive_id, locomotive.patent, "Locomotive"));
            }
            return list;
        }

        public bool AddNewSectionToTravel(DateTime init_time, DateTime arrival_time, int origin_station_id, int destination_station_id)
        {
            try
            {
                if (properity == 1) this.init_time = init_time;

                List<SectionAction> list = new List<SectionAction>(actions_list);
                all_actions_by_section.Add(list);
                actions_list.Clear();
                TravelSection travel_section = new TravelSection(init_time, arrival_time, this.travel_index, properity++, origin_station_id, destination_station_id);
                all_sections.Add(travel_section);
                this.section_index++;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        public void SaveTravel(DateTime init_time, DateTime arrival_time, int origin_station_id, int destination_station_id)
        {
            this.arrival_time = arrival_time;
            this.AddNewSectionToTravel(init_time, arrival_time, origin_station_id, destination_station_id);

            if (wagon_list.Count > 0 || locomotive_list.Count > 0)
                MessageBox.Show("Todas las maquinas seran almacenadas en la estacion de llegada!");
            
            Travel travel = new Travel(this.init_time, this.arrival_time, "Programado");
            travel.Save();
            foreach (TravelSection travel_section in this.all_sections)
            {
                travel_section.Save();
            }
            foreach (List<SectionAction> all_actions in this.all_actions_by_section)
            {
                foreach (SectionAction section_action in all_actions)
                {
                    section_action.Save();
                }
            }
        }

        public static void FeedDataGridTravelDetails(DataGridView data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Código");
            dt.Columns.Add("Hora Llegada");
            dt.Columns.Add("Código Viaje");
            dt.Columns.Add("Prioridad");
            dt.Columns.Add("Estación Origen");
            dt.Columns.Add("Estación Destino");

            foreach (TravelSection item in TravelSection.All())
            {
                Station origin = Station.Find(item.origin_station_id);
                Station destination = Station.Find(item.destination_station_id);

                Object[]  aux = {item.travel_section_id,item.arrival_time,item.travel_id,item.priority,origin.name,destination.name};

                dt.Rows.Add(aux);
            }

            data.DataSource = dt;
        }

        public static void FeedDataGridScheduledTravels(DataGridView dgv)
        {
            DataTable dt, dn = new DataTable();
            dn.Columns.Add("Código");
            dn.Columns.Add("Estado");
            dn.Columns.Add("Tiempo salida");
            dn.Columns.Add("Tiempo llegada");
            dn.Columns.Add("Estación origen");
            dn.Columns.Add("Estación llegada");
            dt = Travel.GetScheduledTravels().Tables[0];

            int len = dt.Rows.Count;
            for (int i=0; i < len; i++)
            {
                if (i + 1 < len && dt.Rows[i][0].ToString() == dt.Rows[i+1][0].ToString()) // funciona para duplicado adelante
                {
                    Object[] dr = { dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i + 1][3], dt.Rows[i][5], dt.Rows[i + 1][6] };
                    dn.Rows.Add(dr);
                }
                else if(i == 0 && i+1 == len) // cuando existe una sola tupla
                {
                    Object[] dr = { dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][5], dt.Rows[i][6] };
                    dn.Rows.Add(dr);
                }
                else if(i - 1 > 0 && dt.Rows[i][0].ToString() != dt.Rows[i - 1][0].ToString()) // funciona para duplicado atras
                {
                    Object[] dr = { dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][5], dt.Rows[i][6] };
                    dn.Rows.Add(dr);
                }
            }

            dgv.DataSource = dn;
        }
    }
}
