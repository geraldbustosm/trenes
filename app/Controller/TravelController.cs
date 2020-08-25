using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Interface;
using System.Runtime.CompilerServices;

namespace Controller
{
    public class TravelController
    {
        // this will be save on database 
        List<List<Wagon>> all_wagons_by_section;
        List<List<Locomotive>> all_locomotives_by_section;
        List<List<SectionAction>> all_actions_by_section;
        List<TravelSection> all_sections;

        // auxiliar variables
        List<SectionAction> actions_list;
        List<Locomotive> locomotive_list;
        List<Wagon> wagon_list;
        int section_index;

        public TravelController()
        {
            all_wagons_by_section = new List<List<Wagon>>();
            all_locomotives_by_section = new List<List<Locomotive>>();
            all_actions_by_section = new List<List<SectionAction>>();
            all_sections = new List<TravelSection>();
            actions_list = new List<SectionAction>();
            locomotive_list = new List<Locomotive>();
            wagon_list = new List<Wagon>();
            section_index = this.GetLastTravelSection();
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
                    combo_box.DataSource = this.all_wagons_by_section[section_index];
                    break;
                case 3: // "Quitar locomotora":
                    combo_box.DataSource = this.all_locomotives_by_section[section_index];
                    break;
                case 4: // "Descargar carro":
                    combo_box.DataSource = this.all_wagons_by_section[section_index];
                    break;
                default:
                    break;
            }
        }

        public int GetTravelIndex()
        {
            Travel travel = Travel.GetLastTravel();
            return (travel != null) ? travel.travel_id + 1 : 1;
        }

        public int GetLastTravelSection()
        {
            // lo necesito para almacenar las acciones de las secciones antes de ser ingresadas a la base de datos
            TravelSection last_travel_section = TravelSection.GetLastTravelSection();
            int id = (last_travel_section != null) ? last_travel_section.travel_id : 1;
            return id;
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
                if (type == "locomotive")
                    this.AddLocomotiveToSection(locomotive_id);
                else
                    this.AddWagonToSection(wagon_id);

                SectionAction action = new SectionAction(action_id, section_index, locomotive_id, wagon_id);
                actions_list.Add(action);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
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

        public bool AddNewSectionToTravel(string arrival_time, int origin_station_id, int destination_station_id)
        {
            // priority means the order of sections in travel
            all_actions_by_section.Add(actions_list);
            all_locomotives_by_section.Add(locomotive_list);
            all_wagons_by_section.Add(wagon_list);
            actions_list.Clear();
            // store
            TravelSection travel_section = new TravelSection(arrival_time, )
            // cont for store actions
            this.section_index++;
            return true;
        }
    }
}
