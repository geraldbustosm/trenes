using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddTravelSectionForm : Form
    {
        public AddTravelSectionForm()
        {
            InitializeComponent();
        }

        private void AddTravelSectionForm_Load(object sender, System.EventArgs e)
        {
            TravelController.FeedInitStationComboBox(this.init_station_combo_box);
            ActionController.FeedActionsComboBox(this.actions_combo_box);

        }

        private void init_station_combo_box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TravelController.FeedDestinationStationComboBox(this.init_station_combo_box.SelectedIndex, this.destination_station_combo_box);
        }


    }
}
