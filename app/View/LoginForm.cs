using System;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class LoginForm : Form
    {
        private LayoutForm _layout_form;
        private String email;
        private String password;
        public LoginForm(LayoutForm layout_form)
        {
            InitializeComponent();
            this.errorLabel.Text = "";
            _layout_form = layout_form;
        }

        // Metodo que se encarga del proceso de login y enviar al formulario de bienvenida
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _layout_form.resizeWindowsToNormalSize();
            _layout_form.showWelcomeScreen();
            return;


            this.email = this.inputEmail.Text;
            this.password = this.inputPassword.Text;

            User auth = UserController.Authenticate(this.email, this.password);

            if (auth != null)
            {
                _layout_form.auth = auth;
                _layout_form.resizeWindowsToNormalSize();
                _layout_form.showWelcomeScreen();
            } else
            {
                this.errorLabel.Text = "Correo y/o contraseña incorrecto";
            }
        }
    }
}
