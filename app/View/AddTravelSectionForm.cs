using System;
using System.Drawing;
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
        private DateTime init_time;
        private DateTime arrival_time;

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
            if (CompareDateAndHour())
            {
                try
                {
                    this.information_label.ForeColor = Color.Transparent;
                    int action_id = Int32.Parse(this.actions_combo_box.SelectedValue.ToString());
                    bool action_to_locomotive = this.actions_combo_box.Text.Contains("locomotora");
                    int station_id = Convert.ToInt32(init_station_combo_box.SelectedValue);

                    if (action_to_locomotive)
                        travel_controller.AddNewActionToSection(action_id, station_id, machines_combo_box.SelectedValue.ToString(), "locomotive");
                    else
                        travel_controller.AddNewActionToSection(action_id, station_id, machines_combo_box.SelectedValue.ToString(), "wagon");

                    this.BlockForm();
                    this.RefreshActions();
                    this.RefreshTrainState();
                    machines_combo_box.DataSource = null;
                    travel_controller.FeedMachinesComboBox(actions_combo_box.SelectedIndex, station_id, machines_combo_box);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Error("Campo Fecha mal ingresado");
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
            SetTime();
            this.SetupTime();
            this.init_station_id = Convert.ToInt32(init_station_combo_box.SelectedValue);
            this.destination_station_id = Convert.ToInt32(destination_station_combo_box.SelectedValue);

            try
            {
                bool success = travel_controller.AddNewSectionToTravel(
                    this.init_time,
                    this.arrival_time,
                    this.init_station_id,
                    this.destination_station_id
                );

                if (success)
                    SetupNextSection();
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
            this.SetupTime();
            this.init_station_id = Convert.ToInt32(init_station_combo_box.SelectedValue);
            this.destination_station_id = Convert.ToInt32(destination_station_combo_box.SelectedValue);
            travel_controller.SaveTravel(this.init_time, this.arrival_time, this.init_station_id, this.destination_station_id);
            _layout_form.changeLayout(new AddTravelSectionForm(_layout_form));
        }

        private void SetupTime()
        {
            this.init_time = new DateTime(
                this.init_date.Value.Year,
                this.init_date.Value.Month,
                this.init_date.Value.Day,
                this.init_hour.Value.Hour,
                this.init_hour.Value.Minute,
                0
            );
            this.arrival_time = new DateTime(
                this.arrival_date.Value.Year,
                this.arrival_date.Value.Month,
                this.arrival_date.Value.Day,
                this.arrival_hour.Value.Hour,
                this.arrival_hour.Value.Minute,
                0
            );
        }

        private void SetupNextSection()
        {
            try
            {
                this.init_station_combo_box.Text = destination_station_combo_box.Text;
                this.destination_station_combo_box.Enabled = true;
                this.init_date.Value = this.arrival_date.Value;
                this.arrival_date.Enabled = true;
                this.init_hour.Value = this.arrival_hour.Value;
                this.arrival_hour.Enabled = true;
                travel_controller.FeedActionsDataGrid(this.actions_datagrid);
                int id = Int32.Parse(this.destination_station_combo_box.SelectedValue.ToString());
                travel_controller.FeedDestinationStationComboBox(id, this.destination_station_combo_box);
                travel_controller.FeedMachinesComboBox(this.actions_combo_box.SelectedIndex, id, this.machines_combo_box);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetTime()
        {
            int total_time_action = this.travel_controller.AllTimeForAction();
            TimeSpan min = TimeSpan.FromMinutes(total_time_action);
            this.arrival_hour.Value = this.arrival_hour.Value.Add(min);
        }

        private bool CompareDateAndHour()
        {
            int result_date = DateTime.Compare(this.init_date.Value,this.arrival_date.Value);
            TimeSpan result = this.init_hour.Value.Subtract(this.arrival_hour.Value);

            if (result_date <= 1 && result.Hours <= 0 && result.Minutes < 0 && result.Seconds < 0) return true;
            return false;
        }

        private void BlockForm()
        {
            this.init_station_combo_box.Enabled = false;
            this.destination_station_combo_box.Enabled = false;
            this.init_date.Enabled = false;
            this.init_hour.Enabled = false;
            this.arrival_date.Enabled = false;
            this.arrival_hour.Enabled = false;
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

        private void Error(string error)
        {
            this.information_label.ForeColor = Color.Red;
            this.information_label.Text = error;
        }

    }
}
