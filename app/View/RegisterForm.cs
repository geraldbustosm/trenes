using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class RegisterForm : Form
    {
        private LayoutForm _layoutForm;
        private bool is_password_validated;
        private Color successfullColor, wrongColor;
        public RegisterForm(LayoutForm layoutForm)
        {
            InitializeComponent();
            is_password_validated = false;
            this.information_label.Text = "";
            this.successfullColor = Color.FromArgb(21, 87, 36);
            this.wrongColor = information_label.ForeColor;
            _layoutForm = layoutForm;
            PermissionController.FillComboBox(combobox_rol);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = this.input_email.Text;
            string username = this.input_username.Text;
            string password = this.input_password.Text;
            int permission_id = Int32.Parse(this.combobox_rol.SelectedValue.ToString());

            if (this.is_password_validated)
            {
                if(UserController.CreateUser(username, email, password, permission_id))
                {
                    this.input_email.Text = "";
                    this.input_username.Text = "";
                    this.input_password.Text = "";
                    this.input_validate_password.Text = "";
                    this.information_label.Text = "Usuario creado con éxito";
                    this.information_label.ForeColor = successfullColor;
                }
                else
                {
                    if (information_label.ForeColor == successfullColor)
                        information_label.ForeColor = wrongColor;

                    this.information_label.Text = "Ingrese los datos correctamente";
                }
            } else
            {
                if(information_label.ForeColor == successfullColor)
                        information_label.ForeColor = wrongColor;

                this.information_label.Text = "Ingrese los datos correctamente";
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
                if (this.information_label.ForeColor == successfullColor)
                {
                    this.information_label.ForeColor = wrongColor;
                }
                this.information_label.Text = "Las contraseñas no coinciden";
                this.is_password_validated = false;
            }
        }
    }
}
