using System.Windows.Forms;
using Controller;
using System;

namespace View
{
    public partial class ListStationsForm : Form
    {
        public ListStationsForm()
        {
            InitializeComponent();
            StationController.FeedDataGridList(dataGridView);
            dataGridView.Columns[0].HeaderText = "Código";
            dataGridView.Columns[1].HeaderText = "Nombre";
            dataGridView.Columns[2].HeaderText = "Capacidad";
            StationController.AddDetailsLinkColumn(dataGridView);
            StationController.AddEditLinkColumn(dataGridView);
            StationController.AddDeleteLinkColumn(dataGridView);
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowConfirmationMessage(e);
        }

        private void ShowConfirmationMessage(DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar la estación?","Ventana de confirmación",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
                StationController.RemoveStationFromDGV(dataGridView, id, e.RowIndex);
            }
        }
    }
}
