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
            this.travel_datagrid = new System.Windows.Forms.DataGridView();
            this.label_fecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.travel_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // travel_datagrid
            // 
            this.travel_datagrid.AllowUserToAddRows = false;
            this.travel_datagrid.AllowUserToDeleteRows = false;
            this.travel_datagrid.AllowUserToResizeColumns = false;
            this.travel_datagrid.AllowUserToResizeRows = false;
            this.travel_datagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.travel_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.travel_datagrid.BackgroundColor = System.Drawing.Color.White;
            this.travel_datagrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.travel_datagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.travel_datagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.travel_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.travel_datagrid.EnableHeadersVisualStyles = false;
            this.travel_datagrid.Location = new System.Drawing.Point(95, 71);
            this.travel_datagrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.travel_datagrid.Name = "travel_datagrid";
            this.travel_datagrid.ReadOnly = true;
            this.travel_datagrid.RowHeadersVisible = false;
            this.travel_datagrid.RowHeadersWidth = 51;
            this.travel_datagrid.RowTemplate.Height = 24;
            this.travel_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.travel_datagrid.Size = new System.Drawing.Size(887, 585);
            this.travel_datagrid.TabIndex = 18;
            // 
            // label_fecha
            // 
            this.label_fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_fecha.AutoSize = true;
            this.label_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label_fecha.Location = new System.Drawing.Point(880, 29);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(102, 24);
            this.label_fecha.TabIndex = 22;
            this.label_fecha.Text = "00-00-0000";
            // 
            // TravelDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1073, 721);
            this.Controls.Add(this.label_fecha);
            this.Controls.Add(this.travel_datagrid);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TravelDetailsForm";
            this.Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.travel_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView travel_datagrid;
        private System.Windows.Forms.Label label_fecha;
    }
}