using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientPOI;

namespace ClientPOI.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            cBState.DataSource = Enum.GetValues(typeof(UserState));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != "")
                if (txtUser.Text != "")
                {
                    frmChat Chat = new frmChat(txtUser.Text, cBState.Text, txtServer.Text);
                    Chat.Show();
                    this.Hide();
                }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            frmPrincipal principal=new frmPrincipal();
            principal.Show();

       
        }
    }
}
