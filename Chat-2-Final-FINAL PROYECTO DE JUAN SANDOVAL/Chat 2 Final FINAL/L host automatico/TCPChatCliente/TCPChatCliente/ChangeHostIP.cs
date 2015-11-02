using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPChatCliente
{
    public partial class ChangeHostIP : Form
    {
        private String _name, _pass, _ipAddress;
        public ChangeHostIP(String nombre, String contra)
        {
            _name = nombre;
            _pass = contra;
            InitializeComponent();
           
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            if (tbNewIp.Text != "")
            {
                _ipAddress = tbNewIp.Text;
                this.Hide();
                Chat chat = new Chat(_name, _pass, _ipAddress);

            }
            else {
                MessageBox.Show("Favor de ingresar una direccion de servidor valida.", "Error");
            }

        }

       
    }
}
