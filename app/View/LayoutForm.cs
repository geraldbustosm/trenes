using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace View
{
    public partial class LayoutForm : Form
    {
        private Form activeLayoutForm = null;
        private Form activeSideForm = null;
        private Boolean authenticate = false;
        private int loginFormWidth = 550;
        private Size normalLayoutSize;
        
        public LayoutForm()
        {
            InitializeComponent();
            this.normalLayoutSize = this.Size;
            showLoginScreen();
        }

        // Metodo que invoca la pantalla de login
        private void showLoginScreen()
        {
            changeLayout(new LoginForm(this));
        }

        // Metodo que invoca la pantalla de bienvenida
        public void showWelcomeScreen()
        {
            changeSidePanel(new MenuForm(this));
            changeLayout(new HomeForm());
        }

        // Metodo que cambia el panel de la izquierda (Menu)
        public void changeSidePanel(Form newForm)
        {
            if (activeSideForm != null)
                activeSideForm.Close();

            activeSideForm = newForm;
            customizeSideForm();
        }

        // Metodo que prepara/configura correctamente el panel de la izquierda (Menu)
        private void customizeSideForm()
        {
            activeSideForm.TopLevel = false;
            activeSideForm.FormBorderStyle = FormBorderStyle.None;
            activeSideForm.Dock = DockStyle.Fill;
            panelSide.Controls.Add(activeSideForm);
            panelSide.Tag = activeSideForm;
            activeSideForm.BringToFront();
            activeSideForm.Show();
        }

        // Metodo que cambia el panel principal de la derecha
        public void changeLayout(Form newForm)
        {
            if (activeLayoutForm != null) activeLayoutForm.Close();
            
            activeLayoutForm = newForm;

            if (!authenticate) resizeWindowToLoginSize();

            customizeLayoutForm();
        }
        // Método que redimensiona layoutForm unicamente en la ventana de login
        public void resizeWindowToLoginSize()
        {
            panelSide.Visible = false;
            this.Width = loginFormWidth;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        // Método que redimensiona layoutForm a su tamaño normal despúes del login
        public void resizeWindowsToNormalSize()
        {
            authenticate = true;
            panelSide.Visible = true;
            this.MaximizeBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Size = normalLayoutSize;
            this.CenterToScreen();
        }

        // Metodo que prepara/configura correctamente el panel principal de la derecha
        private void customizeLayoutForm()
        {
            activeLayoutForm.TopLevel = false;
            activeLayoutForm.FormBorderStyle = FormBorderStyle.None;
            activeLayoutForm.Dock = DockStyle.Fill;
            panelLayout.Controls.Add(activeLayoutForm);
            panelLayout.Tag = activeLayoutForm;
            activeLayoutForm.BringToFront();
            activeLayoutForm.Show();
        }
    }
}