using Common.Domen;
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
    public class KontrolerUCKreiranjeRez
    {
        public UCKreiranjeRezervacije UCKreiranjeRezervacije { get; set; }

        internal UserControl NapraviUCKreiranjeRezervacije(ClanKontroler clanKontroler)
        {
            UCKreiranjeRezervacije = new UCKreiranjeRezervacije();
            UCKreiranjeRezervacije.textBox2.TextChanged += (s, e) => VratiKnjigePoNaslovu(clanKontroler.IzabranaBiblioteka);
            UCKreiranjeRezervacije.button1.Click += (s, e) => KreirajRezervaciju(clanKontroler);
            UCKreiranjeRezervacije.dataGridView1.DataSource = VratiKnjigeIzBiblioteke(clanKontroler.IzabranaBiblioteka);

            return UCKreiranjeRezervacije;
        }

        private void VratiKnjigePoNaslovu(Biblioteka izabranaBiblioteka)
        {
            Knjiga knjiga = new Knjiga
            {
                Naslov = UCKreiranjeRezervacije.textBox2.Text,
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

            UCKreiranjeRezervacije.dataGridView1.DataSource = (List<Knjiga>)o.Rezultat;
        }

        private void KreirajRezervaciju(ClanKontroler clanKontroler)
        {
            if (UCKreiranjeRezervacije.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali knjigu");
                return;
            }

            List<Stavka> stavke = new List<Stavka>();


            Rezervacija rezervacija = new Rezervacija
            {
                DatumTrajanja = DateTime.Now.AddMonths(1),
                Biblioteka = clanKontroler.IzabranaBiblioteka,
                Clan = clanKontroler.Clan,
                Status = StatusRezervacije.NEOBRADJENA
            };

            for (int i = 0; i < UCKreiranjeRezervacije.dataGridView1.SelectedRows.Count; i++)
            {
                Knjiga knjiga = (Knjiga)UCKreiranjeRezervacije.dataGridView1.SelectedRows[i].DataBoundItem;
                stavke.Add(new Stavka
                {
                    Knjiga = knjiga,
                    Rezervacija = rezervacija
                });
            }

            rezervacija.Stavke = stavke;

            Odgovor o = Komunikacija.Instance.KreirajRezervaciju(rezervacija);

            if (!o.Uspesno)
            {
                MessageBox.Show($"Sistem ne moze da zapamti rezervaciju: {o.Greska}");
            }

            MessageBox.Show("Sistem je zapamtio rezervaciju");

            PromeniBrojKnjiga(stavke);

            UCKreiranjeRezervacije.dataGridView1.DataSource = VratiKnjigeIzBiblioteke(clanKontroler.IzabranaBiblioteka);
        }

        private void PromeniBrojKnjiga(List<Stavka> stavke)
        {
            foreach (Stavka stavkeItem in stavke)
            {
                Knjiga k = stavkeItem.Knjiga;
                k.BrojPrimeraka -= 1;
                Komunikacija.Instance.IzmeniKnjigu(k);
            }
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
