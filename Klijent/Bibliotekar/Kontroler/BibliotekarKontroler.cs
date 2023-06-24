using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Bibliotekar.Kontroler
{
    public class BibliotekarKontroler
    {
        public FrmBibliotekar FrmBibliotekar { get; set; }
        public Common.Domen.Bibliotekar  Bibliotekar { get; set; }

        public FrmBibliotekar NapraviBibliotekarFormu()
        {
            FrmBibliotekar = new FrmBibliotekar();
            Koordinator.Instance.OtvoriUCHome(this);
            FrmBibliotekar.FormClosed += (s, a) => OdjaviSe(s, a);
            FrmBibliotekar.homeToolStripMenuItem.Click += (s, a) => Koordinator.Instance.OtvoriUCHome(this);
            FrmBibliotekar.pristigleRezervacijeToolStripMenuItem.Click += (s, a) => Koordinator.Instance.OtvoriUCPristigleRez(this);
            FrmBibliotekar.obradjeneRezervacijeToolStripMenuItem.Click += (s, a) => Koordinator.Instance.OtvoriUCObradjeneRezervacije(this);
            FrmBibliotekar.dodajKnjiguToolStripMenuItem.Click += (s, a) => Koordinator.Instance.OtvoriUCDodajKnjigu(this);
            FrmBibliotekar.izmeniKnjiguToolStripMenuItem.Click += (s, a) => Koordinator.Instance.OtvoriUCIzmeniKnjigu(this);
            FrmBibliotekar.clanoviToolStripMenuItem.Click += (s, a) => Koordinator.Instance.OtvoriUCClanovi(this);
            FrmBibliotekar.profilToolStripMenuItem.Click += (s, a) => Koordinator.Instance.OtvoriUCProfil(this);
            FrmBibliotekar.odjaviSeToolStripMenuItem.Click += (s, a) => OdjaviSe(s, a);
            return FrmBibliotekar;
        }

        private void OdjaviSe(object s, EventArgs a)
        {
            try
            {
                Komunikacija.Instance.OdjaviSe(Bibliotekar);
                MessageBox.Show("Uspesno ste se odjavili");
                FrmBibliotekar.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
