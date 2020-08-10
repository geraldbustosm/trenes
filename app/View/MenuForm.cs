using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    public partial class MenuForm : Form
    {
        Panel activeSubMenu = null;
        Button activeButton = null;
        private LayoutForm _layoutForm;
        private Color navButtonColor;
        private Color highLightButtonColor;
        public MenuForm(LayoutForm layoutForm)
        {
            _layoutForm = layoutForm;
            InitializeComponent();
            hideAllSubMenu();
            navButtonColor = Color.FromArgb(50, 70, 211);
            highLightButtonColor = Color.FromArgb(29, 45, 163);
        }

        // Metodo que esconde todos los paneles de sub menu
        private void hideAllSubMenu()
        {
            activeSubMenu = null;
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
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

        private void btn_admin_viajes_Click(object sender, EventArgs e)
        {
            toggleSubMenu(panelSubMenu1);
        }

        private void btn_conf_estaciones_Click(object sender, EventArgs e)
        {
            toggleSubMenu(panelSubMenu2);
        }
        private void btn_admin_usuarios_Click(object sender, EventArgs e)
        {
            toggleSubMenu(panelSubMenu3);
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            hideAllSubMenu();
            _layoutForm.changeLayout(new HomeForm());
        }

        private void btn_viajes_en_transito_Click(object sender, EventArgs e)
        {
            highLightButton(btn_viajes_en_transito);
            _layoutForm.changeLayout(new InTransitTravelForm());
        }

        private void btn_nueva_estacion_Click(object sender, EventArgs e)
        {
            highLightButton(btn_nueva_estacion);
            _layoutForm.changeLayout(new AddStationForm());
        }

        private void btn_nueva_locomotora_Click(object sender, EventArgs e)
        {
            highLightButton(btn_nueva_locomotora);
            _layoutForm.changeLayout(new AddLocomotiveForm());
        }

        private void btn_nuevo_carro_Click(object sender, EventArgs e)
        {
            highLightButton(btn_nuevo_carro);
            _layoutForm.changeLayout(new AddWagonForm());
        }

        private void btn_viajes_pendientes_Click(object sender, EventArgs e)
        {
            highLightButton(btn_viajes_pendientes);
            _layoutForm.changeLayout(new ScheduledTravelForm());
        }

        private void btn_nuevo_viaje_Click(object sender, EventArgs e)
        {
            highLightButton(btn_nuevo_viaje);
        }

        private void btn_nuevo_usuario_Click(object sender, EventArgs e)
        {
            highLightButton(btn_nuevo_usuario);
            _layoutForm.changeLayout(new RegisterForm(_layoutForm));
        }

        private void btn_ver_estaciones_Click(object sender, EventArgs e)
        {
            highLightButton(btn_ver_estaciones);
            _layoutForm.changeLayout(new ListStationsForm());
        }

        private void btn_ver_usuarios_Click(object sender, EventArgs e)
        {
            highLightButton(btn_ver_usuarios);
            _layoutForm.changeLayout(new ListUsersForm());
        }
        private void highLightButton(Button button)
        {

            if (activeButton != null)
            {
                activeButton.BackColor = navButtonColor;
            }

            activeButton = button;
            activeButton.BackColor = highLightButtonColor;
            activeButton.FlatAppearance.BorderColor = highLightButtonColor;

        }
    }
}
