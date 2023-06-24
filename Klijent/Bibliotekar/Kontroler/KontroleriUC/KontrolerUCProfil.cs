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
    public class KontrolerUCProfil
    {
        public UCProfil UCProfil { get; set; }

        internal UserControl NapraviUCProfil(Common.Domen.Bibliotekar bibliotekar)
        {
            UCProfil = new UCProfil();
            UCProfil.button1.Click += (s, e) => PromeniPodatkeBibliotekara(bibliotekar);
            UCProfil.textBox1.Validating += TextBox1_Validating;
            UCProfil.textBox2.Validating += TextBox2_Validating;
            UCProfil.textBox4.Validating += TextBox4_Validating;
            UCProfil.textBox1.Text = bibliotekar.ImePrezime;
            UCProfil.textBox2.Text = bibliotekar.KorisnickoIme;
            UCProfil.textBox4.Text = bibliotekar.DatumRodjenja.ToString("yyyy-MM-dd"); ;
            UCProfil.textBox5.Text = bibliotekar.Biblioteka.Ime;
            return UCProfil;
        }

        private void TextBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCProfil.textBox4.Text) || !new Regex(@"^\d{4}-\d{2}-\d{2}$").IsMatch(UCProfil.textBox4.Text))
            {
                e.Cancel = true;
                UCProfil.errorProvider.SetError(UCProfil.textBox4, "Datum mora biti u formatu yyyy-MM-dd");
            }
            else
            {
                e.Cancel = false;
                UCProfil.errorProvider.SetError(UCProfil.textBox4, null);
            }
        }

        private void TextBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCProfil.textBox2.Text))
            {
                e.Cancel = true;
                UCProfil.errorProvider.SetError(UCProfil.textBox2, "Niste uneli korisnicko ime");
            }
            else
            {
                e.Cancel = false;
                UCProfil.errorProvider.SetError(UCProfil.textBox2, null);
            }
        }

        private void TextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UCProfil.textBox1.Text) || !new Regex(@"^[A-Za-z]+\s[A-Za-z]+$").IsMatch(UCProfil.textBox1.Text))
            {
                e.Cancel = true;
                UCProfil.errorProvider.SetError(UCProfil.textBox1, "Niste uneli dobro ime i prezime");
            }
            else
            {
                e.Cancel = false;
                UCProfil.errorProvider.SetError(UCProfil.textBox1, null);
            }
        }

        internal void PromeniPodatkeBibliotekara(Common.Domen.Bibliotekar bibliotekar)
        {
            bibliotekar.ImePrezime = UCProfil.textBox1.Text;
            bibliotekar.KorisnickoIme = UCProfil.textBox2.Text;
            bibliotekar.DatumRodjenja = DateTime.ParseExact(UCProfil.textBox4.Text, "yyyy-MM-dd", null);

            Odgovor o = Komunikacija.Instance.PromeniPodatkeBibliotekara(bibliotekar);

            if (!o.Uspesno)
            {
                MessageBox.Show($"Sistem ne moze da zapamti bibliotekara: {o.Greska}");
                return;
            }

            MessageBox.Show("Sistem je zapamtio bibliotekara");
        }
    }
}
