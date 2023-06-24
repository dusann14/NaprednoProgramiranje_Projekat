using Common.Domen;
using Common.Transfer;
using Klijent.Bibliotekar.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Bibliotekar.Kontroler.KontroleriUC
{
    public class KontrolerUCClanovi
    {
        public UCClanovi UCClanovi { get; set; }

        internal UserControl NapraviUCClanovi(Common.Domen.Bibliotekar bibliotekar)
        {
            UCClanovi = new UCClanovi();
            UCClanovi.textBox1.TextChanged += (s, e) => PronadjiClanove(bibliotekar.Biblioteka);
            UCClanovi.dataGridView1.DataSource = VratiClanove(bibliotekar.Biblioteka);
            return UCClanovi;
        }

        internal void PronadjiClanove(Biblioteka biblioteka)
        {
            UCClanovi.dataGridView1.DataSource = VratiClanovePoImenu(biblioteka);
        }

        private List<ClanBiblioteka> VratiClanovePoImenu(Biblioteka biblioteka)
        {
            Common.Domen.Clan clan = new Common.Domen.Clan
            {
                ImePrezime = UCClanovi.textBox1.Text
            };

            Odgovor o = Komunikacija.Instance.VratiClanovePoImenu(clan, biblioteka);

            List<ClanBiblioteka> clanovi = (List<ClanBiblioteka>)o.Rezultat;

            if (clanovi.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da nadje clanove po zadatoj vrednosti");
            }

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return clanovi;
        }

        private List<ClanBiblioteka> VratiClanove(Biblioteka biblioteka)
        {
            Odgovor o = Komunikacija.Instance.VratiClanove(biblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<ClanBiblioteka>)o.Rezultat;
        }
    }
}
