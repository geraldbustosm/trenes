﻿using System;
using System.Drawing;
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

            this.email = this.inputEmail.Text;
            this.password = this.inputPassword.Text;

            User auth = UserController.Authenticate(this.email, this.password);

            if (auth != null)
            {
                _layout_form.resizeWindowsToNormalSize();
                _layout_form.showWelcomeScreen();
                _layout_form.auth = auth;
            } else
            {
                this.errorLabel.Text = "Correo y/o contraseña incorrecto";
            }
        }
    }
}
