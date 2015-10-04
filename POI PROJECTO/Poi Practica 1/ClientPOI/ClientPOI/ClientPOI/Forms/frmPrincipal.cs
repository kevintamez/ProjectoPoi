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
    public partial class frmPrincipal : Form
    {
        
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void PublicarPregunta_Click(object sender, EventArgs e)
        {
            usuario u = new usuario();

            Label nombrePublicacion = new Label();
            nombrePublicacion.Text = u.nombreUsuario;

            Label contenidoPublicacion = new Label();
            contenidoPublicacion.Text = ContenidoAPublicar.Text;
            contenidoPublicacion.AutoSize = true;
            contenidoPublicacion.Location = new Point(10, 100);

            //this.GBMuro.Controls.Add(nombrePublicacion);
            this.GBMuro.Controls.Add(contenidoPublicacion);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}



public class usuario
{
    public String nombreUsuario;
    public int id;

    public usuario() { 
    }

    
}
public class publicacion
{
    DateTime fecha;
    int id;
}