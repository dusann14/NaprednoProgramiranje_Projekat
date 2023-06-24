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
    public class KontrolerUCHome
    {
        public UCHome UCHome { get; set; }

        internal UserControl NapraviUCHome(Common.Domen.Bibliotekar bibliotekar)
        {
            UCHome = new UCHome();
            UCHome.button2.Click += (s, e) => ObisiKnjigu(bibliotekar);
            UCHome.textBox2.TextChanged += (s, e) => VratiKnjigePoNaslovu(bibliotekar.Biblioteka);
            UCHome.textBox1.TextChanged += (s, e) => VratiKnjigePoAutoru(bibliotekar);
            UCHome.label1.Text = $"DOBRODOSLI {bibliotekar.KorisnickoIme}";
            UCHome.dataGridView1.DataSource = VratiKnjige(bibliotekar.Biblioteka);
            return UCHome;
        }

        private void VratiKnjigePoNaslovu(Biblioteka biblioteka)
        {
            Knjiga knjiga = new Knjiga
            {
                Naslov = UCHome.textBox2.Text,
                Biblioteka = biblioteka
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

        private void ObisiKnjigu(Common.Domen.Bibliotekar bibliotekar)
        {
            if (UCHome.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali knjigu za brisanje");
                return;
            }
            else if (UCHome.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Mozete izabrati samo jednu knjigu za brisanje");
                return;
            }

            Knjiga k = (Knjiga)UCHome.dataGridView1.SelectedRows[0].DataBoundItem;

            Odgovor o = Komunikacija.Instance.ObrisiKnjigu(k);

            if (!o.Uspesno)
            {
                MessageBox.Show($"Sistem ne moze da obrise knjigu {o.Greska}");
                return;
            }

            MessageBox.Show("Sistem je obrisao knjigu");
            UCHome.dataGridView1.DataSource = VratiKnjige(bibliotekar.Biblioteka);
        }

        private List<Knjiga> VratiKnjige(Biblioteka biblioteka)
        {
            Odgovor o = Komunikacija.Instance.VratiKnjige(biblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<Knjiga>)o.Rezultat;
        }

        private void VratiKnjigePoAutoru(Common.Domen.Bibliotekar bibliotekar)
        {
            Autor autor = new Autor { ImePrezime = UCHome.textBox1.Text };
            Odgovor o = Komunikacija.Instance.VratiKnjigePoAutoru(autor, bibliotekar.Biblioteka);

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

    }
}
