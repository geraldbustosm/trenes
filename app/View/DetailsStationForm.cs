using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class DetailsStationForm : Form
    {
        private LayoutForm _layoutForm;
        private int id;
        public DetailsStationForm(LayoutForm layoutForm, int id)
        {
            InitializeComponent();
            _layoutForm = layoutForm;
            this.id = id;
            FeedLabelStacion();
            FeedDataGridView();
            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Capacidad";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this._layoutForm.changeLayout(new ListStationsForm(this._layoutForm));
        }

        private void FeedLabelStacion()
        {
            Station station = Station.Find(id);
            label_estacion.Text = station.name;
        }
        private void FeedDataGridView()
        {
            List<Station> list = Station.GetNearbyStations(id);
            var source = new BindingSource(list, null);
            dataGridView1.DataSource = source;
        }
    }
}
