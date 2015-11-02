namespace TCPChatCliente
{
    partial class ChatPersonal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatPersonal));
            this.btnVideo = new System.Windows.Forms.Button();
            this.picBoxVideo = new System.Windows.Forms.PictureBox();
            this.listChatMessagesPersonal = new System.Windows.Forms.RichTextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.richEscrito = new System.Windows.Forms.RichTextBox();
            this.labelVideo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVideo
            // 
            this.btnVideo.BackgroundImage = global::TCPChatCliente.Properties.Resources.le_lolz;
            this.btnVideo.Location = new System.Drawing.Point(593, 444);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(39, 42);
            this.btnVideo.TabIndex = 27;
            this.btnVideo.Text = "OK";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click_1);
            // 
            // picBoxVideo
            // 
            this.picBoxVideo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.picBoxVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxVideo.Location = new System.Drawing.Point(595, 231);
            this.picBoxVideo.Name = "picBoxVideo";
            this.picBoxVideo.Size = new System.Drawing.Size(297, 207);
            this.picBoxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxVideo.TabIndex = 25;
            this.picBoxVideo.TabStop = false;
            // 
            // listChatMessagesPersonal
            // 
            this.listChatMessagesPersonal.Enabled = false;
            this.listChatMessagesPersonal.Location = new System.Drawing.Point(12, 12);
            this.listChatMessagesPersonal.Name = "listChatMessagesPersonal";
            this.listChatMessagesPersonal.Size = new System.Drawing.Size(577, 333);
            this.listChatMessagesPersonal.TabIndex = 24;
            this.listChatMessagesPersonal.Text = "";
            this.listChatMessagesPersonal.TextChanged += new System.EventHandler(this.listChatMessagesPersonal_TextChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(500, 418);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(87, 43);
            this.btnEnviar.TabIndex = 22;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // richEscrito
            // 
            this.richEscrito.Location = new System.Drawing.Point(12, 363);
            this.richEscrito.Name = "richEscrito";
            this.richEscrito.Size = new System.Drawing.Size(484, 98);
            this.richEscrito.TabIndex = 16;
            this.richEscrito.Text = "";
            this.richEscrito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richEscrito_KeyDown);
            // 
            // labelVideo
            // 
            this.labelVideo.AutoSize = true;
            this.labelVideo.ForeColor = System.Drawing.Color.Red;
            this.labelVideo.Location = new System.Drawing.Point(612, 489);
            this.labelVideo.Name = "labelVideo";
            this.labelVideo.Size = new System.Drawing.Size(0, 13);
            this.labelVideo.TabIndex = 28;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(595, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(297, 213);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(502, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 49);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 25);
            this.button2.TabIndex = 31;
            this.button2.Text = "Guardar conversacion";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(426, 467);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 30);
            this.button3.TabIndex = 32;
            this.button3.Text = "Encriptar conversacion";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ChatPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(906, 499);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelVideo);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.picBoxVideo);
            this.Controls.Add(this.listChatMessagesPersonal);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.richEscrito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatPersonal";
            this.Text = "ChatPersonal";
            this.Load += new System.EventHandler(this.ChatPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.PictureBox picBoxVideo;
        private System.Windows.Forms.RichTextBox listChatMessagesPersonal;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox richEscrito;
        private System.Windows.Forms.Label labelVideo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

    }
}