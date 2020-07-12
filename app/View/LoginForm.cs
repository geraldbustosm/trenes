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
    public partial class LoginForm : Form
    {
        private LayoutForm _layoutForm;
        public LoginForm(LayoutForm layoutForm)
        {
            _layoutForm = layoutForm;
            InitializeComponent();
        }

        // Metodo que se encarga del proceso de login y enviar al formulario de bienvenida
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // todo: verificar si el usuario es correcto!

            // if autorizacion exitosa
            _layoutForm.showWelcomeScreen();
            // else 
            // *metodo que muestre los errores*
        }
    }
}
