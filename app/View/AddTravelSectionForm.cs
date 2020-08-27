using System;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddTravelSectionForm : Form
    {
        LayoutForm _layout_form;
        private TravelController travel_controller = new TravelController();
        private int init_station_id = 0;
        private int destination_station_id = 0;
        private string action_description = "";
        private string init;
        private string arrival;
        private string init_hrs;
        private string arrival_hrs;

        public AddTravelSectionForm(LayoutForm layout_form)
        {
            InitializeComponent();
            this.information_label.Text = "";
            _layout_form = layout_form;
            this.RefreshActions();
            TravelController.AddDeleteLinkColumn(actions_datagrid);
            this.RefreshTrainState();
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
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshTrainState()
        {
            travel_controller.FeedTrainStateDataGrid(this.train_state_datagrid);
            train_state_datagrid.Columns[0].HeaderText = "Código";
            train_state_datagrid.Columns[1].HeaderText = "Patente";
            train_state_datagrid.Columns[2].HeaderText = "Tipo";
        }

        public void RefreshActions()
        {
            travel_controller.FeedActionsDataGrid(this.actions_datagrid);
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

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void actions_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            travel_controller.FeedMachinesComboBox(actions_combo_box.SelectedIndex, Int32.Parse(this.init_station_combo_box.SelectedValue.ToString()), machines_combo_box);
        }

        private void save_trip_btn_Click(object sender, EventArgs e)
        {
            this.arrival = this.arrival_date.Value.ToString("dd/MM/yyyy");
            this.init_station_id = Convert.ToInt32(init_station_combo_box.SelectedValue);
            this.destination_station_id = Convert.ToInt32(destination_station_combo_box.SelectedValue);
            travel_controller.SaveTravel(this.arrival, this.init_station_id, this.destination_station_id);
            _layout_form.changeLayout(new AddTravelSectionForm(_layout_form));
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this._layout_form.changeLayout(new AddTravelSectionForm(_layout_form));
        }

        private void actions_datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ShowConfirmationMessage(e);
            }
        }
        private void ShowConfirmationMessage(DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar la acción?", "Ventana de confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //to do
            }
        }
    }
}
