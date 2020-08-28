using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddLocomotiveForm : Form
    {
        private string patent;
        private string drag_capacity;
        private LocomotiveController locomotive_controller;
        public AddLocomotiveForm()
        {
            this.locomotive_controller = new LocomotiveController();
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.patent = this.input_patent.Text;
            this.drag_capacity = this.input_drag_capacity.Text;
            if (this.patent != "" && this.drag_capacity != "")
            {
                if (LocomotiveController.IsNumberCapacity(this.drag_capacity))
                {
                    if (!this.locomotive_controller.RepeatedPatent(this.patent))
                    {
                        int station_id = Convert.ToInt32(station_combo_box.SelectedValue);
                        if (this.locomotive_controller.IsThereSpace(station_id))
                        {
                            this.label_error.ForeColor = Color.Transparent;
                            locomotive_controller.AddToLocomotiveList(station_id, this.patent, this.drag_capacity);
                            locomotive_controller.FeedLocomotiveDataGrid(locomotive_datagrid);
                            ClearAllTextBox();
                        }
                        else
                        {
                            Error("Estación sin Capacidad");
                        }
                    }
                    else
                    {
                        Error("Patente ya Ingresada");
                    }
                }
                else
                {
                    Error("Capacidad Campo Numérico");
                }
            }
            else
            {
                Error("Error, Campo Vacío");
            }
        }
        private void ClearAllTextBox()
        {
            this.input_patent.Text = "";
            this.input_drag_capacity.Text = "";
        }

        private void AddLocomotiveForm_Load(object sender, EventArgs e)
        {
            this.label_error.ForeColor = Color.Transparent;
            LocomotiveController.FeedComboBox(station_combo_box);
            this.locomotive_controller.FeedLocomotiveDataGrid(locomotive_datagrid);
            AddLinkColumnAndName();
        }
        private void AddLinkColumnAndName()
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();

            link.UseColumnTextForLinkValue = true;
            link.Name = "Eliminar";
            link.Text = "Eliminar";

            locomotive_datagrid.Columns.Add(link);
            locomotive_datagrid.Columns[0].HeaderText = "Código";
            locomotive_datagrid.Columns[1].HeaderText = "Patente";
            locomotive_datagrid.Columns[2].HeaderText = "Capacidad";
            locomotive_datagrid.Columns[3].HeaderText = "Activo";
            locomotive_datagrid.Columns[4].HeaderText = "Código tren";
            locomotive_datagrid.Columns[5].HeaderText = "Código estación";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.locomotive_controller.ClearLocomotiveList();
            this.locomotive_controller.FeedLocomotiveDataGrid(locomotive_datagrid);
            ClearAllTextBox();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.locomotive_controller.Insert())
            {
                this.locomotive_controller.ClearLocomotiveList();
                this.locomotive_controller.FeedLocomotiveDataGrid(locomotive_datagrid);
            }
        }
        private void locomotive_datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.locomotive_datagrid.Columns["Eliminar"].Index)
            {
                int id = Convert.ToInt32(((DataGridView)(sender)).Rows[e.RowIndex].Cells[1].Value.ToString());
                this.locomotive_controller.DeleteToLocomotiveList(id);
                this.locomotive_controller.FeedLocomotiveDataGrid(locomotive_datagrid);
            }
        }

        private void Error(string error)
        {
            this.label_error.ForeColor = Color.Red;
            this.label_error.Text = error;
        }

    }
}
