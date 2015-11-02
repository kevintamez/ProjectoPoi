using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace TCPChatCliente
{
    public partial class Login : Form
    {
        private static IPAddress[] ip = Dns.GetHostAddresses("Juan-PC");

        private String ipAddress = ip[2].ToString(), _nombreUsuario, _contrasenia;
       
        public Login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text != null && !txtNombreUsuario.Text.Trim().Equals("") && txtContrasenia.Text != null && !txtContrasenia.Text.Trim().Equals(""))
            {
                this._nombreUsuario = this.txtNombreUsuario.Text;
                this._contrasenia = this.txtContrasenia.Text;
                Chat chat = new Chat(_nombreUsuario, _contrasenia,ipAddress);
                this.Hide();
                
          
            }
            else {
                MessageBox.Show("Favor de ingresar correctamente los datos requeridos","Error de autenticacion");
             }
        }

        private void txtContrasenia_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
