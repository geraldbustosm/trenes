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
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(394, 642);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(245, 78);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Registrarse";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.Location = new System.Drawing.Point(278, 190);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(150, 33);
            this.username_label.TabIndex = 7;
            this.username_label.Text = "Username";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_label.Location = new System.Drawing.Point(327, 269);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(89, 33);
            this.email_label.TabIndex = 8;
            this.email_label.Text = "Email";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(285, 356);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(143, 33);
            this.password_label.TabIndex = 9;
            this.password_label.Text = "Password";
            // 
            // repeat_password_label
            // 
            this.repeat_password_label.AutoSize = true;
            this.repeat_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeat_password_label.Location = new System.Drawing.Point(186, 441);
            this.repeat_password_label.Name = "repeat_password_label";
            this.repeat_password_label.Size = new System.Drawing.Size(242, 33);
            this.repeat_password_label.TabIndex = 10;
            this.repeat_password_label.Text = "Repetir password";
            // 
            // input_username
            // 
            this.input_username.Location = new System.Drawing.Point(500, 194);
            this.input_username.Name = "input_username";
            this.input_username.Size = new System.Drawing.Size(100, 31);
            this.input_username.TabIndex = 11;
            // 
            // input_email
            // 
            this.input_email.Location = new System.Drawing.Point(500, 273);
            this.input_email.Name = "input_email";
            this.input_email.Size = new System.Drawing.Size(100, 31);
            this.input_email.TabIndex = 12;
            // 
            // input_password
            // 
            this.input_password.Location = new System.Drawing.Point(500, 356);
            this.input_password.Name = "input_password";
            this.input_password.Size = new System.Drawing.Size(100, 31);
            this.input_password.TabIndex = 13;
            // 
            // input_validate_password
            // 
            this.input_validate_password.Location = new System.Drawing.Point(500, 441);
            this.input_validate_password.Name = "input_validate_password";
            this.input_validate_password.Size = new System.Drawing.Size(100, 31);
            this.input_validate_password.TabIndex = 14;
            this.input_validate_password.TextChanged += new System.EventHandler(this.input_validate_password_TextChanged);
            // 
            // information_label
            // 
            this.information_label.AutoSize = true;
            this.information_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.information_label.ForeColor = System.Drawing.Color.Red;
            this.information_label.Location = new System.Drawing.Point(411, 547);
            this.information_label.Name = "information_label";
            this.information_label.Size = new System.Drawing.Size(198, 29);
            this.information_label.TabIndex = 15;
            this.information_label.Text = "Information Label";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 894);
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
    }
}