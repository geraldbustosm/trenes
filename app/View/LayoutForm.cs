using Model;
using System;
using System.Drawing;
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
        public User auth;
        
        public LayoutForm()
        {
            InitializeComponent();
            this.normalLayoutSize = this.Size;
            Show(new LoginForm(this));
        }

        // Metodo para mostrar un formulario
        public void Show(Form form)
        {
            changeLayout(form);
        }

        // Metodo que invoca la pantalla de bienvenida
        public void showWelcomeScreen()
        {
            changeSidePanel(new MenuForm(this));
            changeLayout(new InTransitTravelForm());
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
            if (!authenticate) resizeWindowToInitialSize();
            customizeLayoutForm();
        }

        // Método que redimensiona layoutForm a el tamaño inicial de las pestañas
        public void resizeWindowToInitialSize()
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