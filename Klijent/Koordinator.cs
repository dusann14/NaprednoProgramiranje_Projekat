using Klijent.Bibliotekar;
using Klijent.Bibliotekar.Kontroler;
using Klijent.Bibliotekar.Kontroler.KontroleriUC;
using Klijent.Clan.Kontroler;
using Klijent.Clan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klijent.Clan.Kontroler.KontroleriUC;

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
            clanKontroler = new ClanKontroler();

            //inicijalizacija kontrolera za bibliotekara
            kontrolerUCHome = new KontrolerUCHome();
            kontrolerUCDodajKnjigu = new KontrolerUCDodajKnjigu();
            kontrolerUCIzmeniKnjigu = new KontrolerUCIzmeniKnjigu();
            kontrolerUCClanovi = new KontrolerUCClanovi();
            kontrolerUCProfil = new KontrolerUCProfil();
            kontrolerUCPristigleRez = new KontrolerUCPristigleRez();
            kontrolerUCObradjeneRez = new KontrolerUCObradjeneRez();

            //inicijalizacija kontrolera za clana
            kontrolerUCBiranjeB = new KontrolerUCBiranjeBiblioteke();
            kontrolerUCHomeClan = new KontrolerUCHomeClan();
            kontrolerUCUclanjivanje = new KontrolerUCUclanjivanje();
            kontrolerUCProfilClan = new KontrolerUCProfilClan();
            kontrolerUCBiblioteka = new KontrolerUCBiblioteka();
            kontrolerUCRezervacije = new KontrolerUCRezervacije();
            kontrolerUCKreiranjeRez = new KontrolerUCKreiranjeRez();
        }

        private LoginKontroler loginKontroler;
        private BibliotekarKontroler bibliotekarKontroler;
        private ClanKontroler clanKontroler;

        //kontroleri za bibliotekara
        private KontrolerUCHome kontrolerUCHome;
        private KontrolerUCDodajKnjigu kontrolerUCDodajKnjigu;
        private KontrolerUCIzmeniKnjigu kontrolerUCIzmeniKnjigu;
        private KontrolerUCClanovi kontrolerUCClanovi;
        private KontrolerUCProfil kontrolerUCProfil;
        private KontrolerUCPristigleRez kontrolerUCPristigleRez;
        private KontrolerUCObradjeneRez kontrolerUCObradjeneRez;


        //kontroleri za clana
        private KontrolerUCBiranjeBiblioteke kontrolerUCBiranjeB;
        private KontrolerUCHomeClan kontrolerUCHomeClan;
        private KontrolerUCUclanjivanje kontrolerUCUclanjivanje;
        private KontrolerUCProfilClan kontrolerUCProfilClan;
        private KontrolerUCBiblioteka kontrolerUCBiblioteka;
        private KontrolerUCRezervacije kontrolerUCRezervacije;
        private KontrolerUCKreiranjeRez kontrolerUCKreiranjeRez;

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
            clanKontroler.Clan = Session.Session.Instance.Clan;
            FrmClan frmClan = clanKontroler.NapraviClanFormu();
            frmClan.ShowDialog();
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
        internal void OtvoriUCBiranjeBiblioteke(ClanKontroler clanKontroler)
        {
            clanKontroler.FrmClan.SetPanel(kontrolerUCBiranjeB.NapraviUCBiranjeBiblioteke(clanKontroler));
        }

        internal void OtvoriUCHomeClan(ClanKontroler clanKontroler)
        {
            clanKontroler.FrmClan.SetPanel(kontrolerUCHomeClan.NapraviUCHome(clanKontroler));
        }

        internal void OtvoriUCUclanjivanje(ClanKontroler clanKontroler)
        {
            clanKontroler.FrmClan.SetPanel(kontrolerUCUclanjivanje.NapraviUCUclanjivanje(clanKontroler));
        }

        internal void OtvoriUCProfilClan(ClanKontroler clanKontroler)
        {
            clanKontroler.FrmClan.SetPanel(kontrolerUCProfilClan.NapraviUCProfil(clanKontroler));
        }

        internal void OtvoriUCBiblioteka(ClanKontroler clanKontroler)
        {
            clanKontroler.FrmClan.SetPanel(kontrolerUCBiblioteka.NapraviUCBiblioteka(clanKontroler));
        }

        internal void OtvoriUCRezervacije(ClanKontroler clanKontroler)
        {
            clanKontroler.FrmClan.SetPanel(kontrolerUCRezervacije.NapraviUCRezervacije(clanKontroler));
        }

        internal void OtvoriUCKreiranjeRezervacije(ClanKontroler clanKontroler)
        {
            clanKontroler.FrmClan.SetPanel(kontrolerUCKreiranjeRez.NapraviUCKreiranjeRezervacije(clanKontroler));
        }
    }
}
