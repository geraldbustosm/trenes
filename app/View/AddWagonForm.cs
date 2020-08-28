using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddWagonForm : Form
    {
        private string shipload_type;
        private string shipload_weight;
        private string wagon_weight;
        private string patent;
        private WagonController wagon_controller;
        public AddWagonForm()
        {
            this.wagon_controller = new WagonController();
            InitializeComponent();
        }

        private void AddWagonForm_Load(object sender, System.EventArgs e)
        {
            this.label_error.ForeColor = Color.Transparent;
            WagonController.FeedComboBox(station_combo_box);
            this.wagon_controller.FeedDataGrid(station_datagrid);
            AddLinkColumnAndName();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            this.patent = this.input_patent.Text;
            this.shipload_weight = this.input_shipload_w.Text;
            this.shipload_type = this.input_shipload_type.Text;
            this.wagon_weight = this.input_wagon_w.Text;
            if (this.shipload_weight != "" && this.shipload_type != "" && this.wagon_weight != "")
            {
                if (WagonController.IsNumber(this.shipload_weight))
                {
                    if (WagonController.IsNumber(this.wagon_weight))
                    {
                        if (!this.wagon_controller.RepeatedPatent(this.patent))
                        {
                            int station_id = Convert.ToInt32(station_combo_box.SelectedValue);
                            if (this.wagon_controller.IsThereSpace(station_id))
                            {
                                this.label_error.ForeColor = Color.Transparent;
                                this.wagon_controller.AddListWagon(this.patent, this.shipload_weight, this.wagon_weight, this.shipload_type, station_id);
                                this.wagon_controller.FeedDataGrid(station_datagrid);
                                ClearAllBoxText();
                            }
                            else
                            {
                                Error("Estación sin Capacidad");
                            }
                        }
                        else
                        {
                            Error("Patente Ingresada.");
                        }
                    }
                    else
                    {
                        Error("Campo Peso Tipo Numérico.");
                    }
                }
                else
                {
                    Error("Campo Peso Numerico.");
                }
            }
            else
            {
                Error("Error, Campo Vacío.");
            }
        }
        private void ClearAllBoxText()
        {
            this.input_shipload_w.Text = "";
            this.input_wagon_w.Text = "";
            this.input_shipload_type.Text = "";
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.wagon_controller.ClearListWagon();
            this.wagon_controller.FeedDataGrid(station_datagrid);
            ClearAllBoxText();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (this.wagon_controller.Insert())
            {
                this.wagon_controller.ClearListWagon();
                this.wagon_controller.FeedDataGrid(station_datagrid);
            }
        }
        private void AddLinkColumnAndName()
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();

            link.UseColumnTextForLinkValue = true;
            link.Name = "Eliminar";
            link.Text = "Eliminar";

            station_datagrid.Columns.Add(link);
            station_datagrid.Columns[0].HeaderText = "Código";
            station_datagrid.Columns[1].HeaderText = "Patente";
            station_datagrid.Columns[2].HeaderText = "Tipo carga";
            station_datagrid.Columns[3].HeaderText = "Peso carga";
            station_datagrid.Columns[4].HeaderText = "Peso carro";
            station_datagrid.Columns[5].HeaderText = "Activo";
            station_datagrid.Columns[6].HeaderText = "Código tren";
            station_datagrid.Columns[7].HeaderText = "Código estación";
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.station_datagrid.Columns["Eliminar"].Index)
            {
                int id = Convert.ToInt32(((DataGridView)(sender)).Rows[e.RowIndex].Cells[1].Value.ToString());
                this.wagon_controller.DeleteToWagonList(id);
                this.wagon_controller.FeedDataGrid(station_datagrid);
            }
        }

        private void Error(string error)
        {
            this.label_error.ForeColor = Color.Red;
            this.label_error.Text = error;
        }

    }
}
