using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ClientPOI.Forms
{
    public partial class frmChatGrupal : Form
    {
        Hashtable emoticonos;
        public frmChatGrupal()
        {
            InitializeComponent();
        }

        private void cBState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void AgregarEmoticonos()
        {
            foreach (string EmotiParam in emoticonos.Keys)
            {
                while (ListMsg.Text.Contains(EmotiParam))
                {
                    int emot = ListMsg.Text.IndexOf(EmotiParam);
                    ListMsg.Select(emot, EmotiParam.Length);
                    try

                    {
                        Clipboard.SetImage((Image)emoticonos[EmotiParam]);
                        ListMsg.Paste();
                    }
                    catch { }
                }
            }

        }


        public void DibujaEmoti()

        {

            emoticonos = new Hashtable(16);
            emoticonos.Add(":(", Properties.Resources.triste);
            emoticonos.Add(":3", Properties.Resources.aliviado);
            emoticonos.Add(":S", Properties.Resources.asco);
            emoticonos.Add(":*", Properties.Resources.beso);
            emoticonos.Add("u.u", Properties.Resources.desanimado);
            emoticonos.Add("<3", Properties.Resources.enamorado);
            emoticonos.Add("-.-", Properties.Resources.fastidiado);
            emoticonos.Add(":D", Properties.Resources.feliz);
            emoticonos.Add(";)", Properties.Resources.guiño);
            emoticonos.Add(":'(", Properties.Resources.lagrima);
            emoticonos.Add("n_n", Properties.Resources.jijitl);
            emoticonos.Add(":P", Properties.Resources.lengua);
            emoticonos.Add(":DD", Properties.Resources.MuyFeliz);
            emoticonos.Add("3:)", Properties.Resources.pícaro);
            emoticonos.Add(":)", Properties.Resources.sonrisa);
            emoticonos.Add(":$", Properties.Resources.sonrojado);


        }


        private void frmChatGrupal_Load(object sender, EventArgs e)
        {

        }
    }
}
