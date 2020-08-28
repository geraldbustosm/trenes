using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;


namespace Controller
{
    public class ActionController
    {
        public static void FeedActionsComboBox(ComboBox combo_box)
        {
            Stack<Action> actions = Action.FindAll();
            actions.Pop();
            actions.Pop();

            Stack<Action> valid_actions = new Stack<Action>();
            while (actions.Count != 0)
            {
                valid_actions.Push(actions.Pop());
            }

            combo_box.DataSource = new BindingSource(valid_actions, null);
            combo_box.DisplayMember = "description";
            combo_box.ValueMember = "action_id";
        }
    }
}
