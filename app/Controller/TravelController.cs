using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Model;

namespace Controller
{
    public class TravelController
    {
        List<Wagon> wagons;
        List<Locomotive> locomotives;
        List<TravelSection> travel_sections_list;
        List<SectionAction> section_action_list;

        public TravelController()
        {
            wagons = new List<Wagon>();
            locomotives = new List<Locomotive>();
            travel_sections_list = new List<TravelSection>();
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

        public int GetNewTravelId()
        {
            // this method will be return a last id of travel table
            // we need that id for store a sections with this until save in database the travel
            return 0;
        }

        public bool AddNewSectionToTravel(string arrival_time, int travel_id, int origin_station_id, int destination_station_id)
        {
            // priority means the order of sections in travel
            return true;
        }
    }
}
