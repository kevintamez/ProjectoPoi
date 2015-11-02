namespace TCPChatCliente
{
    partial class ChangeHostIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeHostIP));
            this.btnIP = new System.Windows.Forms.Button();
            this.tbNewIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIP
            // 
            this.btnIP.Location = new System.Drawing.Point(217, 253);
            this.btnIP.Name = "btnIP";
            this.btnIP.Size = new System.Drawing.Size(90, 39);
            this.btnIP.TabIndex = 0;
            this.btnIP.Text = "Conectar";
            this.btnIP.UseVisualStyleBackColor = true;
            this.btnIP.Click += new System.EventHandler(this.btnIP_Click);
            // 
            // tbNewIp
            // 
            this.tbNewIp.Location = new System.Drawing.Point(184, 218);
            this.tbNewIp.Name = "tbNewIp";
            this.tbNewIp.Size = new System.Drawing.Size(168, 20);
            this.tbNewIp.TabIndex = 1;
            this.tbNewIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Favor de ingresar la direccion IP del host a conectarse.";
            // 
            // ChangeHostIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(532, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNewIp);
            this.Controls.Add(this.btnIP);
            this.DoubleBuffered = true;
            this.Name = "ChangeHostIP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIP;
        private System.Windows.Forms.TextBox tbNewIp;
        private System.Windows.Forms.Label label1;
    }
}