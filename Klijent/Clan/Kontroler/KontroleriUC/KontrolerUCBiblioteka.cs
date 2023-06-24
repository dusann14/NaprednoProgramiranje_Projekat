using Common.Transfer;
using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCBiblioteka
    {
        public UCBiblioteka UCBiblioteka { get; set; }

        internal UserControl NapraviUCBiblioteka(ClanKontroler clanKontroler)
        {
            UCBiblioteka = new UCBiblioteka();
            UCBiblioteka.button1.Click += (s, e) => OtkaziClanstvo(clanKontroler);
            UCBiblioteka.label5.Text = clanKontroler.IzabranaBiblioteka.Ime;
            UCBiblioteka.label6.Text = clanKontroler.IzabranaBiblioteka.Adresa;
            return UCBiblioteka;
        }

        private void OtkaziClanstvo(ClanKontroler clanKontroler)
        {
            Odgovor o = Komunikacija.Instance.OtkaziClanstvo(clanKontroler.Clan, clanKontroler.IzabranaBiblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show($"Sistem ne moze da obrise clanstvo: {o.Greska}");
                return;
            }

            clanKontroler.BibliotekeClana.Remove(clanKontroler.IzabranaBiblioteka);
            clanKontroler.IzabranaBiblioteka = null;
            MessageBox.Show("Sistem je obrisao clanstvo");
            clanKontroler.FrmClan.menuStrip1.Visible = false;
            Koordinator.Instance.OtvoriUCBiranjeBiblioteke(clanKontroler);
        }


    }
}
