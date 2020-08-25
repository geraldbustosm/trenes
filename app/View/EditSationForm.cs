using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;

namespace View
{
    public partial class EditSationForm : Form
    {
        private LayoutForm _layoutForm;
        private int id;
        private Color successfullColor, wrongColor;
        private bool checked_; 
        public EditSationForm(LayoutForm layoutForm, int id)
        {
            InitializeComponent();
            _layoutForm = layoutForm;
            this.id = id;
            FeedTextBoxs();
            FeedComboBoxStation();
            this.information_label.Text = "";
            this.successfullColor = Color.FromArgb(21, 87, 36);
            this.wrongColor = information_label.ForeColor;
            this.checked_ = false;
            combobox_station.Enabled = checked_;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string name = this.input_stationname.Text;
            int capacity = Int32.Parse(this.input_capacidad.Text);
            StationController.EditStation(this.id,name,capacity);
            if (this.checked_)
            {
                int borderStation = Int32.Parse(this.combobox_station.SelectedValue.ToString());
                BorderStation border_station = new BorderStation(this.id, borderStation);
                border_station.Save();
            }
            this.information_label.Text = "Estación editada con éxito";
            this.information_label.ForeColor = successfullColor;
            this._layoutForm.changeLayout(new ListStationsForm(this._layoutForm));
        }

        private void FeedTextBoxs()
        {
            Station station = Station.Find(this.id);
            input_stationname.Text = station.name;
            input_capacidad.Text = station.capacity.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.checked_ = !checked_;
            combobox_station.Enabled = this.checked_;
        }

        private void FeedComboBoxStation()
        {
            Console.WriteLine(this.id);
            List<Station> list = Station.GetNoNearbyStations(this.id);
            combobox_station.DataSource = list;
            combobox_station.DisplayMember = "name";
            combobox_station.ValueMember = "station_id";
        }
    }
}
