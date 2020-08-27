using System;
using System.Drawing;
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
            this.combo_box_station.Enabled = false;
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
            data_border_station.Columns[0].HeaderText = "Codigo";
            data_border_station.Columns[1].HeaderText = "Nombre";
            data_border_station.Columns[2].HeaderText = "Capacidad";
        }

        private void AddStationForm_Load(object sender, EventArgs e)
        {
            this.label_error.ForeColor = Color.Transparent;
            this.show_same.ReadOnly = true;
            this.combo_box_station.Enabled = false;
            this.stationController.FeedDataBorderStation(data_border_station);
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
                    if (!this.stationController.RepeatedPatent(this.name))
                    {
                        this.label_error.ForeColor = Color.Transparent;
                        this.input_name.ReadOnly = true;
                        this.input_capacity.ReadOnly = true;
                        this.show_same.Text = this.name;
                        this.combo_box_station.Enabled = true;
                        StationController.FeedComboBox(combo_box_station);
                    }
                    else
                    {
                        Error("Nombre ya Ingresado");
                    }
                }
                else
                {
                    Error("Capacidad Campo Numérico");
                }
            }
            else
            {
                Error("Error, Campo Vacío");
            }
        }
        private void data_border_station_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.data_border_station.Columns["Delete"].Index)
            {
                int id = Convert.ToInt32(((DataGridView)(sender)).Rows[e.RowIndex].Cells[1].Value.ToString());
                this.stationController.DeleteBorderStation(id);
                this.stationController.FeedDataBorderStation(data_border_station);
            }
        }

        private void Error(string error)
        {
            this.label_error.ForeColor = Color.Red;
            this.label_error.Text = error;
        }

    }
}
