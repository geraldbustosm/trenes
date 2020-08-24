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
        private void Clear()
        {
            this.inputName.Text = "";
            this.inputCapacity.Text = "";
            this.ShowName.Text = "";
            this.stationController.FeedDataGridView(dataGridView);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            this.inputName.ReadOnly = false;
            this.inputCapacity.ReadOnly = false;
            this.comboBox.DataSource = null;
            this.comboBox.Items.Clear();
            this.stationController.Clear();
            this.stationController.FeedDataGridView(dataGridView);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.stationController.AddListBorderStation(comboBox);
            this.stationController.FeedDataGridView(dataGridView);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            stationController.Insert(this.name, this.capacity);
            this.inputName.ReadOnly = false;
            this.inputCapacity.ReadOnly = false;
            this.comboBox.DataSource = null;
            this.comboBox.Items.Clear();
            this.stationController.Clear();
            Clear();
        }
        private void AddLinkColumnDelete()
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();

            link.UseColumnTextForLinkValue = true;
            link.Name = "Delete";
            link.Text = "Eliminar";

            dataGridView.Columns.Add(link);
        }
        private void AddStationForm_Load(object sender, EventArgs e)
        {
            this.ShowName.ReadOnly = true;
            this.stationController.FeedDataGridView(dataGridView);
            dataGridView.Columns[0].HeaderText = "Codigo";
            dataGridView.Columns[1].HeaderText = "Nombre";
            dataGridView.Columns[2].HeaderText = "Capacidad";
            AddLinkColumnDelete();
        }

        private void btnAddBS_Click(object sender, EventArgs e)
        {
            this.name = this.inputName.Text;
            this.capacity = this.inputCapacity.Text;
            if (this.name != null && this.capacity != null)
            {
                if (StationController.IsNumberCapacity(this.capacity))
                {
                    this.inputName.ReadOnly = true;
                    this.inputCapacity.ReadOnly = true;
                    this.ShowName.Text = this.name;
                    StationController.FeedComboBox(comboBox);
                }
            }
            else
            {
                MessageBox.Show("Error, Campo Vacío");
            }
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView.Columns["Delete"].Index)
            {
                string res = ((DataGridView)(sender)).Rows[e.RowIndex].Cells[1].Value.ToString();
                this.stationController.DeleteBorderStation(res);
                this.stationController.FeedDataGridView(dataGridView);
            }
        }
    }
}
