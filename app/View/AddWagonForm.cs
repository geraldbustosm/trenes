using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddWagonForm : Form
    {
        private string shipload_type;
        private string shipload_weight;
        private string wagon_weight;
        private WagonController wagonController;
        public AddWagonForm()
        {
            this.wagonController = new WagonController();
            InitializeComponent();
        }

        private void AddWagonForm_Load(object sender, System.EventArgs e)
        {
            WagonController.FeedComboBox(comboBox);
            AddLinkColumn();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            this.shipload_weight = this.inputShipload_w.Text;
            this.shipload_type = this.input_Shipload_type.Text;
            this.wagon_weight = this.inputWagon_w.Text;
            if (this.shipload_weight != null && this.shipload_type != null && this.wagon_weight != null)
            {
                if (WagonController.IsNumber(this.shipload_weight))
                {
                    if (WagonController.IsNumber(this.wagon_weight))
                    {
                        this.wagonController.AddListWagon(this.shipload_weight, this.wagon_weight, this.shipload_type, comboBox);
                        this.wagonController.FeedDataGrid(dataGridView);
                        Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error, Campo Vacío");
            }
        }
        private void Clear()
        {
            this.inputShipload_w.Text = "";
            this.inputWagon_w.Text = "";
            this.input_Shipload_type.Text = "";
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.wagonController.Clear();
            this.wagonController.FeedDataGrid(dataGridView);
            Clear();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (this.wagonController.Insert())
            {
                this.wagonController.Clear();
                this.wagonController.FeedDataGrid(dataGridView);
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
                this.wagonController.DeleteWagon(res);
                this.wagonController.FeedDataGrid(dataGridView);
            }
        }
    }
}
