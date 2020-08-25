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
    }
}
