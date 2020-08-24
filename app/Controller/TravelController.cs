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
    }
}
