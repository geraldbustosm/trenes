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
        private Tren _tren;

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
            this.Close();
            ((Form_Show_Trenes)this.Owner).loadTrenes();
        }

        private void saveTren()
        {
            Tren tren = new Tren();
            tren.codigo = textBox_codigo.Text;
            tren.capacidad = textBox_capacidad.Text;
            tren.tipo = textBox_tipo.Text;
            tren.origen = textBox_origen.Text;
            tren.destino = textBox_destino.Text;

            tren.Id = _tren != null ? _tren.Id : 0;

            _businessLogicLayer.saveTren(tren);
        }

        public void loadTren(Tren tren) {
            _tren = tren;
            if (tren != null) {

                clearForm();

                textBox_codigo.Text = tren.codigo;
                textBox_capacidad.Text = tren.capacidad;
                textBox_tipo.Text = tren.tipo;
                textBox_origen.Text = tren.origen;
                textBox_destino.Text = tren.destino;
            }
        }

        private void clearForm() {
            textBox_codigo.Text = string.Empty;
            textBox_capacidad.Text = string.Empty;
            textBox_tipo.Text = string.Empty;
            textBox_origen.Text = string.Empty;
            textBox_destino.Text = string.Empty;
        }

        private void textBox_capacidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
