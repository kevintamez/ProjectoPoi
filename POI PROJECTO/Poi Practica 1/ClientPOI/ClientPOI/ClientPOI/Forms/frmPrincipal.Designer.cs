namespace ClientPOI.Forms
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "LMAD"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "LCC"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "LCTI"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "LA"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            this.GBMuro = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PublicarPregunta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ContenidoAPublicar = new System.Windows.Forms.RichTextBox();
            this.ListaGrupos = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.GBMuro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // GBMuro
            // 
            this.GBMuro.BackColor = System.Drawing.Color.Transparent;
            this.GBMuro.Controls.Add(this.pictureBox3);
            this.GBMuro.Controls.Add(this.pictureBox1);
            this.GBMuro.Controls.Add(this.PublicarPregunta);
            this.GBMuro.Controls.Add(this.label1);
            this.GBMuro.Controls.Add(this.ContenidoAPublicar);
            this.GBMuro.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBMuro.ForeColor = System.Drawing.Color.Maroon;
            this.GBMuro.Location = new System.Drawing.Point(116, 45);
            this.GBMuro.Name = "GBMuro";
            this.GBMuro.Size = new System.Drawing.Size(594, 408);
            this.GBMuro.TabIndex = 0;
            this.GBMuro.TabStop = false;
            this.GBMuro.Text = "Muro";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(40, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(503, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // PublicarPregunta
            // 
            this.PublicarPregunta.BackColor = System.Drawing.Color.PeachPuff;
            this.PublicarPregunta.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PublicarPregunta.Location = new System.Drawing.Point(481, 89);
            this.PublicarPregunta.Name = "PublicarPregunta";
            this.PublicarPregunta.Size = new System.Drawing.Size(75, 23);
            this.PublicarPregunta.TabIndex = 2;
            this.PublicarPregunta.Text = "Publicar";
            this.PublicarPregunta.UseVisualStyleBackColor = false;
            this.PublicarPregunta.Click += new System.EventHandler(this.PublicarPregunta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dudas?";
            // 
            // ContenidoAPublicar
            // 
            this.ContenidoAPublicar.Location = new System.Drawing.Point(24, 39);
            this.ContenidoAPublicar.Name = "ContenidoAPublicar";
            this.ContenidoAPublicar.Size = new System.Drawing.Size(473, 44);
            this.ContenidoAPublicar.TabIndex = 0;
            this.ContenidoAPublicar.Text = "";
            // 
            // ListaGrupos
            // 
            this.ListaGrupos.BackColor = System.Drawing.Color.Linen;
            this.ListaGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaGrupos.ForeColor = System.Drawing.Color.Maroon;
            this.ListaGrupos.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.ListaGrupos.Location = new System.Drawing.Point(716, 84);
            this.ListaGrupos.Name = "ListaGrupos";
            this.ListaGrupos.Size = new System.Drawing.Size(126, 197);
            this.ListaGrupos.TabIndex = 2;
            this.ListaGrupos.UseCompatibleStateImageBehavior = false;
            this.ListaGrupos.View = System.Windows.Forms.View.SmallIcon;
            this.ListaGrupos.SelectedIndexChanged += new System.EventHandler(this.frmPrincipal_Load);
            this.ListaGrupos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListaGrupos_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(716, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grupos";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(769, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 23);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(885, 448);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListaGrupos);
            this.Controls.Add(this.GBMuro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Orange Chat";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.GBMuro.ResumeLayout(false);
            this.GBMuro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBMuro;
        private System.Windows.Forms.Button PublicarPregunta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ContenidoAPublicar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView ListaGrupos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}