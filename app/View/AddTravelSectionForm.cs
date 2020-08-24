using System;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddTravelSectionForm : Form
    {
        private TravelController travel_controller = new TravelController();
        private int init_station_id = 0;
        private int destination_station_id = 0;
        private int action_id = 0;

        public AddTravelSectionForm()
        {
            InitializeComponent();
            init_station_combo_box.Text = "Origen";
            destination_station_combo_box.Text = "Destino";
        }

        private void AddTravelSectionForm_Load(object sender, System.EventArgs e)
        {
            travel_controller.FeedInitStationComboBox(this.init_station_combo_box);
            ActionController.FeedActionsComboBox(this.actions_combo_box);
        }

        private void init_station_combo_box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }

        private void actions_combo_box_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private bool AllComboBoxSelected()
        {
            this.GetFormValues();
            if (this.init_station_id != 0 || this.destination_station_id != 0 || this.action_id != 0)
                return false;

            return true;
        }

        private void GetFormValues()
        {
            
            //this.init_station_id = Convert.ToInt32(init_station_combo_box.SelectedValue);
            //this.destination_station_id = Convert.ToInt32(destination_station_combo_box.SelectedValue);
            //this.action_id = Convert.ToInt32(actions_combo_box.SelectedValue);
        }

        private void init_station_combo_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            travel_controller.FeedDestinationStationComboBox(Convert.ToInt32(init_station_combo_box.SelectedValue), this.destination_station_combo_box);
        }

        private void actions_combo_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (AllComboBoxSelected())
            travel_controller.FeedMachinesComboBox(this.actions_combo_box.Text, Convert.ToInt32(init_station_combo_box.SelectedValue), this.machines_combo_box);
        }
    }
}
