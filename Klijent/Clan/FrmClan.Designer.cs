namespace Klijent.Clan
{
    partial class FrmClan
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreiranjeRezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bibliotekeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mojaBibliotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sveBibliotekeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjaviSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mojeBibliotekeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.rezervacijeToolStripMenuItem,
            this.profilToolStripMenuItem,
            this.bibliotekeToolStripMenuItem,
            this.odjaviSeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1540, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // rezervacijeToolStripMenuItem
            // 
            this.rezervacijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem,
            this.kreiranjeRezervacijeToolStripMenuItem});
            this.rezervacijeToolStripMenuItem.Name = "rezervacijeToolStripMenuItem";
            this.rezervacijeToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.rezervacijeToolStripMenuItem.Text = "Rezervacije";
            // 
            // pregledToolStripMenuItem
            // 
            this.pregledToolStripMenuItem.Name = "pregledToolStripMenuItem";
            this.pregledToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.pregledToolStripMenuItem.Text = "Pregled rezervacija";
            // 
            // kreiranjeRezervacijeToolStripMenuItem
            // 
            this.kreiranjeRezervacijeToolStripMenuItem.Name = "kreiranjeRezervacijeToolStripMenuItem";
            this.kreiranjeRezervacijeToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.kreiranjeRezervacijeToolStripMenuItem.Text = "Kreiranje rezervacije";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // bibliotekeToolStripMenuItem
            // 
            this.bibliotekeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mojaBibliotekaToolStripMenuItem,
            this.sveBibliotekeToolStripMenuItem,
            this.mojeBibliotekeToolStripMenuItem});
            this.bibliotekeToolStripMenuItem.Name = "bibliotekeToolStripMenuItem";
            this.bibliotekeToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.bibliotekeToolStripMenuItem.Text = "Biblioteke";
            // 
            // mojaBibliotekaToolStripMenuItem
            // 
            this.mojaBibliotekaToolStripMenuItem.Name = "mojaBibliotekaToolStripMenuItem";
            this.mojaBibliotekaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mojaBibliotekaToolStripMenuItem.Text = "Moja biblioteka";
            // 
            // sveBibliotekeToolStripMenuItem
            // 
            this.sveBibliotekeToolStripMenuItem.Name = "sveBibliotekeToolStripMenuItem";
            this.sveBibliotekeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sveBibliotekeToolStripMenuItem.Text = "Sve biblioteke";
            // 
            // odjaviSeToolStripMenuItem
            // 
            this.odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            this.odjaviSeToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.odjaviSeToolStripMenuItem.Text = "Odjavi se";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 684);
            this.panel1.TabIndex = 1;
            // 
            // mojeBibliotekeToolStripMenuItem
            // 
            this.mojeBibliotekeToolStripMenuItem.Name = "mojeBibliotekeToolStripMenuItem";
            this.mojeBibliotekeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mojeBibliotekeToolStripMenuItem.Text = "Moje biblioteke";
            // 
            // FrmClan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 712);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmClan";
            this.Text = "Clan";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        public System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem rezervacijeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem bibliotekeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem odjaviSeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem mojaBibliotekaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem sveBibliotekeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem kreiranjeRezervacijeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem mojeBibliotekeToolStripMenuItem;
    }
}