namespace View
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegister = new System.Windows.Forms.Button();
            this.username_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.repeat_password_label = new System.Windows.Forms.Label();
            this.input_username = new System.Windows.Forms.TextBox();
            this.input_email = new System.Windows.Forms.TextBox();
            this.input_password = new System.Windows.Forms.TextBox();
            this.input_validate_password = new System.Windows.Forms.TextBox();
            this.information_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combobox_rol = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(822, 635);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(164, 50);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Registrar";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // username_label
            // 
            this.username_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.username_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.username_label.Location = new System.Drawing.Point(95, 71);
            this.username_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(84, 24);
            this.username_label.TabIndex = 7;
            this.username_label.Text = "Nombre ";
            // 
            // email_label
            // 
            this.email_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.email_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.email_label.Location = new System.Drawing.Point(95, 108);
            this.email_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(166, 24);
            this.email_label.TabIndex = 8;
            this.email_label.Text = "Correo electrónico";
            // 
            // password_label
            // 
            this.password_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.password_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.password_label.Location = new System.Drawing.Point(95, 184);
            this.password_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(106, 24);
            this.password_label.TabIndex = 9;
            this.password_label.Text = "Contraseña";
            // 
            // repeat_password_label
            // 
            this.repeat_password_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeat_password_label.AutoSize = true;
            this.repeat_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.repeat_password_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.repeat_password_label.Location = new System.Drawing.Point(95, 221);
            this.repeat_password_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.repeat_password_label.Name = "repeat_password_label";
            this.repeat_password_label.Size = new System.Drawing.Size(189, 24);
            this.repeat_password_label.TabIndex = 10;
            this.repeat_password_label.Text = "Confirmar contraseña";
            // 
            // input_username
            // 
            this.input_username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_username.Location = new System.Drawing.Point(740, 71);
            this.input_username.Margin = new System.Windows.Forms.Padding(2);
            this.input_username.Name = "input_username";
            this.input_username.Size = new System.Drawing.Size(246, 22);
            this.input_username.TabIndex = 11;
            // 
            // input_email
            // 
            this.input_email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_email.Location = new System.Drawing.Point(740, 108);
            this.input_email.Margin = new System.Windows.Forms.Padding(2);
            this.input_email.Name = "input_email";
            this.input_email.Size = new System.Drawing.Size(246, 22);
            this.input_email.TabIndex = 12;
            // 
            // input_password
            // 
            this.input_password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_password.Location = new System.Drawing.Point(740, 184);
            this.input_password.Margin = new System.Windows.Forms.Padding(2);
            this.input_password.Name = "input_password";
            this.input_password.PasswordChar = '*';
            this.input_password.Size = new System.Drawing.Size(246, 22);
            this.input_password.TabIndex = 13;
            this.input_password.TextChanged += new System.EventHandler(this.validate_password_TextChanged);
            // 
            // input_validate_password
            // 
            this.input_validate_password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_validate_password.Location = new System.Drawing.Point(740, 221);
            this.input_validate_password.Margin = new System.Windows.Forms.Padding(2);
            this.input_validate_password.Name = "input_validate_password";
            this.input_validate_password.PasswordChar = '*';
            this.input_validate_password.Size = new System.Drawing.Size(246, 22);
            this.input_validate_password.TabIndex = 14;
            this.input_validate_password.TextChanged += new System.EventHandler(this.validate_password_TextChanged);
            // 
            // information_label
            // 
            this.information_label.AutoSize = true;
            this.information_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.information_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.information_label.Location = new System.Drawing.Point(737, 266);
            this.information_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.information_label.Name = "information_label";
            this.information_label.Size = new System.Drawing.Size(121, 18);
            this.information_label.TabIndex = 15;
            this.information_label.Text = "Information Label";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(95, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Seleccione rol ";
            // 
            // combobox_rol
            // 
            this.combobox_rol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combobox_rol.BackColor = System.Drawing.Color.White;
            this.combobox_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_rol.FormattingEnabled = true;
            this.combobox_rol.Location = new System.Drawing.Point(740, 147);
            this.combobox_rol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combobox_rol.Name = "combobox_rol";
            this.combobox_rol.Size = new System.Drawing.Size(246, 24);
            this.combobox_rol.TabIndex = 21;
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1073, 721);
            this.Controls.Add(this.combobox_rol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.information_label);
            this.Controls.Add(this.input_validate_password);
            this.Controls.Add(this.input_password);
            this.Controls.Add(this.input_email);
            this.Controls.Add(this.input_username);
            this.Controls.Add(this.repeat_password_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.btnRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label repeat_password_label;
        private System.Windows.Forms.TextBox input_username;
        private System.Windows.Forms.TextBox input_email;
        private System.Windows.Forms.TextBox input_password;
        private System.Windows.Forms.TextBox input_validate_password;
        private System.Windows.Forms.Label information_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combobox_rol;
    }
}