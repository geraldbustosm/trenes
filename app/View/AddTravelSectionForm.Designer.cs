﻿namespace View
{
    partial class AddTravelSectionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.save_trip_btn = new System.Windows.Forms.Button();
            this.machines_combo_box = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.actions_datagrid = new System.Windows.Forms.DataGridView();
            this.destination_station_combo_box = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.init_date = new System.Windows.Forms.DateTimePicker();
            this.init_hour = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.init_station_combo_box = new System.Windows.Forms.ComboBox();
            this.arrival_hour = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.arrival_date = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.actions_combo_box = new System.Windows.Forms.ComboBox();
            this.add_action_btn = new System.Windows.Forms.Button();
            this.next_section_btn = new System.Windows.Forms.Button();
            this.information_label = new System.Windows.Forms.Label();
            this.train_state_datagrid = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.locomotive_combobox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.capacity_label = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.fix_locomotive_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.actions_datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.train_state_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(59, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estación de partida";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(551, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estación de llegada";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(24)))), ((int)(((byte)(79)))));
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cancel_btn.ForeColor = System.Drawing.Color.White;
            this.cancel_btn.Location = new System.Drawing.Point(57, 635);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(164, 50);
            this.cancel_btn.TabIndex = 10;
            this.cancel_btn.Text = "Cancelar";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // save_trip_btn
            // 
            this.save_trip_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_trip_btn.BackColor = System.Drawing.Color.ForestGreen;
            this.save_trip_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_trip_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.save_trip_btn.ForeColor = System.Drawing.Color.White;
            this.save_trip_btn.Location = new System.Drawing.Point(868, 635);
            this.save_trip_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.save_trip_btn.Name = "save_trip_btn";
            this.save_trip_btn.Size = new System.Drawing.Size(164, 50);
            this.save_trip_btn.TabIndex = 11;
            this.save_trip_btn.Text = "Guardar viaje";
            this.save_trip_btn.UseVisualStyleBackColor = false;
            this.save_trip_btn.Click += new System.EventHandler(this.save_trip_btn_Click);
            // 
            // machines_combo_box
            // 
            this.machines_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machines_combo_box.FormattingEnabled = true;
            this.machines_combo_box.Location = new System.Drawing.Point(277, 267);
            this.machines_combo_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.machines_combo_box.Name = "machines_combo_box";
            this.machines_combo_box.Size = new System.Drawing.Size(246, 24);
            this.machines_combo_box.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(57, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Seleccione máquina";
            // 
            // actions_datagrid
            // 
            this.actions_datagrid.AllowUserToAddRows = false;
            this.actions_datagrid.AllowUserToDeleteRows = false;
            this.actions_datagrid.AllowUserToResizeColumns = false;
            this.actions_datagrid.AllowUserToResizeRows = false;
            this.actions_datagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actions_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.actions_datagrid.BackgroundColor = System.Drawing.Color.White;
            this.actions_datagrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.actions_datagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.actions_datagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.actions_datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.actions_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.actions_datagrid.DefaultCellStyle = dataGridViewCellStyle27;
            this.actions_datagrid.EnableHeadersVisualStyles = false;
            this.actions_datagrid.Location = new System.Drawing.Point(63, 389);
            this.actions_datagrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.actions_datagrid.Name = "actions_datagrid";
            this.actions_datagrid.ReadOnly = true;
            this.actions_datagrid.RowHeadersVisible = false;
            this.actions_datagrid.RowHeadersWidth = 51;
            this.actions_datagrid.RowTemplate.Height = 24;
            this.actions_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.actions_datagrid.Size = new System.Drawing.Size(460, 209);
            this.actions_datagrid.TabIndex = 17;
            // 
            // destination_station_combo_box
            // 
            this.destination_station_combo_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destination_station_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destination_station_combo_box.FormattingEnabled = true;
            this.destination_station_combo_box.Location = new System.Drawing.Point(786, 46);
            this.destination_station_combo_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.destination_station_combo_box.Name = "destination_station_combo_box";
            this.destination_station_combo_box.Size = new System.Drawing.Size(246, 24);
            this.destination_station_combo_box.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(59, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fecha partida";
            // 
            // init_date
            // 
            this.init_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.init_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.init_date.Location = new System.Drawing.Point(277, 100);
            this.init_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.init_date.Name = "init_date";
            this.init_date.Size = new System.Drawing.Size(246, 28);
            this.init_date.TabIndex = 24;
            // 
            // init_hour
            // 
            this.init_hour.CustomFormat = "hh:mm";
            this.init_hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.init_hour.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.init_hour.Location = new System.Drawing.Point(277, 156);
            this.init_hour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.init_hour.Name = "init_hour";
            this.init_hour.ShowUpDown = true;
            this.init_hour.Size = new System.Drawing.Size(246, 28);
            this.init_hour.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(551, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Hora de llegada";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(59, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Hora de partida";
            // 
            // init_station_combo_box
            // 
            this.init_station_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.init_station_combo_box.FormattingEnabled = true;
            this.init_station_combo_box.Location = new System.Drawing.Point(277, 46);
            this.init_station_combo_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.init_station_combo_box.Name = "init_station_combo_box";
            this.init_station_combo_box.Size = new System.Drawing.Size(246, 24);
            this.init_station_combo_box.TabIndex = 29;
            this.init_station_combo_box.SelectionChangeCommitted += new System.EventHandler(this.init_station_combo_box_SelectionChangeCommitted);
            // 
            // arrival_hour
            // 
            this.arrival_hour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arrival_hour.CustomFormat = "hh:mm";
            this.arrival_hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.arrival_hour.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.arrival_hour.Location = new System.Drawing.Point(786, 154);
            this.arrival_hour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.arrival_hour.Name = "arrival_hour";
            this.arrival_hour.ShowUpDown = true;
            this.arrival_hour.Size = new System.Drawing.Size(246, 28);
            this.arrival_hour.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(551, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 31;
            this.label7.Text = "Fecha llegada";
            // 
            // arrival_date
            // 
            this.arrival_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arrival_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.arrival_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.arrival_date.Location = new System.Drawing.Point(786, 98);
            this.arrival_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.arrival_date.Name = "arrival_date";
            this.arrival_date.Size = new System.Drawing.Size(246, 28);
            this.arrival_date.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(57, 219);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 24);
            this.label8.TabIndex = 33;
            this.label8.Text = "Seleccione acción";
            // 
            // actions_combo_box
            // 
            this.actions_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actions_combo_box.FormattingEnabled = true;
            this.actions_combo_box.Location = new System.Drawing.Point(277, 219);
            this.actions_combo_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.actions_combo_box.Name = "actions_combo_box";
            this.actions_combo_box.Size = new System.Drawing.Size(246, 24);
            this.actions_combo_box.TabIndex = 34;
            this.actions_combo_box.SelectedIndexChanged += new System.EventHandler(this.actions_combo_box_SelectedIndexChanged);
            // 
            // add_action_btn
            // 
            this.add_action_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.add_action_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_action_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.add_action_btn.ForeColor = System.Drawing.Color.White;
            this.add_action_btn.Location = new System.Drawing.Point(61, 312);
            this.add_action_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add_action_btn.Name = "add_action_btn";
            this.add_action_btn.Size = new System.Drawing.Size(164, 50);
            this.add_action_btn.TabIndex = 35;
            this.add_action_btn.Text = "Agregar acción";
            this.add_action_btn.UseVisualStyleBackColor = false;
            this.add_action_btn.Click += new System.EventHandler(this.add_action_btn_Click);
            // 
            // next_section_btn
            // 
            this.next_section_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.next_section_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.next_section_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_section_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.next_section_btn.ForeColor = System.Drawing.Color.White;
            this.next_section_btn.Location = new System.Drawing.Point(651, 635);
            this.next_section_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.next_section_btn.Name = "next_section_btn";
            this.next_section_btn.Size = new System.Drawing.Size(164, 50);
            this.next_section_btn.TabIndex = 36;
            this.next_section_btn.Text = "Siguiente tramo";
            this.next_section_btn.UseVisualStyleBackColor = false;
            this.next_section_btn.Click += new System.EventHandler(this.next_section_btn_Click);
            // 
            // information_label
            // 
            this.information_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.information_label.AutoSize = true;
            this.information_label.BackColor = System.Drawing.Color.Transparent;
            this.information_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.information_label.ForeColor = System.Drawing.Color.Red;
            this.information_label.Location = new System.Drawing.Point(254, 649);
            this.information_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.information_label.Name = "information_label";
            this.information_label.Size = new System.Drawing.Size(152, 24);
            this.information_label.TabIndex = 37;
            this.information_label.Text = "information_label";
            // 
            // train_state_datagrid
            // 
            this.train_state_datagrid.AllowUserToAddRows = false;
            this.train_state_datagrid.AllowUserToDeleteRows = false;
            this.train_state_datagrid.AllowUserToResizeColumns = false;
            this.train_state_datagrid.AllowUserToResizeRows = false;
            this.train_state_datagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.train_state_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.train_state_datagrid.BackgroundColor = System.Drawing.Color.White;
            this.train_state_datagrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.train_state_datagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.train_state_datagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.train_state_datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.train_state_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.train_state_datagrid.DefaultCellStyle = dataGridViewCellStyle29;
            this.train_state_datagrid.EnableHeadersVisualStyles = false;
            this.train_state_datagrid.Location = new System.Drawing.Point(555, 389);
            this.train_state_datagrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.train_state_datagrid.Name = "train_state_datagrid";
            this.train_state_datagrid.ReadOnly = true;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.train_state_datagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.train_state_datagrid.RowHeadersVisible = false;
            this.train_state_datagrid.RowHeadersWidth = 62;
            this.train_state_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.train_state_datagrid.Size = new System.Drawing.Size(477, 209);
            this.train_state_datagrid.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label9.Location = new System.Drawing.Point(553, 338);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 24);
            this.label9.TabIndex = 39;
            this.label9.Text = "Estado del tren en el viaje";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.Location = new System.Drawing.Point(551, 217);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(204, 24);
            this.label10.TabIndex = 40;
            this.label10.Text = "Locomotora de arrastre";
            // 
            // locomotive_combobox
            // 
            this.locomotive_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.locomotive_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locomotive_combobox.FormattingEnabled = true;
            this.locomotive_combobox.Location = new System.Drawing.Point(786, 217);
            this.locomotive_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.locomotive_combobox.Name = "locomotive_combobox";
            this.locomotive_combobox.Size = new System.Drawing.Size(246, 24);
            this.locomotive_combobox.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label11.Location = new System.Drawing.Point(551, 265);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 24);
            this.label11.TabIndex = 42;
            this.label11.Text = "Capacidad de arrastre";
            // 
            // capacity_label
            // 
            this.capacity_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.capacity_label.AutoSize = true;
            this.capacity_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.capacity_label.Location = new System.Drawing.Point(782, 265);
            this.capacity_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.capacity_label.Name = "capacity_label";
            this.capacity_label.Size = new System.Drawing.Size(0, 24);
            this.capacity_label.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label13.Location = new System.Drawing.Point(942, 265);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 24);
            this.label13.TabIndex = 44;
            this.label13.Text = "Tonelada";
            // 
            // fix_locomotive_btn
            // 
            this.fix_locomotive_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fix_locomotive_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(211)))));
            this.fix_locomotive_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fix_locomotive_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.fix_locomotive_btn.ForeColor = System.Drawing.Color.White;
            this.fix_locomotive_btn.Location = new System.Drawing.Point(825, 312);
            this.fix_locomotive_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fix_locomotive_btn.Name = "fix_locomotive_btn";
            this.fix_locomotive_btn.Size = new System.Drawing.Size(207, 50);
            this.fix_locomotive_btn.TabIndex = 45;
            this.fix_locomotive_btn.Text = "Fijar locomotora";
            this.fix_locomotive_btn.UseVisualStyleBackColor = false;
            this.fix_locomotive_btn.Click += new System.EventHandler(this.fix_locomotive_btn_Click);
            // 
            // AddTravelSectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1074, 704);
            this.Controls.Add(this.fix_locomotive_btn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.capacity_label);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.locomotive_combobox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.train_state_datagrid);
            this.Controls.Add(this.information_label);
            this.Controls.Add(this.next_section_btn);
            this.Controls.Add(this.add_action_btn);
            this.Controls.Add(this.actions_combo_box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.arrival_date);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.arrival_hour);
            this.Controls.Add(this.init_station_combo_box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.init_hour);
            this.Controls.Add(this.init_date);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.destination_station_combo_box);
            this.Controls.Add(this.actions_datagrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.machines_combo_box);
            this.Controls.Add(this.save_trip_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddTravelSectionForm";
            this.Text = "AddStationForm";
            this.Load += new System.EventHandler(this.AddTravelSectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actions_datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.train_state_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button save_trip_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox machines_combo_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView actions_datagrid;
        private System.Windows.Forms.ComboBox destination_station_combo_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker init_date;
        private System.Windows.Forms.DateTimePicker init_hour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox init_station_combo_box;
        private System.Windows.Forms.DateTimePicker arrival_hour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker arrival_date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox actions_combo_box;
        private System.Windows.Forms.Button add_action_btn;
        private System.Windows.Forms.Button next_section_btn;
        private System.Windows.Forms.Label information_label;
        private System.Windows.Forms.DataGridView train_state_datagrid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox locomotive_combobox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label capacity_label;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button fix_locomotive_btn;
    }
}