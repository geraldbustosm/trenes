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
            this.stationController.FeedDataGridView(dataGridView);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
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
            this.name = this.inputName.Text;
            this.capacity = this.inputCapacity.Text;
            if (this.name != null && this.capacity != null)
            {
                if (StationController.IsNumber(this.capacity))
                {
                    stationController.Insert(this.name, this.capacity);
                    this.stationController.Clear();
                    Clear();
                    StationController.FeedComboBox(comboBox);

                }
            }
            else
            {
                MessageBox.Show("Error, Campo Vacío");
            }
        }
        private void AddLinkColumn()
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();

            link.UseColumnTextForLinkValue = true;
            link.Name = "Delete";
            link.Text = "Eliminar";

            dataGridView.Columns.Add(link);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView.Columns["Delete"].Index)
            {
                string res = ((DataGridView)(sender)).Rows[e.RowIndex].Cells[1].Value.ToString();
                this.stationController.DeleteBorderStation(res);
                this.stationController.FeedDataGridView(dataGridView);
            }
        }

        private void AddStationForm_Load(object sender, EventArgs e)
        {
            StationController.FeedComboBox(comboBox);
            this.stationController.FeedDataGridView(dataGridView);
            AddLinkColumn();
        }
    }
}
