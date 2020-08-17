namespace View
{
    partial class InTransitTravelForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo_viaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origen_viaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destino_viaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_llegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_fecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo_viaje,
            this.origen_viaje,
            this.destino_viaje,
            this.hora_salida,
            this.hora_llegada});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(95, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(887, 492);
            this.dataGridView1.TabIndex = 18;
            // 
            // codigo_viaje
            // 
            this.codigo_viaje.HeaderText = "Código";
            this.codigo_viaje.MinimumWidth = 6;
            this.codigo_viaje.Name = "codigo_viaje";
            // 
            // origen_viaje
            // 
            this.origen_viaje.HeaderText = "Origen";
            this.origen_viaje.MinimumWidth = 6;
            this.origen_viaje.Name = "origen_viaje";
            // 
            // destino_viaje
            // 
            this.destino_viaje.HeaderText = "Destino";
            this.destino_viaje.MinimumWidth = 6;
            this.destino_viaje.Name = "destino_viaje";
            // 
            // hora_salida
            // 
            this.hora_salida.HeaderText = "Hora de salida";
            this.hora_salida.MinimumWidth = 6;
            this.hora_salida.Name = "hora_salida";
            // 
            // hora_llegada
            // 
            this.hora_llegada.HeaderText = "Hora de llegada";
            this.hora_llegada.MinimumWidth = 6;
            this.hora_llegada.Name = "hora_llegada";
            // 
            // label_fecha
            // 
            this.label_fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_fecha.AutoSize = true;
            this.label_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label_fecha.Location = new System.Drawing.Point(884, 71);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(102, 24);
            this.label_fecha.TabIndex = 21;
            this.label_fecha.Text = "00-00-0000";
            // 
            // InTransitTravelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1073, 721);
            this.Controls.Add(this.label_fecha);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InTransitTravelForm";
            this.Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_viaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn origen_viaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn destino_viaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_llegada;
    }
}