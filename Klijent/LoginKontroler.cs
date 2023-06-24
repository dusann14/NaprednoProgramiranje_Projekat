using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Windows.Forms;
using Common.Transfer;
using Common.Domen;

namespace Klijent
{
    internal class LoginKontroler
    {
        public FrmLogin FrmLogin { get; set; }

        internal FrmLogin NapraviFrmLogin()
        {
            FrmLogin = new FrmLogin();
            FrmLogin.button1.Click += (s, a) => PrijaviSe(s, a);
            FrmLogin.FormClosed += (s, a) => Komunikacija.Instance.Disconnect();
            return FrmLogin;
        }

        internal void PrijaviSe(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FrmLogin.textBox1.Text))
            {
                MessageBox.Show("Niste uneli korisnicko ime");
                return;
            }
            if (String.IsNullOrEmpty(FrmLogin.textBox2.Text))
            {
                MessageBox.Show("Niste uneli lozinku");
                return;
            }
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PrijaviSe(FrmLogin.textBox1.Text, FrmLogin.textBox2.Text);
                IEntitet entitet = (IEntitet)odgovor.Rezultat;
                if (entitet == null)
                {
                    MessageBox.Show("Ne postoji korisnik sa unetim kredencijalima");
                    return;
                }
                else if (entitet is Clan)
                {
                    Session.Session.Instance.Clan = (Clan)entitet;
                    MessageBox.Show($"Dobrodosli {FrmLogin.textBox1.Text}");
                    Koordinator.Instance.OtvoriClanFormu();
                    FrmLogin.Dispose();
                }
                else if (entitet is Bibliotekar)
                {   
                    Session.Session.Instance.Bibliotekar = (Bibliotekar)entitet;
                    MessageBox.Show($"Dobrodosli {FrmLogin.textBox1.Text}");
                    Koordinator.Instance.OtvoriBibliotekarFormu();
                    FrmLogin.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }
    }
}
