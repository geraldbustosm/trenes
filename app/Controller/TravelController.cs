using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Model;

namespace Controller
{
    public class TravelController
    {
        // this will be save on database 
        List<List<Wagon>> all_wagons_by_section;
        List<List<Locomotive>> all_locomotiyves_by_section;
        List<List<SectionAction>> all_actions_by_section;
        List<TravelSection> all_sections;

        // auxiliar variables
        List<SectionAction> actions_list;
        int section_index;

        public TravelController()
        {
            all_wagons_by_section = new List<List<Wagon>>();
            all_locomotiyves_by_section = new List<List<Locomotive>>();
            all_actions_by_section = new List<List<SectionAction>>();
            all_sections = new List<TravelSection>();
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

        public void FeedMachinesComboBox(string action, int station_id, ComboBox combo_box)
        {
            combo_box.ValueMember = "patent";
            combo_box.DisplayMember = "patent";
            switch (action)
            {
                case "Agregar carro":
                    combo_box.DataSource = Wagon.GetWagonsByStation(station_id);
                    break;
                case "Agregar locomotora":
                    combo_box.DataSource = Locomotive.GetLocomotivesByStation(station_id);
                    break;
                case "Quitar carro":
                    combo_box.DataSource = this.wagons;
                    break;
                case "Quitar locomotora":
                    combo_box.DataSource = this.locomotives;
                    break;
                case "Descargar carro":
                    combo_box.DataSource = this.wagons;
                    break;
                default:
                    break;
            }
        }

        public int GetLastTravel()
        {
            // this method will be return a last id of travel table
            // we need that id for store a sections with this until save in database the travel
            return Travel.GetLastTravel().travel_id;
        }

        public int GetLastTravelSection()
        {
            // lo necesito para almacenar las acciones de las secciones antes de ser ingresadas a la base de datos
            return TravelSection.GetLastTravelSection().travel_section_id;
        }

        public bool AddNewActionToSection(string action_description, string patent, string type)
        {
            int locomotive_id = 0, wagon_id = 0;
            if (type == "locomotive")
                locomotive_id = Locomotive.FindByPatent(patent).locomotive_id;
            else
                wagon_id = Wagon.FindByPatent(patent).wagon_id;

            try
            {
                int action_id = Model.Action.FindByDescription(action_description).action_id;
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

        public bool AddNewSectionToTravel(string arrival_time, int travel_id, int origin_station_id, int destination_station_id)
        {
            // priority means the order of sections in travel

            // store

            // cont for store actions
            this.section_cont++;
            return true;
        }
    }
}
