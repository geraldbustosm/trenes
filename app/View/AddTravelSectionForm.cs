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
        private string action_description = "";
        private string init;
        private string arrival;
        private string init_hrs;
        private string arrival_hrs;

        public AddTravelSectionForm()
        {
            InitializeComponent();
            this.information_label.Text = "";
        }

        private void AddTravelSectionForm_Load(object sender, System.EventArgs e)
        {
            travel_controller.FeedInitStationComboBox(this.init_station_combo_box);
            int id_default_station = Int32.Parse(init_station_combo_box.SelectedValue.ToString());
            travel_controller.FeedDestinationStationComboBox(id_default_station, this.destination_station_combo_box);
            ActionController.FeedActionsComboBox(this.actions_combo_box);
            travel_controller.FeedMachinesComboBox(actions_combo_box.SelectedIndex, id_default_station, machines_combo_box);
        }

        private void init_station_combo_box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            travel_controller.FeedDestinationStationComboBox(Convert.ToInt32(init_station_combo_box.SelectedValue), this.destination_station_combo_box);
        }

        private void add_action_btn_Click(object sender, EventArgs e)
        {
            // store actions for travel_section
            int action_id = Int32.Parse(this.actions_combo_box.SelectedValue.ToString());
            bool action_to_locomotive = this.actions_combo_box.Text.Contains("locomotora");

            if (action_to_locomotive)
                travel_controller.AddNewActionToSection(action_id, machines_combo_box.SelectedValue.ToString(), "locomotive");
            else
                travel_controller.AddNewActionToSection(action_id, machines_combo_box.SelectedValue.ToString(), "wagon");

            this.RefreshActions();
            this.init_station_combo_box.Enabled = false;
            this.destination_station_combo_box.Enabled = false;
            this.RefreshTrainState();
        }

        public void RefreshTrainState()
        {
            travel_controller.FeedTrainStateDataGrid(this.train_state_datagrid);
        }

        public void RefreshActions()
        {
            travel_controller.FeedActionsDataGrid(this.actions_datagrid);
            //travel_controller.FeedBackWithReadNames(actions_datagrid);
        }

        private void next_section_btn_Click(object sender, EventArgs e)
        {
            this.init_station_id = Convert.ToInt32(init_station_combo_box.SelectedValue);
            this.destination_station_id = Convert.ToInt32(destination_station_combo_box.SelectedValue);
            this.init = this.init_date.Value.ToString("dd/MM/yyyy");
            this.arrival = this.arrival_date.Value.ToString("dd/MM/yyyy");
            this.init_hrs = this.init_hour.Value.ToString("hh:mm");
            this.arrival_hrs = this.arrival_hour.Value.ToString("hh:mm");

            // validate all things

            // this metohd will be save in travel_section table on database
            bool success = travel_controller.AddNewSectionToTravel(
                this.arrival,  
                this.init_station_id,
                this.destination_station_id
            );

            if (success)
            {
                travel_controller.FeedActionsDataGrid(this.actions_datagrid);
                this.init_station_combo_box.Text = destination_station_combo_box.Text;
                this.destination_station_combo_box.Enabled = true;
                int id = Int32.Parse(destination_station_combo_box.SelectedValue.ToString());
                travel_controller.FeedDestinationStationComboBox(id, this.destination_station_combo_box);
                travel_controller.FeedMachinesComboBox(actions_combo_box.SelectedIndex, id, machines_combo_box);
            }
            //else
            // show error information


            // actualizar combobox de destino con el nuevo INICIO
        }

        private void actions_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            travel_controller.FeedMachinesComboBox(actions_combo_box.SelectedIndex, Int32.Parse(this.init_station_combo_box.SelectedValue.ToString()), machines_combo_box);
        }

        private void save_trip_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
