using Klijent.Bibliotekar;
using Klijent.Bibliotekar.Kontroler;
using Klijent.Bibliotekar.Kontroler.KontroleriUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public class Koordinator
    {
        private static Koordinator instance;
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }
        
        }

        private Koordinator()
        {
            loginKontroler = new LoginKontroler();
            bibliotekarKontroler = new BibliotekarKontroler();

            //inicijalizacija kontrolera za bibliotekara
            kontrolerUCHome = new KontrolerUCHome();
            kontrolerUCDodajKnjigu = new KontrolerUCDodajKnjigu();
            kontrolerUCIzmeniKnjigu = new KontrolerUCIzmeniKnjigu();
            kontrolerUCClanovi = new KontrolerUCClanovi();
            kontrolerUCProfil = new KontrolerUCProfil();
            kontrolerUCPristigleRez = new KontrolerUCPristigleRez();
            kontrolerUCObradjeneRez = new KontrolerUCObradjeneRez();

            //inicijalizacija kontrolera za clana
        }

        private LoginKontroler loginKontroler;
        private BibliotekarKontroler bibliotekarKontroler;

        //kontroleri za bibliotekara
        private KontrolerUCHome kontrolerUCHome;
        private KontrolerUCDodajKnjigu kontrolerUCDodajKnjigu;
        private KontrolerUCIzmeniKnjigu kontrolerUCIzmeniKnjigu;
        private KontrolerUCClanovi kontrolerUCClanovi;
        private KontrolerUCProfil kontrolerUCProfil;
        private KontrolerUCPristigleRez kontrolerUCPristigleRez;
        private KontrolerUCObradjeneRez kontrolerUCObradjeneRez;


        //kontroleri za clana


        public void OtvoriLoginFormu()
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
            }catch(Exception e)
            {
                MessageBox.Show("Nije uspelo povezivanje sa serverom");
                return;
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frmLogin = loginKontroler.NapraviFrmLogin();
            frmLogin.AutoSize = true;
            Application.Run(frmLogin);
        }

        public void OtvoriBibliotekarFormu()
        {
            bibliotekarKontroler.Bibliotekar = Session.Session.Instance.Bibliotekar;
            FrmBibliotekar frmBibliotekar = bibliotekarKontroler.NapraviBibliotekarFormu();
            frmBibliotekar.ShowDialog();
        }
        public void OtvoriClanFormu()
        {
            
        }

        //metode za otvaranje UC za bibliotekara

        internal void OtvoriUCHome(BibliotekarKontroler bibliotekarKontroler)
        {
            bibliotekarKontroler.FrmBibliotekar.SetPanel(kontrolerUCHome.NapraviUCHome(bibliotekarKontroler.Bibliotekar));
        }

        internal void OtvoriUCDodajKnjigu(BibliotekarKontroler bibliotekarKontroler)
        {
            bibliotekarKontroler.FrmBibliotekar.SetPanel(kontrolerUCDodajKnjigu.NapraviUCDodajKnjigu(bibliotekarKontroler.Bibliotekar));
        }

        internal void OtvoriUCIzmeniKnjigu(BibliotekarKontroler bibliotekarKontroler)
        {
            bibliotekarKontroler.FrmBibliotekar.SetPanel(kontrolerUCIzmeniKnjigu.NapraviUCIzmeniKnjigu(bibliotekarKontroler.Bibliotekar));
        }

        internal void OtvoriUCClanovi(BibliotekarKontroler bibliotekarKontroler)
        {
            bibliotekarKontroler.FrmBibliotekar.SetPanel(kontrolerUCClanovi.NapraviUCClanovi(bibliotekarKontroler.Bibliotekar));
        }

        internal void OtvoriUCProfil(BibliotekarKontroler bibliotekarKontroler)
        {
            bibliotekarKontroler.FrmBibliotekar.SetPanel(kontrolerUCProfil.NapraviUCProfil(bibliotekarKontroler.Bibliotekar));
        }

        internal void OtvoriUCPristigleRez(BibliotekarKontroler bibliotekarKontroler)
        {
            bibliotekarKontroler.FrmBibliotekar.SetPanel(kontrolerUCPristigleRez.NapraviUCPristigleRez(bibliotekarKontroler.Bibliotekar));
        }

        internal void OtvoriUCObradjeneRezervacije(BibliotekarKontroler bibliotekarKontroler)
        {
            bibliotekarKontroler.FrmBibliotekar.SetPanel(kontrolerUCObradjeneRez.NapraviUCObradjeneRez(bibliotekarKontroler.Bibliotekar));
        }

        //metode za otvaranje UC za clana

    }
}
