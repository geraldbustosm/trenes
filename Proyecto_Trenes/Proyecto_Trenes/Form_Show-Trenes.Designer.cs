namespace Proyecto_Trenes
{
    partial class Form_Show_Trenes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGrid_Trenes = new System.Windows.Forms.DataGridView();
            this.trenBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.trenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Trenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trenBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_Trenes
            // 
            this.dataGrid_Trenes.AutoGenerateColumns = false;
            this.dataGrid_Trenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Trenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.capacidadDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.origenDataGridViewTextBoxColumn,
            this.destinoDataGridViewTextBoxColumn,
            this.Edit,
            this.Delete});
            this.dataGrid_Trenes.DataSource = this.trenBindingSource1;
            this.dataGrid_Trenes.Location = new System.Drawing.Point(12, 105);
            this.dataGrid_Trenes.Name = "dataGrid_Trenes";
            this.dataGrid_Trenes.Size = new System.Drawing.Size(845, 333);
            this.dataGrid_Trenes.TabIndex = 0;
            this.dataGrid_Trenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Trenes_CellContentClick);
            // 
            // trenBindingSource1
            // 
            this.trenBindingSource1.DataSource = typeof(Proyecto_Trenes.Tren);
            // 
            // trenBindingSource
            // 
            this.trenBindingSource.DataSource = typeof(Proyecto_Trenes.Tren);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_search.Location = new System.Drawing.Point(88, 25);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(308, 29);
            this.textBox_search.TabIndex = 2;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(402, 32);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(73, 20);
            this.button_search.TabIndex = 3;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(481, 32);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(73, 20);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // capacidadDataGridViewTextBoxColumn
            // 
            this.capacidadDataGridViewTextBoxColumn.DataPropertyName = "capacidad";
            this.capacidadDataGridViewTextBoxColumn.HeaderText = "capacidad";
            this.capacidadDataGridViewTextBoxColumn.Name = "capacidadDataGridViewTextBoxColumn";
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            // 
            // origenDataGridViewTextBoxColumn
            // 
            this.origenDataGridViewTextBoxColumn.DataPropertyName = "origen";
            this.origenDataGridViewTextBoxColumn.HeaderText = "origen";
            this.origenDataGridViewTextBoxColumn.Name = "origenDataGridViewTextBoxColumn";
            // 
            // destinoDataGridViewTextBoxColumn
            // 
            this.destinoDataGridViewTextBoxColumn.DataPropertyName = "destino";
            this.destinoDataGridViewTextBoxColumn.HeaderText = "destino";
            this.destinoDataGridViewTextBoxColumn.Name = "destinoDataGridViewTextBoxColumn";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // Form_Show_Trenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 450);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid_Trenes);
            this.Name = "Form_Show_Trenes";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form_Show_Trenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Trenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trenBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trenBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_Trenes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.BindingSource trenBindingSource;
        private System.Windows.Forms.BindingSource trenBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn origenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}

