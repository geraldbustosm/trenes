using System;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class InTransitTravelForm : Form
    {
        public InTransitTravelForm()
        {
            InitializeComponent();
        }

        private void InTransitTravelForm_Load(object sender, EventArgs e)
        {
            DateTime local_date = DateTime.Now;
            this.label_fecha.Text = local_date.ToString();
            TravelController.FeedDataGridTravelDetails(this.travel_datagrid);
        }
    }
}
