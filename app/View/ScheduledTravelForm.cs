using System;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class ScheduledTravelForm : Form
    {
        public ScheduledTravelForm()
        {
            InitializeComponent();
            DateTime local_date = DateTime.Now;
            //this.label_fecha.Text = local_date.ToString();
            TravelController.FeedDataGridTravelDetails(dataGridView1);
        }
    }
}
