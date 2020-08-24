﻿using System;
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
            init_station_combo_box.Text = "Origen";
            destination_station_combo_box.Text = "Destino";
            this.information_label.Text = "";
        }

        private void AddTravelSectionForm_Load(object sender, System.EventArgs e)
        {
            travel_controller.FeedInitStationComboBox(this.init_station_combo_box);
            ActionController.FeedActionsComboBox(this.actions_combo_box);
        }

        private bool AllComboBoxSelected()
        {
            this.GetFormValues();
            if (this.init_station_id != 0 || this.destination_station_id != 0 || this.action_description != "")
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
            this.init_station_id = Convert.ToInt32(init_station_combo_box.SelectedValue);
            string action_description = this.actions_combo_box.Text;
            if (init_station_id != 0 && action_description != "")
                travel_controller.FeedMachinesComboBox(action_description, this.init_station_id, this.machines_combo_box);
            else
                this.information_label.Text = "Debes completar todos los campos anteriores!";
        }


        private void add_action_btn_Click(object sender, EventArgs e)
        {
            // store actions for travel_section
            bool action_to_locomotive = this.actions_combo_box.Text.Contains("locomotora");
            if (action_to_locomotive)
                travel_controller.AddNewActionToSection(this.action_description, machines_combo_box.SelectedValue.ToString(), "locomotive");
            else
                travel_controller.AddNewActionToSection(this.action_description, machines_combo_box.SelectedValue.ToString(), "wagon");

            this.RefreshActions();
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

            // this metohd will be save in travel_section table on database
            bool success = travel_controller.AddNewSectionToTravel(
                this.arrival,  
                this.init_station_id,
                this.destination_station_id
            );

            //if(success)
                // setup form for next section
            //else
                // show error information
        }

    }
}
