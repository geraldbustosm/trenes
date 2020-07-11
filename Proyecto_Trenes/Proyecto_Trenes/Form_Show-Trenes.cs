using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Trenes
{
    public partial class Form_Show_Trenes : Form
    {

        private BusinessLogicLayer _businessLogicLayer;

        public Form_Show_Trenes()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        #region EVENTS

        private void button_add_Click(object sender, EventArgs e)
        {
            openFormAddTren();
        }

        #endregion

        #region PRIVATE METHODS

        private void openFormAddTren() {
            Form_Add_Tren form_Add_Tren = new Form_Add_Tren();
            form_Add_Tren.ShowDialog(this);
        }

        #endregion

        private void Form_Show_Trenes_Load(object sender, EventArgs e)
        {
            loadTrenes();
        }

        public void loadTrenes()
        {
            List<Tren> trenes = _businessLogicLayer.getTrenes();
            dataGrid_Trenes.DataSource = trenes;
            
        }

        private void dataGrid_Trenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGrid_Trenes.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value.ToString() == "Edit") {
                Form_Add_Tren trenDetails = new Form_Add_Tren();
                trenDetails.loadTren(new Tren
                {
                    Id = int.Parse(dataGrid_Trenes.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    capacidad = dataGrid_Trenes.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    codigo = dataGrid_Trenes.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    tipo = dataGrid_Trenes.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    origen = dataGrid_Trenes.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    destino = dataGrid_Trenes.Rows[e.RowIndex].Cells[5].Value.ToString()
                });
                trenDetails.ShowDialog(this);
            }
            else if(cell.Value.ToString() == "Delete")
            {
                deleteTren(int.Parse(dataGrid_Trenes.Rows[e.RowIndex].Cells[0].Value.ToString()));
                loadTrenes();
            }
        }

        private void deleteTren(int id)
        {
            _businessLogicLayer.deleteTren(id);
        }
    }
}
