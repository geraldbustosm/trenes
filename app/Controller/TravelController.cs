using System.Windows.Forms;
using Model;

namespace Controller
{
    public class TravelController
    {
        public static void FeedInitStationComboBox(ComboBox combo_box)
        {
            combo_box.DataSource = Station.All();
            combo_box.DisplayMember = "name";
            combo_box.ValueMember = "station_id";
        }

        public static void FeedDestinationStationComboBox(int station_id, ComboBox combo_box)
        {
            combo_box.DataSource = Station.GetNearbyStations(station_id);
            combo_box.DisplayMember = "name";
            combo_box.ValueMember = "station_id";
        }
    }
}
