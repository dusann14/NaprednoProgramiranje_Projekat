using Common.Domen;
using Common.Transfer;
using Klijent.Bibliotekar.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Bibliotekar.Kontroler.KontroleriUC
{
    public class KontrolerUCDodajKnjigu
    {
        public UCDodajKnjigu UCDodajKnjigu { get; set; }

        internal UserControl NapraviUCDodajKnjigu(Common.Domen.Bibliotekar bibliotekar)
        {
            UCDodajKnjigu = new UCDodajKnjigu();
            UCDodajKnjigu.textBox1.Validating += TextBox1_Validating;
            UCDodajKnjigu.textBox2.Validating += TextBox2_Validating;
            UCDodajKnjigu.button1.Click += (s, e) => DodajKnjigu(bibliotekar);
            UCDodajKnjigu.comboBox1.DataSource = VratiAutore(bibliotekar.Biblioteka);
            return UCDodajKnjigu;
        }

        private void TextBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCDodajKnjigu.textBox2.Text))
            {
                e.Cancel = true;
                UCDodajKnjigu.errorProvider1.SetError(UCDodajKnjigu.textBox2, "Niste uneli broj primeraka");
            }
            else if (!new Regex(@"^\d+$").IsMatch(UCDodajKnjigu.textBox2.Text))
            {
                e.Cancel = true;
                UCDodajKnjigu.errorProvider1.SetError(UCDodajKnjigu.textBox2, "Broj primeraka mora biti broj");
            }
            else
            {
                e.Cancel = false;
                UCDodajKnjigu.errorProvider1.SetError(UCDodajKnjigu.textBox2, null);
            }
        }

        private void TextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCDodajKnjigu.textBox1.Text))
            {
                e.Cancel = true;
                UCDodajKnjigu.errorProvider1.SetError(UCDodajKnjigu.textBox1, "Niste uneli naslov knjige");
            }
            else
            {
                e.Cancel = false;
                UCDodajKnjigu.errorProvider1.SetError(UCDodajKnjigu.textBox1, null);
            }
        }

        internal void DodajKnjigu(Common.Domen.Bibliotekar bibliotekar)
        {

            Knjiga knjiga = new Knjiga
            {
                Naslov = UCDodajKnjigu.textBox1.Text,
                BrojPrimeraka = Int32.Parse(UCDodajKnjigu.textBox2.Text),
                Autor = (Autor)UCDodajKnjigu.comboBox1.SelectedItem,
                Biblioteka = bibliotekar.Biblioteka
            };

            Odgovor o = Komunikacija.Instance.DodajKnjigu(knjiga);

            if (!o.Uspesno)
            {
                MessageBox.Show($"Sistem ne moze da zapamti knjigu: {o.Greska}");
                return;
            }

            MessageBox.Show("Sistem je zapamtio knjigu");
        }


        internal List<Autor> VratiAutore(Biblioteka biblioteka)
        {
            Odgovor o = Komunikacija.Instance.VratiAutore(biblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<Autor>)o.Rezultat;
        }
    }
}
