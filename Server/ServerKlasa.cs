using Common.Domen;
using Common.Transfer;
using Server.Obrada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerKlasa
    {
        private Socket osluskujuciSoket;
        bool kraj;
        private BindingList<Clan> clanovi = new BindingList<Clan>();
        private BindingList<Bibliotekar> bibliotekari = new BindingList<Bibliotekar>();
        private Sender sender;
        private Receiver receiver;
        private IEntitet prijavljeniKorisnik = null;

        private List<ClanObrada> klijentiClanovi = new List<ClanObrada>();
        private List<BibliotekarObrada> klijentiBibliotekari = new List<BibliotekarObrada>();

        public BindingList<Bibliotekar> Bibliotekari
        {
            get { return bibliotekari; }
        }

        public BindingList<Clan> Clanovi
        {
            get { return clanovi; }
        }

        internal void PoveziSe()
        {
            osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000));
            osluskujuciSoket.Listen(10);
        }

        internal void Osluskuj()
        {
            try
            {
                kraj = false;
                while (!kraj)
                {
                    Socket klijentskiSoket = osluskujuciSoket.Accept();
                    sender = new Sender(klijentskiSoket);
                    receiver = new Receiver(klijentskiSoket);

                    while (prijavljeniKorisnik == null)
                    {
                        ObradiPrijavu();
                    }

                    if (prijavljeniKorisnik is Clan)
                    {
                        Clan c = (Clan)prijavljeniKorisnik;
                        c.Prijavljen = true;
                        c.Uslov = $"IDClan = {c.IDClan}";
                        clanovi.Add((Clan)prijavljeniKorisnik);
                        Kontroler.Kontroler.Instance.PromeniPodatkeClana(c);
                        ClanObrada clanObrada = new ClanObrada(klijentskiSoket, clanovi);
                        klijentiClanovi.Add(clanObrada);
                        Thread nitClan = new Thread(clanObrada.Obradi);
                        nitClan.IsBackground = true;
                        nitClan.Start();
                    }
                    else
                    {
                        Bibliotekar b = (Bibliotekar)prijavljeniKorisnik;
                        b.Prijavljen = true;
                        b.Uslov = $"IDBibliotekar = {b.IDBibliotekar}";
                        bibliotekari.Add(b);
                        Kontroler.Kontroler.Instance.PromeniPodatkeBibliotekara(b);
                        BibliotekarObrada bibliotekarObrada = new BibliotekarObrada(klijentskiSoket, bibliotekari);
                        klijentiBibliotekari.Add(bibliotekarObrada);
                        Thread nitBibliotekar = new Thread(bibliotekarObrada.Obradi);
                        nitBibliotekar.IsBackground = true;
                        nitBibliotekar.Start();
                    }
                    prijavljeniKorisnik = null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("<<<<<" + e.Message);
            }
        }

        private void ObradiPrijavu()
        {
            Zahtev zahtev = (Zahtev)receiver.Primi();
            List<IEntitet> entitetiZaProveru = (List<IEntitet>)zahtev.Objekat;
            prijavljeniKorisnik = Kontroler.Kontroler.Instance.Login(entitetiZaProveru);
            Odgovor odgovor = new Odgovor { Rezultat = prijavljeniKorisnik };
            sender.Posalji(odgovor);
        }

        internal void Stop()
        {
            kraj = true;

            foreach (ClanObrada c in klijentiClanovi)
            {
                c.Stop();
            }

            foreach (BibliotekarObrada b in klijentiBibliotekari)
            {
                b.Stop();
            }

            clanovi.Clear();
            bibliotekari.Clear();
            osluskujuciSoket.Dispose();
        }
    }
}
