namespace View
{
    partial class TravelDetailsForm
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
            this.label_fecha = new System.Windows.Forms.Label();
            this.tramo_viaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.composicion_tren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_llega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tramo_viaje,
            this.composicion_tren,
            this.hora_partida,
            this.hora_llega,
            this.accion});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(95, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(887, 500);
            this.dataGridView1.TabIndex = 18;
            // 
            // label_fecha
            // 
            this.label_fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_fecha.AutoSize = true;
            this.label_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label_fecha.Location = new System.Drawing.Point(880, 71);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(102, 24);
            this.label_fecha.TabIndex = 22;
            this.label_fecha.Text = "00-00-0000";
            // 
            // tramo_viaje
            // 
            this.tramo_viaje.HeaderText = "Tramo";
            this.tramo_viaje.MinimumWidth = 6;
            this.tramo_viaje.Name = "tramo_viaje";
            // 
            // composicion_tren
            // 
            this.composicion_tren.HeaderText = "Composición del tren";
            this.composicion_tren.MinimumWidth = 6;
            this.composicion_tren.Name = "composicion_tren";
            // 
            // hora_partida
            // 
            this.hora_partida.HeaderText = "Hora de partida";
            this.hora_partida.MinimumWidth = 6;
            this.hora_partida.Name = "hora_partida";
            // 
            // hora_llega
            // 
            this.hora_llega.HeaderText = "Hora de llegada";
            this.hora_llega.MinimumWidth = 6;
            this.hora_llega.Name = "hora_llega";
            // 
            // accion
            // 
            this.accion.HeaderText = "Acción";
            this.accion.MinimumWidth = 6;
            this.accion.Name = "accion";
            // 
            // TravelDetailsForm
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
            this.Name = "TravelDetailsForm";
            this.Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tramo_viaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn composicion_tren;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_llega;
        private System.Windows.Forms.DataGridViewTextBoxColumn accion;
    }
}