using Controller;
using System;
using System.Windows.Forms;


namespace View
{
    public partial class ListUsersForm : Form
    {
        public ListUsersForm(LayoutForm layout_form)
        {
            InitializeComponent();
            UserController.fillDataGridView(dataGridView1);
            // if rol == 1
            UserController.AddEditLinkColumn(dataGridView1);
            UserController.AddDeleteLinkColumn(dataGridView1);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Reemplazar swtich por if(e.ColumIndex == 0 && this.user.rol == 1)
            switch (e.ColumnIndex)
            {
                case 0:
                    
                    // layout.changeLayout
                    break;
                case 1:
                    if (MessageBox.Show("¿Estás seguro que deseas eliminar el registro?", "Ventana de confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        UserController.RemoveUserFromDGV(dataGridView1, id, e.RowIndex);
                    }
                    break;
                default:
                    Console.WriteLine(e.ColumnIndex);
                    break;
            }
        }
    }
}
