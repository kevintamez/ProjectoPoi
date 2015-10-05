namespace ClientPOI.Forms
{
    partial class frmChatGrupal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChatGrupal));
            this.cBState = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ListMsg = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnzumbido = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.NombreGrupox = new System.Windows.Forms.Label();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.btnIcono = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cBState
            // 
            this.cBState.BackColor = System.Drawing.Color.White;
            this.cBState.FormattingEnabled = true;
            this.cBState.Location = new System.Drawing.Point(399, 12);
            this.cBState.Name = "cBState";
            this.cBState.Size = new System.Drawing.Size(219, 21);
            this.cBState.TabIndex = 7;
            this.cBState.SelectedIndexChanged += new System.EventHandler(this.cBState_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(184, 453);
            this.dataGridView1.TabIndex = 8;
            // 
            // ListMsg
            // 
            this.ListMsg.Location = new System.Drawing.Point(190, 48);
            this.ListMsg.Name = "ListMsg";
            this.ListMsg.Size = new System.Drawing.Size(453, 260);
            this.ListMsg.TabIndex = 9;
            this.ListMsg.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(190, 345);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(443, 68);
            this.textBox1.TabIndex = 10;
            // 
            // btnzumbido
            // 
            this.btnzumbido.BackColor = System.Drawing.Color.PeachPuff;
            this.btnzumbido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnzumbido.FlatAppearance.BorderSize = 0;
            this.btnzumbido.Location = new System.Drawing.Point(481, 419);
            this.btnzumbido.Name = "btnzumbido";
            this.btnzumbido.Size = new System.Drawing.Size(73, 24);
            this.btnzumbido.TabIndex = 12;
            this.btnzumbido.Text = "Zumbido";
            this.btnzumbido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnzumbido.UseVisualStyleBackColor = false;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Location = new System.Drawing.Point(560, 419);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(73, 24);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Enviar";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSend.UseVisualStyleBackColor = false;
            // 
            // NombreGrupox
            // 
            this.NombreGrupox.AutoSize = true;
            this.NombreGrupox.BackColor = System.Drawing.Color.Transparent;
            this.NombreGrupox.Location = new System.Drawing.Point(190, 20);
            this.NombreGrupox.Name = "NombreGrupox";
            this.NombreGrupox.Size = new System.Drawing.Size(35, 13);
            this.NombreGrupox.TabIndex = 13;
            this.NombreGrupox.Text = "label1";
            // 
            // btnArchivo
            // 
            this.btnArchivo.BackColor = System.Drawing.Color.PeachPuff;
            this.btnArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnArchivo.FlatAppearance.BorderSize = 0;
            this.btnArchivo.Location = new System.Drawing.Point(320, 9);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(73, 24);
            this.btnArchivo.TabIndex = 14;
            this.btnArchivo.Text = "Archivo";
            this.btnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnArchivo.UseVisualStyleBackColor = false;
            // 
            // btnIcono
            // 
            this.btnIcono.BackColor = System.Drawing.Color.PeachPuff;
            this.btnIcono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcono.FlatAppearance.BorderSize = 0;
            this.btnIcono.Location = new System.Drawing.Point(190, 314);
            this.btnIcono.Name = "btnIcono";
            this.btnIcono.Size = new System.Drawing.Size(73, 24);
            this.btnIcono.TabIndex = 15;
            this.btnIcono.Text = "Icono";
            this.btnIcono.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnIcono.UseVisualStyleBackColor = false;
            // 
            // frmChatGrupal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(651, 455);
            this.Controls.Add(this.btnIcono);
            this.Controls.Add(this.btnArchivo);
            this.Controls.Add(this.NombreGrupox);
            this.Controls.Add(this.btnzumbido);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ListMsg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cBState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChatGrupal";
            this.Text = "frmChatGrupal";
            this.Load += new System.EventHandler(this.frmChatGrupal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBState;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox ListMsg;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnzumbido;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label NombreGrupox;
        private System.Windows.Forms.Button btnArchivo;
        private System.Windows.Forms.Button btnIcono;
    }
}