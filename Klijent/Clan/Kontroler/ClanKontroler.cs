using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler
{
    public class ClanKontroler
    {
        public FrmClan FrmClan { get; set; }
        public Common.Domen.Clan Clan { get; set; }

        public List<Biblioteka> BibliotekeClana { get; set; }

        public Biblioteka IzabranaBiblioteka { get; set; }

        public FrmClan NapraviClanFormu()
        {
            FrmClan = new FrmClan();
            FrmClan.homeToolStripMenuItem.Click += (s, e) => Koordinator.Instance.OtvoriUCHomeClan(this);
            FrmClan.pregledToolStripMenuItem.Click += (s, e) => Koordinator.Instance.OtvoriUCRezervacije(this);
            FrmClan.kreiranjeRezervacijeToolStripMenuItem.Click += (s, e) => Koordinator.Instance.OtvoriUCKreiranjeRezervacije(this);
            FrmClan.profilToolStripMenuItem.Click += (s, e) => Koordinator.Instance.OtvoriUCProfilClan(this);
            FrmClan.mojaBibliotekaToolStripMenuItem.Click += (s, e) => Koordinator.Instance.OtvoriUCBiblioteka(this);
            FrmClan.sveBibliotekeToolStripMenuItem.Click += (s, e) => Koordinator.Instance.OtvoriUCUclanjivanje(this);
            FrmClan.mojeBibliotekeToolStripMenuItem.Click += (s, e) => Koordinator.Instance.OtvoriUCBiranjeBiblioteke(this);
            FrmClan.odjaviSeToolStripMenuItem.Click += (s, e) => OdjaviSe();
            FrmClan.FormClosed += (s, e) => OdjaviSe();
            return FrmClan;
        }

        private void PostaviOdgovarajucuUC()
        {
            BibliotekeClana = Komunikacija.Instance.VratiBibliotekeClana(Clan);

            if (BibliotekeClana.Count > 1)
            {
                Koordinator.Instance.OtvoriUCBiranjeBiblioteke(this);
                FrmClan.menuStrip1.Visible = false;
            }
            else if (BibliotekeClana.Count == 1)
            {
                IzabranaBiblioteka = BibliotekeClana[0];
                Koordinator.Instance.OtvoriUCHomeClan(this);
            }
            else if (BibliotekeClana.Count == 0)
            {
                Koordinator.Instance.OtvoriUCUclanjivanje(this);
                FrmClan.menuStrip1.Visible = false;
            }
        }

        internal void OdjaviSe()
        {
            try
            {
                Komunikacija.Instance.OdjaviSe(Clan);
                MessageBox.Show("Uspesno ste se odjavili");
                FrmClan.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
