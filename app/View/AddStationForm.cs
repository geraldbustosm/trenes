using System;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddStationForm : Form
    {
        private string name;
        private string capacity;
        private StationController stationController;
        public AddStationForm()
        {
            this.stationController = new StationController();
            InitializeComponent();
        }

        private void ClearTextBox()
        {
            this.input_name.Text = "";
            this.input_capacity.Text = "";
            this.show_same.Text = "";
            this.stationController.FeedDataBorderStation(data_border_station);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.input_name.ReadOnly = false;
            this.input_capacity.ReadOnly = false;
            this.combo_box_station.DataSource = null;
            this.combo_box_station.Items.Clear();
            this.stationController.ClearList();
            ClearTextBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.stationController.AddToBorderStationList(combo_box_station);
            this.stationController.FeedDataBorderStation(data_border_station);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            stationController.Insert(this.name, this.capacity);
            this.input_name.ReadOnly = false;
            this.input_capacity.ReadOnly = false;
            this.combo_box_station.DataSource = null;
            this.combo_box_station.Items.Clear();
            this.stationController.ClearList();
            ClearTextBox();
        }

        private void AddLinkColumnDelete()
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();

            link.UseColumnTextForLinkValue = true;
            link.Name = "Delete";
            link.Text = "Eliminar";

            data_border_station.Columns.Add(link);
        }

        private void AddStationForm_Load(object sender, EventArgs e)
        {
            this.show_same.ReadOnly = true;
            this.stationController.FeedDataBorderStation(data_border_station);
            data_border_station.Columns[0].HeaderText = "Codigo";
            data_border_station.Columns[1].HeaderText = "Nombre";
            data_border_station.Columns[2].HeaderText = "Capacidad";
            AddLinkColumnDelete();
        }

        private void btnAddBS_Click(object sender, EventArgs e)
        {
            this.name = this.input_name.Text;
            this.capacity = this.input_capacity.Text;
            if (this.name != null && this.capacity != null)
            {
                if (StationController.IsNumberCapacity(this.capacity))
                {
                    this.input_name.ReadOnly = true;
                    this.input_capacity.ReadOnly = true;
                    this.show_same.Text = this.name;
                    StationController.FeedComboBox(combo_box_station);
                }
            }
            else
            {
                MessageBox.Show("Error, Campo Vacío");
            }
        }
        private void data_border_station_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.data_border_station.Columns["Delete"].Index)
            {
                string res = ((DataGridView)(sender)).Rows[e.RowIndex].Cells[1].Value.ToString();
                this.stationController.DeleteBorderStation(res);
                this.stationController.FeedDataBorderStation(data_border_station);
            }
        }

    }
}
