﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class LoginForm : Form
    {
        private LayoutForm _layout_form;
        private String username;
        private String password;
        public LoginForm(LayoutForm layout_form)
        {
            _layout_form = layout_form;
            InitializeComponent();
            this.errorLabel.Text = "";
        }

        // Metodo que se encarga del proceso de login y enviar al formulario de bienvenida
        private void btnLogin_Click(object sender, EventArgs e)
        {

            this.username = this.inputUser.Text;
            // todo hash password
            this.password = this.inputPassword.Text;

            // todo: validate data

            if(UserController.Authenticate(this.username, this.password))
            {
                _layout_form.resizeWindowsToNormalSize();
                _layout_form.showWelcomeScreen();
            } else
            {
                this.errorLabel.Text = "No se encontraron coincidencias.";
                this.errorLabel.ForeColor = Color.Red; 
            }
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _layout_form.Show(new RegisterForm(_layout_form));
        }
    }
}
