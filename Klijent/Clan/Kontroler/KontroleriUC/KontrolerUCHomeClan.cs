using Common.Domen;
using Common.Transfer;
using Klijent.Bibliotekar.UserControls;
using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCHomeClan
    {
        public UCHomeClan UCHome { get; set; }

        internal UserControl NapraviUCHome(ClanKontroler clanKontroler)
        {
            UCHome = new UCHomeClan();
            UCHome.textBox1.TextChanged += (s, e) => VratiKnjigePoAutoru(clanKontroler.IzabranaBiblioteka);
            UCHome.textBox2.TextChanged += (s, e) => VratiKnjigePoNaslovu(clanKontroler.IzabranaBiblioteka);
            UCHome.label1.Text = $"DOBRODOSLI {clanKontroler.Clan.KorisnickoIme}";
            UCHome.dataGridView1.DataSource = VratiKnjigeIzBiblioteke(clanKontroler.IzabranaBiblioteka);
            return UCHome;
        }

        private void VratiKnjigePoNaslovu(Biblioteka izabranaBiblioteka)
        {
            Knjiga knjiga = new Knjiga
            {
                Naslov = UCHome.textBox2.Text,
                Biblioteka = izabranaBiblioteka
            };

            Odgovor o = Komunikacija.Instance.VratiKnjigePoNaslovu(knjiga);

            List<Knjiga> list = (List<Knjiga>)o.Rezultat;

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return;
            }

            if (list.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da pronadje knjige po zadatoj vrednosti");
                return;
            }

            UCHome.dataGridView1.DataSource = list;
        }

        private void VratiKnjigePoAutoru(Biblioteka izabranaBiblioteka)
        {
            Autor autor = new Autor
            {
                ImePrezime = UCHome.textBox1.Text
            };
            Odgovor o = Komunikacija.Instance.VratiKnjigePoAutoru(autor, izabranaBiblioteka);

            List<Knjiga> list = (List<Knjiga>)o.Rezultat;

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return;
            }

            if (list.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da pronadje knjige po zadatoj vrednosti");
                return;
            }

            UCHome.dataGridView1.DataSource = list;
        }

        private List<Knjiga> VratiKnjigeIzBiblioteke(Biblioteka izabranaBiblioteka)
        {
            Odgovor o = Komunikacija.Instance.VratiKnjige(izabranaBiblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<Knjiga>)o.Rezultat;
        }

    }
}
