using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class AddLocomotiveForm : Form
    {
        private string model;
        private string drag_capacity;
        private LocomotiveController locomotiveController;
        public AddLocomotiveForm()
        {
            this.locomotiveController = new LocomotiveController();
            InitializeComponent();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            this.model = this.inputModel.Text;
            this.drag_capacity = this.inputDrag_capacity.Text;
            if (this.model != null && this.drag_capacity != null)
            {
                if (LocomotiveController.IsNumberCapacity(this.drag_capacity))
                {
                    locomotiveController.AddLocomotive(comboBox, this.model, this.drag_capacity);
                    locomotiveController.FeedDataGrid(dataGridView);
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Error, Campo Vacío");
            }
        }
        private void Clear()
        {
            this.inputModel.Text = "";
            this.inputDrag_capacity.Text = "";
        }

        private void AddLocomotiveForm_Load(object sender, EventArgs e)
        {
            LocomotiveController.FeedComboBox(comboBox);
            AddLinkColumn();
        }
        private void AddLinkColumn()
        {
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();

            link.UseColumnTextForLinkValue = true;
            link.Name = "Delete";
            link.Text = "Eliminar";

            dataGridView.Columns.Add(link);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.locomotiveController.Clear();
            this.locomotiveController.FeedDataGrid(dataGridView);
            Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.locomotiveController.Insert())
            {
                this.locomotiveController.Clear();
                this.locomotiveController.FeedDataGrid(dataGridView);
            }
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView.Columns["Delete"].Index)
            {
                string res = ((DataGridView)(sender)).Rows[e.RowIndex].Cells[1].Value.ToString();
                this.locomotiveController.DeleteLocomotive(res);
                this.locomotiveController.FeedDataGrid(dataGridView);
            }
        }
    }
}
