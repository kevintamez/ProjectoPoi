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
using System.Net.Sockets;
using System.Windows;
using System.Net.NetworkInformation;
using System.IO;
using System.Threading;
using System.Windows.Input;
using System.Collections;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Media;


namespace TCPChatCliente
{
    public partial class Chat : Form
    {
        SoundPlayer zumb = new SoundPlayer("Windows Ringin.wav");
        public String ipAddress;
        private bool encrypt = false;
        private Correo co;
        private ChatPersonal cp;
        private Hashtable emoticons;
        private String msgZumbido = "ha enviado un zumbido!";
        private Boolean tempBool = false, zumbidoBoolean = false;
        private String sDataIncomming, sDataCheck = "null";
        private String _nombre;
        private TcpClient _client;
        private StreamReader _sReader;
        private StreamWriter _sWriter;
        private Boolean _isConnected;
        public string tiempo;
        public int beh = 0;
        public Chat() { }
        public Chat(String nombre, String contra, String ipAddress)
        {
            this.ipAddress = ipAddress;
            _nombre = nombre;
            InitializeComponent();

            try
            {
                _client = new TcpClient();
                _client.Connect(ipAddress, 5555);
                this.Show();
            }
            catch (Exception)
            {
                //Aqui pondriamos la otra forma para cambiar la ip del host servidor
                ChangeHostIP changeHost = new ChangeHostIP(nombre, contra);
                this.Hide();
                changeHost.Show();
            }
        }
        public void HandleCommunication(String nombre)
        {
            try
            {

                _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);
            }
            catch (Exception)
            {
            }
            _isConnected = true;
            String sData = null;
            while (_isConnected)
            {
                try
                {
                    if (zumbidoBoolean == true)
                    { sData = msgZumbido; }
                    else
                    {
                        sData = richEscrito.Text;
                    }
                    if (encrypt == true)
                    {
                        _sWriter.WriteLine(Encrypt.Encryptar(nombre + ": " + sData + " " + comboFuente.Text));
                        _sWriter.Flush();
                    }
                    else
                    {
                        _sWriter.WriteLine(nombre + ": " + sData + " " + comboFuente.Text + " " + tiempo);
                        _sWriter.Flush();
                    }
                    break;
                }
                catch (Exception)
                {

                }

            }
        }
        public void HandleCommunication(String nombre, String clienteP, String SDatap)
        {
            try
            {
                _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);
            }
            catch (Exception)
            {
            }

            _isConnected = true;

            while (_isConnected)
            {
                try
                {
                    if (encrypt == true)
                    {
                        _sWriter.WriteLine(Encrypt.Encryptar("~" + clienteP + " " + nombre + ": " + SDatap));
                        _sWriter.Flush();
                    }
                    else
                    {
                        _sWriter.WriteLine("~" + clienteP + " " + nombre + ": " + SDatap);
                        _sWriter.Flush();
                    }

                    break;
                }
                catch (Exception)
                {

                }

            }
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            CrearEmoticones();
        }
        public void CrearEmoticones()
        {
            emoticons = new Hashtable(16);
            emoticons.Add(":)", "smile");
            emoticons.Add(":d", "grin");
            emoticons.Add(":o", "surprised");
            emoticons.Add(":p", "tongue_smile");
            emoticons.Add(";)", "wink");
            emoticons.Add(":(", "sad");
            emoticons.Add(":s", "confused");
            emoticons.Add(":-|", "dissapointed");
            emoticons.Add(":'(", "crying");
            emoticons.Add(":$", "shy");
            emoticons.Add("(H)", "cool");
            emoticons.Add(":@", "angry");
            emoticons.Add("(A)", "angel");
            emoticons.Add("(6)", "devil");
            emoticons.Add(":-#", "dont_tell");
            emoticons.Add("8o|", "teeth");
        }
        public void AgregarEmoticon()
        {
            foreach (string emoticon in emoticons.Keys)
            {
                while (listChatMessages.Text.Contains(emoticon))
                {
                    int ind = listChatMessages.Text.IndexOf(emoticon);
                    listChatMessages.Select(ind, emoticon.Length);
                    StreamReader sr = File.OpenText("emoticons/" + emoticons[emoticon] + ".rtf");
                    // listChatMessages.SelectedRtf = @"{\rtf1\ansi \b bold \b0 }";
                    //listChatMessages.AppendText("fdsfdsf\u2028");
                    listChatMessages.SelectedRtf = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            HandleCommunication(_nombre);
            richEscrito.AppendText(Environment.NewLine + " >> " + _nombre + "\n \n  ");
            richEscrito.SelectAll();
            richEscrito.Clear();
        }
        public void HandleClient()
        {
            try
            {
                _sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
                sDataIncomming = _sReader.ReadLine();
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(() => HandleClient());
            if (sDataIncomming != null && !sDataIncomming.Equals(sDataCheck))
            {
                try
                {
                    if (encrypt == true )
                    {
                        sDataIncomming = Encrypt.Encryptar(sDataIncomming);
                    }
                }
                catch { }
                String[] _Estado = sDataIncomming.Split(' ');
                String estado = "";
                if (_Estado[_Estado.Length - 1].Equals("AUSENTE") || _Estado[_Estado.Length - 1].Equals("OCUPADO") || _Estado[_Estado.Length - 1].Equals("DISPONIBLE"))
                {
                    estado = _Estado[_Estado.Length - 1];
                    _Estado[_Estado.Length - 1] = "";
                    sDataIncomming = string.Join(" ", _Estado);
                }

                 writeToFile(sDataIncomming);
                if (sDataIncomming.Contains(msgZumbido))
                {
                    Zumbido();
                    sDataIncomming = _nombre + " ah enviado un zumbido.";
                }
                if (sDataIncomming[0].Equals('~'))
                {
                    String[] _privateClientz = sDataIncomming.Split(' ');
                    // Aqui se divide el mensaje por espacios, indice 0 representa el clienteDestino, el indice 1 el remitente del mensaje, a partir de hay es el mensaje;
                    _privateClientz[0] = _privateClientz[0].Replace("~", "");
                    if (cp == null)
                    {
                        if (_nombre.Equals(_privateClientz[0]))
                        {
                            cp = new ChatPersonal(_privateClientz[1].Replace(":", ""), _privateClientz[0], this);
                            cp.showMessage(_privateClientz);
                        }
                    }
                    else
                    {
                        cp.showMessage(_privateClientz);
                    }
                }

                if (!sDataIncomming[0].Equals('~'))
                {

                    if (listChatMessages.Text != "")
                    {
                        listChatMessages.AppendText("\n" + (sDataIncomming));
                    }
                    else
                    {

                        listChatMessages.AppendText((sDataIncomming));
                    }
                }
                sDataCheck = sDataIncomming;
                string[] x = sDataCheck.Split(':');
                foreach (Object s in listAmigos.Items)
                {
                    if (s.ToString().Equals(x[0]) || sDataIncomming[0].Equals('~'))
                    {

                        tempBool = true;
                        switch (estado)
                        {
                            case "AUSENTE":
                                try { listEstados.Items.RemoveAt(listAmigos.Items.IndexOf(s)); }
                                catch { }
                                listEstados.Items.Insert(listAmigos.Items.IndexOf(s), "AUSENTE");
                                break;
                            case "DISPONIBLE":
                                try { listEstados.Items.RemoveAt(listAmigos.Items.IndexOf(s)); }
                                catch { }
                                listEstados.Items.Insert(listAmigos.Items.IndexOf(s), "DISPONIBLE");
                                break;

                            case "OCUPADO":
                                try { listEstados.Items.RemoveAt(listAmigos.Items.IndexOf(s)); }
                                catch { }
                                listEstados.Items.Insert(listAmigos.Items.IndexOf(s), "OCUPADO");
                                break;

                        }
                    }
                }
                if (tempBool == true)
                {
                    tempBool = false;
                }
                else
                {
                    if (!x[0].Contains("ah enviado un zumbido."))
                    {
                        listAmigos.Items.Add(x[0]);
                    }
                }
            }
            t.Start();
        }
        private void writeToFile(String _string)
        {
            using (StreamWriter _escritor = new StreamWriter("conversacion.txt", true))
            {
                _escritor.WriteLine(_string);
            }
        }
        private void richEscrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnviar_Click(sender, e);
                System.Windows.Forms.SendKeys.Send("{BACKSPACE}");
            }
        }
        private void listChatMessages_TextChanged(object sender, EventArgs e)
        {
            AgregarEmoticon();
        }
        public void Zumbido()
        {
            int xCoord = this.Left;
            int yCoord = this.Top;

            int rnd = 0;

            Random RandomClass = new Random();

            for (int i = 0; i <= 1000; i++)
            {
                rnd = RandomClass.Next(xCoord + 1, xCoord + 15);
                this.Left = rnd;
                rnd = RandomClass.Next(yCoord + 1, yCoord + 15);
                this.Top = rnd;
            }

            // Restore the original location of the form
            Chat.ActiveForm.Left = xCoord;
            Chat.ActiveForm.Top = yCoord;
            zumbidoBoolean = false;

        }
        private void btnNudge_Click(object sender, EventArgs e)
        {
            zumbidoBoolean = true;
            zumb.Play();
            HandleCommunication(_nombre);
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {


        }


        private void listAmigos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listAmigos.SelectedItem.ToString() != null && !listAmigos.SelectedItem.ToString().Trim().Equals("") && !listAmigos.SelectedItem.ToString().Equals(_nombre))
                    cp = new ChatPersonal(listAmigos.SelectedItem.ToString(), _nombre, this);
            }
            catch { }

        }


        private void listAmigos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (encrypt == true)
            {
                btnEncrypt.BackColor = Color.White;
                encrypt = false;
            }
            else
            {
                encrypt = true;
                btnEncrypt.BackColor = Color.Red;
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            Stmpcs stmp = new Stmpcs();
        }


        private void comboFuente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picBoxVideo_Click(object sender, EventArgs e)
        {

        }

        private void richEscrito_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Selected)
            {
                richEscrito.AppendText(":)");
                toolStrip1.Visible = false;
            }

            if (toolStripButton2.Selected)
            {
                richEscrito.AppendText("(A)");
                toolStrip1.Visible = false;
            }

            if (toolStripButton3.Selected)
            {
                richEscrito.AppendText(":@");
                toolStrip1.Visible = false;
            }

            if (toolStripButton4.Selected)
            {
                richEscrito.AppendText(":s");
                toolStrip1.Visible = false;
            }

            if (toolStripButton5.Selected)
            {
                richEscrito.AppendText("(H)");
                toolStrip1.Visible = false;
            }

            if (toolStripButton6.Selected)
            {
                richEscrito.AppendText(":'(");
                toolStrip1.Visible = false;
            }

            if (toolStripButton7.Selected)
            {
                richEscrito.AppendText("(6)");
                toolStrip1.Visible = false;
            }

            if (toolStripButton8.Selected)
            {
                richEscrito.AppendText(":-|");
                toolStrip1.Visible = false;
            }

            if (toolStripButton9.Selected)
            {
                richEscrito.AppendText(":-#");
                toolStrip1.Visible = false;
            }

            if (toolStripButton10.Selected)
            {
                richEscrito.AppendText(":d");
                toolStrip1.Visible = false;
            }

            if (toolStripButton11.Selected)
            {
                richEscrito.AppendText(":(");
                toolStrip1.Visible = false;
            }

            if (toolStripButton12.Selected)
            {
                richEscrito.AppendText(":$");
                toolStrip1.Visible = false;
            }

            if (toolStripButton13.Selected)
            {
                richEscrito.AppendText(":o");
                toolStrip1.Visible = false;
            }

            if (toolStripButton14.Selected)
            {
                richEscrito.AppendText("8o|");
                toolStrip1.Visible = false;
            }

            if (toolStripButton15.Selected)
            {
                richEscrito.AppendText(":p");
                toolStrip1.Visible = false;
            }

            if (toolStripButton16.Selected)
            {
                richEscrito.AppendText(";)");
                toolStrip1.Visible = false;
            }
        }

        private void comboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            toolStrip1.Visible = true;
        }

        private void listEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            co = new Correo();
            co.Show();
        }
    }
}

