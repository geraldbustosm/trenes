using System;
using System.Windows.Forms;

namespace View
{
    public partial class LayoutForm : Form
    {
        private Form activeForm = null;
        private Panel activeSubMenu = null;
        
        public LayoutForm()
        {
            InitializeComponent();
            hideAllSubMenu();
            changeForm(new HomeForm());
        }

        private void hideAllSubMenu()
        {
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void toggleSubMenu(Panel subMenu)
        {
            if (activeSubMenu == subMenu)
            {
                activeSubMenu.Visible = false;
                activeSubMenu = null;
            }
            else if(activeSubMenu == null)
            {
                activeSubMenu = subMenu;
                activeSubMenu.Visible = true;
            } else
            {
                activeSubMenu.Visible = false;
                activeSubMenu = subMenu;
                activeSubMenu.Visible = true;
            }
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

        private void changeForm(Form newForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = newForm;
            custumizeForm();
        }

        private void custumizeForm()
        {
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panelLayout.Controls.Add(activeForm);
            panelLayout.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            changeForm(new HomeForm());
        }

        private void btnShowWagons_Click(object sender, EventArgs e)
        {
            changeForm(new ShowWagonsForm());
        }
    }
}