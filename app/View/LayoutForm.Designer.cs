namespace View
{
    partial class LayoutForm
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
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelLayout = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.AutoScroll = true;
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(330, 744);
            this.panelSide.TabIndex = 0;
            // 
            // panelLayout
            // 
            this.panelLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(330, 0);
            this.panelLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.Size = new System.Drawing.Size(928, 744);
            this.panelLayout.TabIndex = 6;
            // 
            // LayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1258, 744);
            this.Controls.Add(this.panelLayout);
            this.Controls.Add(this.panelSide);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LayoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trenes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelLayout;

    }
}