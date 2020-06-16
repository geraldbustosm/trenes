namespace Proyecto_Trenes
{
    partial class Form_Add_Tren
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_codigo = new System.Windows.Forms.TextBox();
            this.textBox_tipo = new System.Windows.Forms.TextBox();
            this.textBox_capacidad = new System.Windows.Forms.TextBox();
            this.textBox_origen = new System.Windows.Forms.TextBox();
            this.textBox_destino = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Capacidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Origen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Destino";
            // 
            // textBox_codigo
            // 
            this.textBox_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_codigo.Location = new System.Drawing.Point(176, 30);
            this.textBox_codigo.Name = "textBox_codigo";
            this.textBox_codigo.Size = new System.Drawing.Size(115, 29);
            this.textBox_codigo.TabIndex = 5;
            // 
            // textBox_tipo
            // 
            this.textBox_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_tipo.Location = new System.Drawing.Point(176, 65);
            this.textBox_tipo.Name = "textBox_tipo";
            this.textBox_tipo.Size = new System.Drawing.Size(115, 29);
            this.textBox_tipo.TabIndex = 6;
            // 
            // textBox_capacidad
            // 
            this.textBox_capacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_capacidad.Location = new System.Drawing.Point(176, 100);
            this.textBox_capacidad.Name = "textBox_capacidad";
            this.textBox_capacidad.Size = new System.Drawing.Size(115, 29);
            this.textBox_capacidad.TabIndex = 7;
            this.textBox_capacidad.TextChanged += new System.EventHandler(this.textBox_capacidad_TextChanged);
            // 
            // textBox_origen
            // 
            this.textBox_origen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_origen.Location = new System.Drawing.Point(176, 171);
            this.textBox_origen.Name = "textBox_origen";
            this.textBox_origen.Size = new System.Drawing.Size(115, 29);
            this.textBox_origen.TabIndex = 8;
            // 
            // textBox_destino
            // 
            this.textBox_destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_destino.Location = new System.Drawing.Point(176, 206);
            this.textBox_destino.Name = "textBox_destino";
            this.textBox_destino.Size = new System.Drawing.Size(115, 29);
            this.textBox_destino.TabIndex = 9;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(31, 259);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(114, 22);
            this.button_add.TabIndex = 10;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(151, 259);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(114, 22);
            this.button_cancel.TabIndex = 11;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_Add_Tren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 303);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_destino);
            this.Controls.Add(this.textBox_origen);
            this.Controls.Add(this.textBox_capacidad);
            this.Controls.Add(this.textBox_tipo);
            this.Controls.Add(this.textBox_codigo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Add_Tren";
            this.Text = "Add Tren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_codigo;
        private System.Windows.Forms.TextBox textBox_tipo;
        private System.Windows.Forms.TextBox textBox_capacidad;
        private System.Windows.Forms.TextBox textBox_origen;
        private System.Windows.Forms.TextBox textBox_destino;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_cancel;
    }
}