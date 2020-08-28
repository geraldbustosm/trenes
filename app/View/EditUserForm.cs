using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;
using Helper;
using Model;

namespace View
{
    public partial class EditUserForm : Form
    {
        private LayoutForm _layoutForm;
        private bool is_password_validated;
        private Color successfullColor, wrongColor;
        private int id;
        public EditUserForm(LayoutForm layoutForm, int id)
        {
            InitializeComponent();
            _layoutForm = layoutForm;
            is_password_validated = false;
            this.information_label.Text = "";
            this.successfullColor = Color.FromArgb(21, 87, 36);
            this.wrongColor = information_label.ForeColor;
            this.id = id;
            FeedFormWithUserValues();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = this.input_email.Text;
            string username = this.input_username.Text;
            string password = this.input_password.Text;
            int permission_id = Int32.Parse(this.combobox_rol.SelectedValue.ToString());

            if (this.is_password_validated)
            {
                if (Validation.IsEmail(email))
                {
                    if (UserController.EditUser(this.id, username, email, password, permission_id))
                    {
                        this.input_email.Text = "";
                        this.input_username.Text = "";
                        this.input_password.Text = "";
                        this.input_validate_password.Text = "";
                        this.information_label.Text = "Usuario editado con éxito";
                        this.information_label.ForeColor = successfullColor;
                    }
                    else
                    {
                        if (information_label.ForeColor == successfullColor)
                        {
                            information_label.ForeColor = wrongColor;
                        }

                        this.information_label.Text = "Usuario ya registrado";
                    }
                }
                else
                {
                    if (information_label.ForeColor == successfullColor)
                    {
                        information_label.ForeColor = wrongColor;
                    }
                    this.information_label.Text = "Ingrese un correo electrónico valido";
                }
            }
        }

        private void validate_password_TextChanged(object sender, EventArgs e)
        {
            string password = this.input_password.Text;
            string validate_password = this.input_validate_password.Text;

            if (password == validate_password)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this._layoutForm.changeLayout(new ListUsersForm(this._layoutForm));
        }

        private void FeedFormWithUserValues()
        {
            User user = User.Find(id);
            Permission permission = Permission.Find(user.permission_id);
            input_username.Text = user.name;
            input_email.Text = user.email;
            PermissionController.FeedComboBoxForEdit(combobox_rol, permission.permission_name);
        }
    }
}
