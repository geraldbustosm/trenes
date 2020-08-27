namespace View
{
    partial class EditSationForm
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.username_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.input_stationname = new System.Windows.Forms.TextBox();
            this.input_capacidad = new System.Windows.Forms.TextBox();
            this.information_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combobox_station = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(822, 635);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(164, 50);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            this.email_label.Size = new System.Drawing.Size(100, 24);
            this.email_label.TabIndex = 8;
            this.email_label.Text = "Capacidad";
            // 
            // input_stationname
            // 
            this.input_stationname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_stationname.Location = new System.Drawing.Point(740, 71);
            this.input_stationname.Margin = new System.Windows.Forms.Padding(2);
            this.input_stationname.Name = "input_stationname";
            this.input_stationname.Size = new System.Drawing.Size(246, 22);
            this.input_stationname.TabIndex = 11;
            // 
            // input_capacidad
            // 
            this.input_capacidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_capacidad.Location = new System.Drawing.Point(740, 108);
            this.input_capacidad.Margin = new System.Windows.Forms.Padding(2);
            this.input_capacidad.Name = "input_capacidad";
            this.input_capacidad.Size = new System.Drawing.Size(246, 22);
            this.input_capacidad.TabIndex = 12;
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
            this.label1.Size = new System.Drawing.Size(283, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Agregar nueva estación cercana";
            // 
            // combobox_station
            // 
            this.combobox_station.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combobox_station.BackColor = System.Drawing.Color.White;
            this.combobox_station.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_station.FormattingEnabled = true;
            this.combobox_station.Location = new System.Drawing.Point(740, 147);
            this.combobox_station.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combobox_station.Name = "combobox_station";
            this.combobox_station.Size = new System.Drawing.Size(246, 24);
            this.combobox_station.TabIndex = 22;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(400, 153);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(95, 635);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(164, 50);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Atrás";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // EditSationForm
            // 
            this.AcceptButton = this.btnEditar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1073, 721);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.combobox_station);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.information_label);
            this.Controls.Add(this.input_capacidad);
            this.Controls.Add(this.input_stationname);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.btnEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditSationForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.TextBox input_stationname;
        private System.Windows.Forms.TextBox input_capacidad;
        private System.Windows.Forms.Label information_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combobox_station;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnBack;
    }
}