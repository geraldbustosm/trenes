using System;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace View
{
    public partial class LayoutForm : Form
    {
        private Form activeLayoutForm = null;
        private Form activeSideForm = null;
        
        public LayoutForm()
        {
            InitializeComponent();
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
            custumizeSideForm();
        }

        // Metodo que prepara/configura correctamente el panel de la izquierda (Menu)
        private void custumizeSideForm()
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
            if (activeLayoutForm != null)
                activeLayoutForm.Close();

            activeLayoutForm = newForm;
            custumizeLayoutForm();
        }

        // Metodo que prepara/configura correctamente el panel principal de la derecha
        private void custumizeLayoutForm()
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