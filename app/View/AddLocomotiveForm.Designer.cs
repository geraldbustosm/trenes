﻿namespace View
{
    partial class AddLocomotiveForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(100, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modelo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(100, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Peso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(100, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Capacidad de arrastre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(589, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 26);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(589, 140);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(157, 26);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(589, 191);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(157, 26);
            this.textBox3.TabIndex = 5;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn.ForeColor = System.Drawing.Color.White;
            this.btn.Location = new System.Drawing.Point(105, 312);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(184, 62);
            this.btn.TabIndex = 6;
            this.btn.Text = "Agregar";
            this.btn.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(105, 403);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(641, 214);
            this.dataGridView1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(352, 641);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 62);
            this.button1.TabIndex = 8;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(209)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Location = new System.Drawing.Point(562, 641);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 62);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(100, 235);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Estación";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(589, 237);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 28);
            this.comboBox1.TabIndex = 11;
            // 
            // AddLocomotiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(928, 744);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddLocomotiveForm";
            this.Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}