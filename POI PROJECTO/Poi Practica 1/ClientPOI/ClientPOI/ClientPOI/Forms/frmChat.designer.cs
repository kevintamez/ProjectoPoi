namespace ClientPOI
{
    partial class frmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.ListaMsg = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnzumbido = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblStatus = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.Maroon;
            this.txtMessage.Location = new System.Drawing.Point(12, 340);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(504, 101);
            this.txtMessage.TabIndex = 1;
            // 
            // ListaMsg
            // 
            this.ListaMsg.BackColor = System.Drawing.Color.White;
            this.ListaMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListaMsg.ForeColor = System.Drawing.Color.Maroon;
            this.ListaMsg.Location = new System.Drawing.Point(12, 31);
            this.ListaMsg.Name = "ListaMsg";
            this.ListaMsg.Size = new System.Drawing.Size(504, 293);
            this.ListaMsg.TabIndex = 3;
            this.ListaMsg.Text = "";
            this.ListaMsg.TextChanged += new System.EventHandler(this.rTBChat_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Location = new System.Drawing.Point(560, 300);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(73, 24);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Enviar";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(538, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // btnzumbido
            // 
            this.btnzumbido.BackColor = System.Drawing.Color.PeachPuff;
            this.btnzumbido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnzumbido.FlatAppearance.BorderSize = 0;
            this.btnzumbido.Location = new System.Drawing.Point(560, 340);
            this.btnzumbido.Name = "btnzumbido";
            this.btnzumbido.Size = new System.Drawing.Size(73, 24);
            this.btnzumbido.TabIndex = 6;
            this.btnzumbido.Text = "Zumbido";
            this.btnzumbido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnzumbido.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(395, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.BackColor = System.Drawing.Color.Transparent;
            this.LblStatus.Location = new System.Drawing.Point(352, 9);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(37, 13);
            this.LblStatus.TabIndex = 8;
            this.LblStatus.Text = "Status";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmChat
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(672, 444);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnzumbido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.ListaMsg);
            this.Controls.Add(this.txtMessage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Orange";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChat_FormClosing);
            this.Load += new System.EventHandler(this.frmChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RichTextBox ListaMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnzumbido;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}