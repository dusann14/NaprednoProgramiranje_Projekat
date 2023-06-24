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
    public class KontrolerUCIzmeniKnjigu
    {
        public UCIzmeniKnjigu UCIzmeniKnjigu { get; set; }
        public Knjiga Knjiga { get; set; }

        public List<Knjiga> IzmenjeneKnjige { get; set; }

        internal UserControl NapraviUCIzmeniKnjigu(Common.Domen.Bibliotekar bibliotekar)
        {
            UCIzmeniKnjigu = new UCIzmeniKnjigu();
            IzmenjeneKnjige = new List<Knjiga>();
            UCIzmeniKnjigu.textBox5.TextChanged += (s, e) => VratiKnjigePoNaslovu(bibliotekar.Biblioteka);
            UCIzmeniKnjigu.textBox4.TextChanged += (s, e) => VratiKnjigePoAutoru(bibliotekar);
            UCIzmeniKnjigu.button1.Click += (s, e) => SacuvajIzmene(bibliotekar.Biblioteka);
            UCIzmeniKnjigu.dataGridView1.CellEndEdit += (s, e) => DodajUListu(e);
            UCIzmeniKnjigu.dataGridView1.DataSource = VratiKnjige(bibliotekar.Biblioteka);
            return UCIzmeniKnjigu;
        }

        private void DodajUListu(DataGridViewCellEventArgs e)
        {
            Knjiga knjiga = (Knjiga)UCIzmeniKnjigu.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            IzmenjeneKnjige.Add(knjiga);
        }

        private void VratiKnjigePoNaslovu(Biblioteka biblioteka)
        {
            Knjiga knjiga = new Knjiga
            {
                Naslov = UCIzmeniKnjigu.textBox5.Text,
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

            UCIzmeniKnjigu.dataGridView1.DataSource = (List<Knjiga>)o.Rezultat;
        }

        private void VratiKnjigePoAutoru(Common.Domen.Bibliotekar bibliotekar)
        {
            Autor autor = new Autor { ImePrezime = UCIzmeniKnjigu.textBox4.Text };
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

            UCIzmeniKnjigu.dataGridView1.DataSource = (List<Knjiga>)o.Rezultat;
        }

        internal void SacuvajIzmene(Biblioteka biblioteka)
        {

            if (IzmenjeneKnjige.Count == 0)
            {
                MessageBox.Show("Niste izmenili nijednu knjigu");
                return;
            }


            foreach (Knjiga knjiga in IzmenjeneKnjige)
            {
                Odgovor o = Komunikacija.Instance.IzmeniKnjigu(knjiga);
                if (!o.Uspesno)
                {
                    MessageBox.Show($"Sistem ne moze da zapamti knjige: {o.Greska}");
                    return;
                }
            }

            MessageBox.Show("Sistem je zapamtio knjige");
        }

        internal List<Knjiga> VratiKnjige(Biblioteka biblioteka)
        {
            Odgovor o = Komunikacija.Instance.VratiKnjige(biblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<Knjiga>)o.Rezultat;
        }

    }
}
