using System;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class RegisterForm : Form
    {
        private LayoutForm _layoutForm;
        private bool is_password_validated;
        private bool is_email_validated;
        private bool is_username_validated;
        public RegisterForm(LayoutForm layoutForm)
        {
            InitializeComponent();
            is_password_validated = false;
            is_email_validated = false;
            is_username_validated = false;
            this.information_label.Text = "";

            _layoutForm = layoutForm;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = this.input_email.Text;
            string username = this.input_username.Text;
            string password = this.input_password.Text;
            string validate_password = this.input_validate_password.Text;

            if (this.is_password_validated)
            {
                if(UserController.CreateUser(username, email, password))
                {
                    _layoutForm.Show(new LoginForm(_layoutForm));
                }
                else
                {
                    this.information_label.Text = "Ha ocurrido un problema, contacte a el soporte!";
                }
            } else
            {
                this.information_label.Text = "Ingrese los datos correctamente!";
            }
        }

        private void input_validate_password_TextChanged(object sender, EventArgs e)
        {
            string password = this.input_password.Text;
            string validate_password = this.input_validate_password.Text;
            
            if(password == validate_password)
            {
                this.information_label.Text = "";
                this.is_password_validated = true;
            }
            else
            {
                this.information_label.Text = "Las contraseñas no coinciden!";
                this.is_password_validated = false;
            }
        }

        //todo: validate email (no debe existir y debe tener el formato correcto)
        //todo: validate username (no debe existir)
    }
}
