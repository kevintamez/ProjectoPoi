namespace TCPChatCliente
{
    partial class Stmpcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stmpcs));
            this.txt_password = new System.Windows.Forms.MaskedTextBox();
            this.FontSizeMenos = new System.Windows.Forms.Button();
            this.FonSizeMas = new System.Windows.Forms.Button();
            this.ToggleBold = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_message = new System.Windows.Forms.RichTextBox();
            this.txt_attachment = new System.Windows.Forms.TextBox();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.txt_account = new System.Windows.Forms.TextBox();
            this.txt_to = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(140, 54);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(253, 20);
            this.txt_password.TabIndex = 34;
            this.txt_password.Text = "FuegoySangre";
            // 
            // FontSizeMenos
            // 
            this.FontSizeMenos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FontSizeMenos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FontSizeMenos.BackgroundImage")));
            this.FontSizeMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FontSizeMenos.Location = new System.Drawing.Point(120, 275);
            this.FontSizeMenos.Name = "FontSizeMenos";
            this.FontSizeMenos.Size = new System.Drawing.Size(29, 29);
            this.FontSizeMenos.TabIndex = 33;
            this.FontSizeMenos.UseVisualStyleBackColor = false;
            // 
            // FonSizeMas
            // 
            this.FonSizeMas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FonSizeMas.BackgroundImage")));
            this.FonSizeMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FonSizeMas.Location = new System.Drawing.Point(85, 275);
            this.FonSizeMas.Name = "FonSizeMas";
            this.FonSizeMas.Size = new System.Drawing.Size(29, 29);
            this.FonSizeMas.TabIndex = 32;
            this.FonSizeMas.UseVisualStyleBackColor = true;
            // 
            // ToggleBold
            // 
            this.ToggleBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToggleBold.Location = new System.Drawing.Point(45, 275);
            this.ToggleBold.Name = "ToggleBold";
            this.ToggleBold.Size = new System.Drawing.Size(34, 29);
            this.ToggleBold.TabIndex = 31;
            this.ToggleBold.Text = "N";
            this.ToggleBold.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Contraseña: ";
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(325, 424);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(92, 43);
            this.btn_send.TabIndex = 29;
            this.btn_send.Text = "Enviar";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(45, 310);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(372, 108);
            this.txt_message.TabIndex = 28;
            this.txt_message.Text = "";
            // 
            // txt_attachment
            // 
            this.txt_attachment.Location = new System.Drawing.Point(134, 204);
            this.txt_attachment.Name = "txt_attachment";
            this.txt_attachment.Size = new System.Drawing.Size(259, 20);
            this.txt_attachment.TabIndex = 27;
            // 
            // txt_subject
            // 
            this.txt_subject.Location = new System.Drawing.Point(134, 148);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(259, 20);
            this.txt_subject.TabIndex = 26;
            // 
            // txt_account
            // 
            this.txt_account.Location = new System.Drawing.Point(134, 10);
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(259, 20);
            this.txt_account.TabIndex = 25;
            this.txt_account.Text = "empostoise_pk@hotmail.com";
            this.txt_account.TextChanged += new System.EventHandler(this.txt_account_TextChanged);
            // 
            // txt_to
            // 
            this.txt_to.Location = new System.Drawing.Point(134, 101);
            this.txt_to.Name = "txt_to";
            this.txt_to.Size = new System.Drawing.Size(259, 20);
            this.txt_to.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Archivo:";
            // 
            // btn_browse
            // 
            this.btn_browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browse.Location = new System.Drawing.Point(404, 201);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(30, 23);
            this.btn_browse.TabIndex = 22;
            this.btn_browse.Text = "...";
            this.btn_browse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "De: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mensaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Asunto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Para: ";
            // 
            // Stmpcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(458, 479);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.FontSizeMenos);
            this.Controls.Add(this.FonSizeMas);
            this.Controls.Add(this.ToggleBold);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.txt_attachment);
            this.Controls.Add(this.txt_subject);
            this.Controls.Add(this.txt_account);
            this.Controls.Add(this.txt_to);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Stmpcs";
            this.Text = "Stmpcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txt_password;
        private System.Windows.Forms.Button FontSizeMenos;
        private System.Windows.Forms.Button FonSizeMas;
        private System.Windows.Forms.Button ToggleBold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.RichTextBox txt_message;
        private System.Windows.Forms.TextBox txt_attachment;
        private System.Windows.Forms.TextBox txt_subject;
        private System.Windows.Forms.TextBox txt_account;
        private System.Windows.Forms.TextBox txt_to;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}