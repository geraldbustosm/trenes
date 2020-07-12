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
    public partial class LayoutForm : Form
    {
        
        public LayoutForm()
        {
            InitializeComponent();
            hideAllSubMenu();
        }

        private void hideAllSubMenu()
        {
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void toggleSubMenu(Panel subMenu)
        {
            subMenu.Visible = (!subMenu.Visible) ? true : false;
        }

        private void btnMenu1_Click(object sender, EventArgs e)
        {
            toggleSubMenu(panelSubMenu1);
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            toggleSubMenu(panelSubMenu2);
        }

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            toggleSubMenu(panelSubMenu3);
        }
    }
}