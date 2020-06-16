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
    public partial class Form_Add_Tren : Form
    {

        private BusinessLogicLayer _businessLogicLayer;

        public Form_Add_Tren()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            saveTren();
        }

        private void saveTren()
        {
            Tren tren = new Tren();
            tren.codigo = textBox_codigo.Text;
            tren.capacidad = textBox_capacidad.Text;
            tren.tipo = textBox_tipo.Text;
            tren.origen = textBox_origen.Text;
            tren.destino = textBox_destino.Text;

            _businessLogicLayer.saveTren(tren);
        }

        private void textBox_capacidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
