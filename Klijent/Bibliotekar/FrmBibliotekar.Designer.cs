namespace Klijent.Bibliotekar
{
    partial class FrmBibliotekar
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knjigaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKnjiguToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniKnjiguToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clanoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjaviSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pristigleRezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obradjeneRezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.rezervacijeToolStripMenuItem,
            this.knjigaToolStripMenuItem,
            this.clanoviToolStripMenuItem,
            this.profilToolStripMenuItem,
            this.odjaviSeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1558, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // knjigaToolStripMenuItem
            // 
            this.knjigaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajKnjiguToolStripMenuItem,
            this.izmeniKnjiguToolStripMenuItem});
            this.knjigaToolStripMenuItem.Name = "knjigaToolStripMenuItem";
            this.knjigaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.knjigaToolStripMenuItem.Text = "Knjiga";
            // 
            // dodajKnjiguToolStripMenuItem
            // 
            this.dodajKnjiguToolStripMenuItem.Name = "dodajKnjiguToolStripMenuItem";
            this.dodajKnjiguToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.dodajKnjiguToolStripMenuItem.Text = "Dodaj knjigu";
            // 
            // izmeniKnjiguToolStripMenuItem
            // 
            this.izmeniKnjiguToolStripMenuItem.Name = "izmeniKnjiguToolStripMenuItem";
            this.izmeniKnjiguToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.izmeniKnjiguToolStripMenuItem.Text = "Izmeni knjigu";
            // 
            // clanoviToolStripMenuItem
            // 
            this.clanoviToolStripMenuItem.Name = "clanoviToolStripMenuItem";
            this.clanoviToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.clanoviToolStripMenuItem.Text = "Clanovi";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // odjaviSeToolStripMenuItem
            // 
            this.odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            this.odjaviSeToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.odjaviSeToolStripMenuItem.Text = "Odjavi se";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1558, 759);
            this.panel1.TabIndex = 9;
            // 
            // rezervacijeToolStripMenuItem
            // 
            this.rezervacijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pristigleRezervacijeToolStripMenuItem,
            this.obradjeneRezervacijeToolStripMenuItem});
            this.rezervacijeToolStripMenuItem.Name = "rezervacijeToolStripMenuItem";
            this.rezervacijeToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.rezervacijeToolStripMenuItem.Text = "Rezervacije";
            // 
            // pristigleRezervacijeToolStripMenuItem
            // 
            this.pristigleRezervacijeToolStripMenuItem.Name = "pristigleRezervacijeToolStripMenuItem";
            this.pristigleRezervacijeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pristigleRezervacijeToolStripMenuItem.Text = "Pristigle ";
            // 
            // obradjeneRezervacijeToolStripMenuItem
            // 
            this.obradjeneRezervacijeToolStripMenuItem.Name = "obradjeneRezervacijeToolStripMenuItem";
            this.obradjeneRezervacijeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.obradjeneRezervacijeToolStripMenuItem.Text = "Obradjene ";
            // 
            // FrmBibliotekar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1558, 787);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmBibliotekar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bibliotekar";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem knjigaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem dodajKnjiguToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clanoviToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripMenuItem odjaviSeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem izmeniKnjiguToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervacijeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pristigleRezervacijeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem obradjeneRezervacijeToolStripMenuItem;
    }
}