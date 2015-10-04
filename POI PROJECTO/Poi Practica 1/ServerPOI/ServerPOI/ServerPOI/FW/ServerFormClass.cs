using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ServerPOI.FW
{
    public class ServerFormClass: Form
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ServerFormClass
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "ServerFormClass";
            this.Load += new System.EventHandler(this.ServerFormClass_Load);
            this.ResumeLayout(false);

        }

        private void ServerFormClass_Load(object sender, EventArgs e)
        {

        }
    }
}
