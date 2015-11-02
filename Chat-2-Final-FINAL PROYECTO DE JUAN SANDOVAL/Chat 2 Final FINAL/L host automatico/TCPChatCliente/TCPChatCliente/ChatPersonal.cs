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
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Runtime.InteropServices;


namespace TCPChatCliente
{
    public partial class ChatPersonal : Form
    {
        Byte[] send, receive;
        private Hashtable emoticons;
        private String msgZumbido = "ha enviado un zumbido!";
        //video
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        private bool startstream = false;
        private bool haystreaming = false;
        Image imgstream, imgchat;
        UdpClient client = new UdpClient();
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
        IPEndPoint ipeps = new IPEndPoint(IPAddress.Any, 9050);
        String ipAddress;
        
        //Audio
        private Thread mListenThread;
        private IPEndPoint sIpEnd;
        private Socket audioSocket;
        private WaveIn wavein;
        private WaveOut waveout;
        private static BufferedWaveProvider wavProv;

        //Generales
        private Hashtable emoticonsP;
        private Boolean tempBoolP = false;
        private String sDataIncommingP, sDataCheckP = "null";
        public String _nombreP, _clienteP;
        private TcpClient _clientP;
        private StreamReader _sReaderP;
        private StreamWriter _sWriterP;
        private Boolean _isConnectedP;
        private Chat comunicacion;

        private Socket ClientSocket;
        private DirectSoundHelper sound;
        private byte[] buffer = new byte[2205];
        private Thread th;


        public ChatPersonal(String _cliente, String nombre, Chat _comunicacion)
        {
            ipAddress = _comunicacion.ipAddress;
            comunicacion = _comunicacion;
            _clienteP = _cliente;
            _nombreP = nombre;
            InitializeComponent();
            //video
            //BuscarDispositivos();
            //
            this.Show();
        }

        #region Webcam

        //Unser Webcam Objekt
        VideoCaptureDevice videoSource;

        void InitWebCam(int nr)
        {
            //Auflistung aller Webcam/Videogeräte
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Überprüfen, ob mindestens eine Webcam gefunden wurde
            if (videosources != null)
            {
                //Die Webcam "nr" an unser Webcam Objekt binden
                videoSource = new VideoCaptureDevice(videosources[nr].MonikerString);

                try
                {
                    //Überprüfen ob die Webcam Technische-Eigenschaften mitliefert
                    if (videoSource.VideoCapabilities.Length > 0)
                    {
                        string lowestSolution = "10000;0";
                        //Das Profil mit der niedrigsten Auflösung suchen
                        for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
                        {
                            if (videoSource.VideoCapabilities[i].FrameSize.Width < Convert.ToInt32(lowestSolution.Split(';')[0]))
                                lowestSolution = videoSource.VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                        }
                        //Dem Webcam Objekt die niedrigstmögliche Auflösung übergeben
                        videoSource.DesiredFrameSize = videoSource.VideoCapabilities[Convert.ToInt32(lowestSolution.Split(';')[1])].FrameSize;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

                //Dem Webcam Objekt den NewFrame Eventhandler zuweisen.
                //Dieser schlägt bei jedem eingehenden Bild der Webcam an
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Die Webcam aktivieren
                videoSource.Start();
            }
        }

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //Jedes ankommende Bild von der Webcam der Picturebox zuweisen
            pictureBox2.BackgroundImage = (Image)eventArgs.Frame.Clone();
        }

        #endregion

        Image LastImageSent = null;
        Image LastImageReceived = null;

        Thread Sender;
        Thread Receiver;

        bool Closing = false;
        String ClosingString = "FORM#CLOSING";
        byte[] ClosingBytes;
        ASCIIEncoding ByteConverter = new ASCIIEncoding(); 

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            comunicacion.HandleCommunication(_nombreP, _clienteP, richEscrito.Text);
            richEscrito.SelectAll();
            richEscrito.Clear();
        }
        //Video
        //public void CargarDispositivos(FilterInfoCollection Dispositivos)
        //{
        //    for (int i = 0; i < Dispositivos.Count; i++)
        //    {
        //    comboVideo.Items.Add(Dispositivos[i].Name.ToString());
        //    comboVideo.Text = comboVideo.Items[i].ToString();
        //    }
        //}
        //public void BuscarDispositivos()
        //{
        //    DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        //    if (DispositivoDeVideo.Count == 0)
        //    {
        //        ExisteDispositivo = false;
        //    }
        //    else
        //    {
        //        ExisteDispositivo = true;
        //        CargarDispositivos(DispositivoDeVideo);
        //    }
        //}
        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }
        }
        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            picBoxVideo.Image = Imagen;
            imgstream = Imagen;
        }

        public Byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public Image byteArrayToImage(Byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public void GetStream()
        {
            while (startstream)     //SI HAY UN STREAMING, RECIBE LA IMAGEN COMO ARREGLO DE BYTES
            {
                Byte[] receiveBytes = client.Receive(ref ipeps);
                if (!send.SequenceEqual(receiveBytes))
                {
                    ReceiveStream(receiveBytes);
                }
            }
        }       //FUNCIÓN DEL HILO QUE CHECA SI HAY UN STREAMING ACTIVO
        public void ReceiveStream(Byte[] byteImg)
        {
            if (haystreaming == true)
            {
                imgchat = byteArrayToImage(byteImg);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = imgchat;
            }
        }           //RECIBE EL ARREGLO DE BYTES Y LO CONVIERTE A IMAGEN, LA CUAL SE PASA AL PICTUREBOX QUE MUESTRA AL OTRO USUARIO
        public void SendStream(Image img)
        {
          // UdpClient client = new UdpClient();
            Byte[] sendBytes = imageToByteArray(picBoxVideo.Image);
            send = sendBytes;
            String ip = (ipAddress);
            int tempipep = (9050);
       client.Send(sendBytes, sendBytes.Length, ip, tempipep);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (haystreaming == true)
            {
                startstream = true;
                SendStream(imgstream);
            }
            else
            {
                startstream = false;
            }
        }
        
        public void showMessage(String[] _message)
        {
            String temp = "";
            _message[0] = "";
            for (int i = 0; i < _message.Length; i++)
            {
                temp += _message[i] + " ";
            }
            listChatMessagesPersonal.AppendText("\n\n" + temp);
        }




        private void richEscrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnviar_Click(sender, e);
                System.Windows.Forms.SendKeys.Send("{BACKSPACE}");
            }
        }
        private void btnVideo_Click_1(object sender, EventArgs e)
        {
            
            Sender = new Thread(new ParameterizedThreadStart(this.Send));
            Sender.Start(int.Parse("5554"));

            Receiver = new Thread(new ParameterizedThreadStart(Receive));
            Receiver.Start("3339" + "-" + ipAddress);

            ClosingBytes = ByteConverter.GetBytes(ClosingString);

            wavein = new WaveIn();
            wavein.WaveFormat = new WaveFormat(8000, 16, 1);

            wavein.DataAvailable += new EventHandler<WaveInEventArgs>(Recorded);
            waveout = new WaveOut();
            wavProv = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));

            waveout.Init(wavProv);

            mListenThread = new Thread(new ParameterizedThreadStart(startListen));
            mListenThread.Start();
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            wavein.StartRecording();

                //if (btnVideo.Text == "OK")
                //{
                //    if (ExisteDispositivo)
                //    {
                //        FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[comboVideo.SelectedIndex].MonikerString);
                //        FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                //        FuenteDeVideo.Start();
                //        btnVideo.Text = "Detener";
                //        comboVideo.Enabled = false;
                //        labelVideo.Text = "Dispositivo corriendo";
                //        timer1.Enabled = true;
                //        haystreaming = true;
                //    }
                //    else
                //        labelVideo.Text = "Error: No se encuenta el Dispositivo";
                //}
                //else
                //{
                //    if (FuenteDeVideo.IsRunning)
                //    {
                //        TerminarFuenteDeVideo();
                //        labelVideo.Text = "";
                //        btnVideo.Text = "OK";
                //        comboVideo.Enabled = true;
                //        timer1.Enabled = false;
                //        haystreaming = false;
                //    }
                //}
            
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
                while (listChatMessagesPersonal.Text.Contains(emoticon))
                {
                    int ind = listChatMessagesPersonal.Text.IndexOf(emoticon);
                    listChatMessagesPersonal.Select(ind, emoticon.Length);
                    StreamReader sr = File.OpenText("emoticons/" + emoticons[emoticon] + ".rtf");
                    // listChatMessages.SelectedRtf = @"{\rtf1\ansi \b bold \b0 }";
                    //listChatMessages.AppendText("fdsfdsf\u2028");
                    listChatMessagesPersonal.SelectedRtf = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }


        private void Recorded(object sender, WaveInEventArgs e)
        {
            try
            {
                IPAddress test1 = IPAddress.Parse(ipAddress);
                IPEndPoint cIpEnd = new IPEndPoint(test1, 12131);
                ClientSocket.SendTo(e.Buffer, cIpEnd);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void startListen(object sender)
        {
            //MessageBox.Show("Thread Start");
            // UDP Start
            IPEndPoint sIpEnd = new IPEndPoint(IPAddress.Any, 12131);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(sIpEnd);

            IPEndPoint remoteIpEnd = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)remoteIpEnd;


            waveout.Play();
            int offset = 0;
            while (true)
            {

                byte[] data = new byte[65535];
                int recv = sock.ReceiveFrom(data, ref Remote);
                wavProv.DiscardOnBufferOverflow = true;
                wavProv.AddSamples(data, offset, recv);


            }
        }
        private void Send(object port)
        {
            InitWebCam(int.Parse("0"));

            TcpListener Server = new TcpListener(int.Parse(port.ToString()));
            Server.Start();

            TcpClient Client = Server.AcceptTcpClient();

            NetworkStream ClientStream = Client.GetStream();

            while (true)
            {
                if (Closing)
                    break;
                try
                {
                    WriteImage((Image)pictureBox2.BackgroundImage.Clone(), ClientStream);
                    LastImageSent = (Image)pictureBox2.BackgroundImage.Clone();
                    Thread.Sleep(100);
                }
                catch
                {
                    WriteImage(LastImageSent, ClientStream);
                }
            }

            try
            {
                ClientStream.Write(ClosingBytes, 0, ClosingBytes.Length);
            }
            catch { };
        }

        private void Receive(object portip)
        {

            string[] Parameter = portip.ToString().Split('-');
            //System.Net.IPAddress IP = System.Net.IPAddress.Parse(Parameter[1]);
            System.Net.IPAddress IP = System.Net.IPAddress.Parse(Parameter[1]);

            TcpClient Exchange = new TcpClient();
            NetworkStream ExchangeStream = null;

            Image TempImage;


            while (true)
            {
                try
                {
                    Exchange.Connect(IP, int.Parse(Parameter[0]));
                    ExchangeStream = Exchange.GetStream();
                    break;
                }
                catch
                {
                    Thread.Sleep(3000);
                }
            }

            while (true)
            {
                if (Closing)
                    break;

                try
                {

                    TempImage = ReadImage(ExchangeStream);
                    if (TempImage == null)
                        throw new Exception();

                    picBoxVideo.BackgroundImage = TempImage;
                    LastImageReceived = (Image)picBoxVideo.BackgroundImage.Clone();
                    Thread.Sleep(100);
                }
                catch
                {
                    try
                    {
                        picBoxVideo.BackgroundImage = LastImageReceived;
                    }
                    catch { }
                }
            }
        }

        private void WriteImage(Image image, NetworkStream stream)
        {
            ASCIIEncoding Encoder = new ASCIIEncoding();
            MemoryStream TempStream = new MemoryStream();
            byte[] Buffer;

            try
            {

                image.Save(TempStream, System.Drawing.Imaging.ImageFormat.Gif);
            }
            catch
            {
            }

            Buffer = TempStream.ToArray();

            string ImageSize = Buffer.Length.ToString();
            while (ImageSize.Length < 20)
                ImageSize += "x";

            byte[] FittedImageSize = Encoder.GetBytes(ImageSize);
            byte[] ImagePlusSize = new byte[FittedImageSize.Length + Buffer.Length];
            Array.Copy(FittedImageSize, ImagePlusSize, FittedImageSize.Length);
            Array.Copy(Buffer, 0, ImagePlusSize, FittedImageSize.Length, Buffer.Length);

            try
            {
                stream.Write(ImagePlusSize, 0, ImagePlusSize.Length);
                stream.Flush();
            }
            catch
            {

                Closing = true;
            }
        }

        private Image ReadImage(NetworkStream stream)
        {
            Image Result;
            int BytesRead;


            byte[] ImageSize = new byte[20];
            BytesRead = stream.Read(ImageSize, 0, 20);


            if (BytesRead == 12)
            {
                if (ByteConverter.GetString(ImageSize, 0, 12) == "FORM#CLOSING")
                {
                    Closing = true;
                    return null;
                }
            }

            byte[] ErrorBuffer = new byte[100000000];

            ASCIIEncoding Decoder = new ASCIIEncoding();
            string ImageSizeString = Decoder.GetString(ImageSize).Replace("x", "");

            int TestSize;

            if (!int.TryParse(ImageSizeString, out TestSize))
            {
                stream.Read(ErrorBuffer, 0, ErrorBuffer.Length);
                return null;
            }

            byte[] ImageFile = new byte[int.Parse(ImageSizeString)];

            stream.Read(ImageFile, 0, ImageFile.Length);

            MemoryStream temps = new MemoryStream();

            try
            {
                temps.Write(ImageFile, 0, ImageFile.Length);
                Result = Image.FromStream(temps);
                return Result;
            }
            catch
            {
                return null;
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(() => GetStream());
            t.Start();
        }

        private void ChatPersonal_Load(object sender, EventArgs e)
        {
            CrearEmoticones();

        }

        private void listChatMessagesPersonal_TextChanged(object sender, EventArgs e)
        {
            AgregarEmoticon();
        }
        private void comboFuente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}