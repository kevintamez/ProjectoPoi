using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientPOI.Forms
{
    public partial class prueba : Form
    {
        public prueba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = "Hola";
            lbl.Location = new Point(100, 100);
            this.Controls.Add(lbl);
        }
    }
}
