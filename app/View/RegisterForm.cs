using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class RegisterForm : Form
    {
        private LayoutForm _layoutForm;
        public RegisterForm(LayoutForm layoutForm)
        {
            InitializeComponent();
            _layoutForm = layoutForm;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _layoutForm.Show(new LoginForm(_layoutForm));
        }
    }
}
