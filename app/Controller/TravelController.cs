using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Interface;
using System.Data;

namespace Controller
{
    public class TravelController
    {
        // this will be save on database 
        List<List<SectionAction>> all_actions_by_section;
        List<TravelSection> all_sections;

        // auxiliar variables
        List<Station> stations;
        List<List<Wagon>> wagons_by_station;
        List<List<Locomotive>> locomotives_by_station;
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
            stations = Station.All();
            wagons_by_station = WagonController.GetAllWagonsByStation(this.stations);
            locomotives_by_station = LocomotiveController.GetAllLocomotivesByStation(this.stations);
        }

        public void FeedInitStationComboBox(ComboBox combo_box)
        {
            combo_box.DataSource = stations;
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
                    combo_box.DataSource = this.GetWagonsByStation(station_id);
                    break;
                case 1: //"Agregar locomotora":
                    combo_box.DataSource = this.GetLocomotivesByStation(station_id);
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

        public List<Wagon> GetWagonsByStation(int station_id)
        {
            int index = FindIndexOfStation(station_id);
            return wagons_by_station[index];
        }

        public List<Locomotive> GetLocomotivesByStation(int station_id)
        {
            int index = FindIndexOfStation(station_id);
            return locomotives_by_station[index];
        }

        public int FindIndexOfStation(int station_id)
        {
            return stations.FindIndex(
                delegate (Station station)
                {
                    return station.station_id.Equals(station_id);
                });
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

        public bool AddNewActionToSection(int action_id, int station_id, string patent, string type)
        {
            int locomotive_id = 0, wagon_id = 0;
            if (type == "locomotive")
                locomotive_id = Locomotive.FindByPatent(patent).locomotive_id;
            else
                wagon_id = Wagon.FindByPatent(patent).wagon_id;

            try
            {
                this.ApplyAction(action_id, locomotive_id, wagon_id, station_id);
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

        public void ApplyAction(int action_id, int locomotive_id, int wagon_id, int station_id)
        {
            switch(action_id)
            {
                case 1:
                    this.AddWagonToTrain(wagon_id, station_id);
                    break;
                case 2:
                    this.AddLocomotiveToTrain(locomotive_id, station_id);
                    break;
                case 3:
                    this.RemoveWagonFromTrain(wagon_id, station_id);
                    break;
                case 4:
                    this.RemoveLocomotiveFromTrain(locomotive_id, station_id);
                    break;
                case 5:
                    MessageBox.Show("Funcionalidad deshabilitada!");
                    break;
                default:
                    break;
            }
        }

        public void RemoveWagonFromTrain(int wagon_id, int station_id)
        {
            this.wagon_list.Remove(wagon_list.Find(delegate (Wagon wagon) {
                return wagon.wagon_id == wagon_id;
            }));

            int index = FindIndexOfStation(station_id);
            Wagon w = Wagon.Find(wagon_id);
            wagons_by_station[index].Add(w);
        }

        public void RemoveLocomotiveFromTrain(int locomotive_id, int station_id)
        {
            this.locomotive_list.Remove(locomotive_list.Find(delegate (Locomotive locomotive) {
                return locomotive.locomotive_id == locomotive_id;
            }));

            int index = FindIndexOfStation(station_id);
            Locomotive l = Locomotive.FindById(locomotive_id);
            locomotives_by_station[index].Add(l);
        }

        public void AddLocomotiveToTrain(int locomotive_id, int station_id)
        {
            Locomotive locomotive = Locomotive.FindById(locomotive_id);
            locomotive_list.Add(locomotive);

            int index = FindIndexOfStation(station_id);
            this.locomotives_by_station[index].Remove(locomotives_by_station[index].Find(delegate (Locomotive l) {
                return l.locomotive_id == locomotive_id;
            }));
        }

        public void AddWagonToTrain(int wagon_id, int station_id)
        {
            Wagon wagon = Wagon.Find(wagon_id);
            wagon_list.Add(wagon);

            int index = FindIndexOfStation(station_id);
            this.wagons_by_station[index].Remove(wagons_by_station[index].Find(delegate (Wagon w) {
                return w.wagon_id == wagon_id;
            }));
        }

        public void FeedActionsDataGrid(DataGridView dt)
        {
            DataTable data = new DataTable();
            data.Columns.Add("Tramo");
            data.Columns.Add("Acción");
            data.Columns.Add("Tiempo");
            data.Columns.Add("Patente");
            data.Columns.Add("Tipo");

            foreach (SectionAction action in actions_list)
            {
                Model.Action _action = Model.Action.FindById(action.action_id);
                _action.description = (_action.description.Contains("Agregar")) ? "Agregar" : "Quitar";
                Locomotive locomotive = Locomotive.FindById(action.locomotive_id);
                if (locomotive == null)
                {
                    Wagon wagon = Wagon.FindById(action.wagon_id);
                    Object[] row = {this.properity, _action.description, _action.minutes, wagon.patent, "Carro"};
                    data.Rows.Add(row);
                }
                else
                {
                    Object[] row = {this.properity,_action.description, _action.minutes, locomotive.patent, "Locomotora"};
                    data.Rows.Add(row);
                }
            }
            dt.DataSource = data;
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
                list.Add(new MachineInterface(locomotive.locomotive_id, locomotive.patent, "Locomotora"));
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
        public static void AddDeleteLinkColumn(DataGridView dt)
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            link.UseColumnTextForLinkValue = true;
            link.Name = "Eliminar";
            link.Text = "Eliminar";
            dt.Columns.Add(link);
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
        public void FeedLocomotiveComboBox(ComboBox cb)
        {
            cb.DataSource = locomotive_list;
            cb.DisplayMember = "patent";
            cb.ValueMember = "patent";
        }
        public void FeedCapacityLabel(Label capacity_label,string patente)
        {
            Locomotive locomotive = Locomotive.FindByPatent(patente);
            if (locomotive != null)
                capacity_label.Text = locomotive.tons_drag.ToString();
            else
                capacity_label.Text = "Seleccione locomotora de arrastre";

        }
    }
}
