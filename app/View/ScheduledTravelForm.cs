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
            TravelController.FeedDataGridScheduledTravels(dataGridView1);
        }
    }
}
