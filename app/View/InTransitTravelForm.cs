using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class InTransitTravelForm : Form
    {
        public InTransitTravelForm()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("1","E1","E8","14:20","15:30");
            dataGridView1.Rows.Add("2", "E5", "E9", "16:30", "18:30");
            dataGridView1.Rows.Add("3", "E8", "E2", "14:20", "15:30");
            dataGridView1.Rows.Add("4", "E4", "E10", "09:20", "11:30");
        }
    }
}
