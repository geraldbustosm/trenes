using System.Windows.Forms;
using Model;


namespace Controller
{
    public class ActionController
    {
        public static void FeedActionsComboBox(ComboBox combo_box)
        {
            combo_box.DataSource = Action.FindAll();
            combo_box.DisplayMember = "description";
            combo_box.ValueMember = "action_id";
        }
    }
}
