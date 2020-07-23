using System;
using System.Windows.Forms;

namespace View
{
    public partial class MenuForm : Form
    {
        Panel activeSubMenu = null;
        private LayoutForm _layoutForm;
        public MenuForm(LayoutForm layoutForm)
        {
            _layoutForm = layoutForm;
            InitializeComponent();
            hideAllSubMenu();
        }

        // Metodo que esconde todos los paneles de sub menu
        private void hideAllSubMenu()
        {
            activeSubMenu = null;
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
        }

        // Metodo que abre un nuevo panel y cierra los demas
        private void toggleSubMenu(Panel subMenu)
        {
            if (activeSubMenu == subMenu)
            {
                activeSubMenu.Visible = false;
                activeSubMenu = null;
            }
            else if (activeSubMenu == null)
            {
                activeSubMenu = subMenu;
                activeSubMenu.Visible = true;
            }
            else
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
            hideAllSubMenu();
            _layoutForm.changeLayout(new HomeForm());
        }

        private void btnShowWagons_Click(object sender, EventArgs e)
        {
            _layoutForm.changeLayout(new ShowWagonsForm());
        }
    }
}
