using System.Windows.Forms;
using Controller;
using System;

namespace View
{
    public partial class ListStationsForm : Form
    {
        private LayoutForm _layoutForm;
        public ListStationsForm(LayoutForm layoutForm)
        {
            InitializeComponent();
            _layoutForm = layoutForm;
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
            int id = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
            if (e.ColumnIndex == 0)
            {
                this._layoutForm.changeLayout(new DetailsStationForm(this._layoutForm, id));
            }else if (e.ColumnIndex ==2)
            {
                ShowConfirmationMessage(e,id);
            }
            else if (e.ColumnIndex == 1)
            {
                this._layoutForm.changeLayout(new EditSationForm(this._layoutForm, id));
            }
        }

        private void ShowConfirmationMessage(DataGridViewCellEventArgs e, int id)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar la estación?","Ventana de confirmación",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StationController.RemoveStationFromDGV(dataGridView, id, e.RowIndex);
            }
        }
    }
}
