using Controller;
using System;
using System.Windows.Forms;


namespace View
{
    public partial class ListUsersForm : Form
    {
        LayoutForm layout_form;
        public ListUsersForm(LayoutForm layout_form)
        {
            InitializeComponent();
            this.layout_form = layout_form;
            UserController.fillDataGridView(dataGridView1);
            AddActionsToDGV(this.layout_form.auth.permission_id);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && this.layout_form.auth.permission_id == 1) { 
                if (MessageBox.Show("¿Estás seguro que deseas eliminar el registro?", "Ventana de confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        UserController.RemoveUserFromDGV(dataGridView1, id, e.RowIndex);
                    }
            }
        }
        private void AddActionsToDGV(int rol)
        {
            if (rol == 1)
            {
                UserController.AddEditLinkColumn(dataGridView1);
                UserController.AddDeleteLinkColumn(dataGridView1);
            }
        }
    }
}
