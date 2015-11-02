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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
        public void KillMe(object o, EventArgs e)
        {
            //splashTimer.Dispose();

            this.Close();
        }        
        private void frmSplash_Load(object sender, EventArgs e)
        {
            this.SendToBack();
            pictureBox1.Image = Image.FromFile("Waiting-for-reply-GIF.gif");
        }
    }
}
