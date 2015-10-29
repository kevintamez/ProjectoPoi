using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientPOI.USER;
using ClientPOI.SERVER;
using System.Threading;

namespace ClientPOI.Forms
{
   
    public partial class frmPrincipal : Form
    {
        User myUser;
        Server server;
        
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
        public frmPrincipal(string _Name, string _State, string _IP) {
            myUser = new User();
            myUser.userName = _Name;
            switch (_State)
            {
                case "Connected":
                    myUser.userState = UserState.Connected;
                    break;
                case "Absent":
                    myUser.userState = UserState.Absent;
                    break;
                case "Busy":
                    myUser.userState = UserState.Busy;
                    break;
            }
            server = new Server();
            server.IP = _IP;
            //waitingMessage = new Thread(new ThreadStart(WaittingMessage));
            //chatOn = true;
            InitializeComponent();

        }

        private void PublicarPregunta_Click(object sender, EventArgs e)
        {
            myUser = new User();
            
            string nombre = myUser.userName;

            Label nombrePublicacion = new Label();
            nombrePublicacion.Text = nombre;

            Label contenidoPublicacion = new Label();
            contenidoPublicacion.Text = ContenidoAPublicar.Text;
            contenidoPublicacion.AutoSize = true;
            contenidoPublicacion.Location = new Point(10, 100);

            //this.GBMuro.Controls.Add(nombrePublicacion);
            this.GBMuro.Controls.Add(contenidoPublicacion);
        }

        private void ListaGrupos_MouseClick(object sender, MouseEventArgs e)
        {
            string item = string.Empty;
            foreach (ListViewItem anItem in ListaGrupos.SelectedItems)//Obtiene el nombre del grupo
            {
                item = anItem.ToString();

            }
            String usuario = myUser.userName;
            frmChatGrupal formaChatGrupal = new frmChatGrupal(item, usuario);
            formaChatGrupal.Show();
        }
    }
}
