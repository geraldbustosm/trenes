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
            form_Add_Tren.ShowDialog();
        }

        #endregion

        private void Form_Show_Trenes_Load(object sender, EventArgs e)
        {
            loadTrenes();
        }

        private void loadTrenes()
        {
            List<Tren> trenes = _businessLogicLayer.getTrenes();
            dataGrid_Trenes.DataSource = trenes;
            
        }
    }
}
