using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Interface;

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

        //public int GetLastTravel()
        //{
        // this method will be return a last id of travel table
        // we need that id for store a sections with this until save in database the travel
        // return Travel.GetLastTravel().travel_id;
        //}

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

            int action_id = Model.Action.FindByDescription(action_description).action_id;

            SectionAction result = this.actions_list.Find(delegate (SectionAction item) {
                return item.action_id == action_id;
            });

            if (result != null) return false;
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
            var list = wagon_list.Cast<MachineInterface>().Concat(locomotive_list.Cast<MachineInterface>());
            dt.DataSource = new BindingSource(list, null);
        }

        public bool AddNewSectionToTravel(string arrival_time, int origin_station_id, int destination_station_id)
        {
            // priority means the order of sections in travel

            // store

            // cont for store actions
            this.section_index++;
            return true;
        }

        public void DeleteActionInDataGrid(int action_id)
        {
            SectionAction result = this.actions_list.Find(delegate (SectionAction item) {
                return item.action_id == action_id;
            });
            this.actions_list.Remove(result);
        }

        public void FeedBackWithReadNames(DataGridView data)
        {
            data.Columns[0].HeaderText = "Codigo";
            data.Columns[0].HeaderText = "Acción";
            data.Columns[0].HeaderText = "Codigo";
            data.Columns[0].HeaderText = "Locomotora";
            data.Columns[0].HeaderText = "Bagón";
            for (int row = 0; row < data.Rows.Count - 1; row++)
            {
                for (int col = 0;col < data.Columns.Count; col++)
                {
                    int id = Convert.ToInt32(data.Rows[row].Cells[col].Value);
                    switch (col)
                    {
                        case 0: // Section_action_id
                            
                            break;
                        case 1: // Action_id
                            Model.Action action = Model.Action.FindById(id);
                            data.Rows[row].Cells[col].Value = action.description;
                            break;
                        case 2: // Travel_section_id
                            
                            break;
                        case 3: // Locomotove_id
                            Locomotive locomotive = Locomotive.FindById(id);
                            data.Rows[row].Cells[col].Value = locomotive.patent;
                            break;
                        case 4: // Wagon_id
                            Wagon wagon = Wagon.FindById(id);
                            data.Rows[row].Cells[col].Value = wagon.patent;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
