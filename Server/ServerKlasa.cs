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
using Newtonsoft.Json;

namespace Server
{
    /// <summary>
    /// Klasa zaduzena prvenstveno za primanje klijentskih zahteva za povezivanje na sistem i obradu zahteva za prijavu.
    /// </summary>
    public class ServerKlasa
    {
        /// <summary>
        /// Soket koji se koristi za osluskivanje klijentskih zahteva.
        /// </summary>
        private Socket osluskujuciSoket;

        /// <summary>
        /// Polje koje oznacava da li je kraj sa radom servera;
        /// </summary>
        bool kraj;

        /// <summary>
        /// Clanovi koji su povezani na sistem tipa Clan.
        /// </summary>
        private BindingList<Clan> clanovi = new BindingList<Clan>();

        /// <summary>
        /// Bibliotekrai koji su povezani na sistem tipa Bibliotekar.
        /// </summary>
        private BindingList<Bibliotekar> bibliotekari = new BindingList<Bibliotekar>();

        /// <summary>
        /// Polje za slanje odgovora ka klijentu.
        /// </summary>
        private Sender sender;

        /// <summary>
        /// Polje za primanje zahteva od klijenta.
        /// </summary>
        private Receiver receiver;

        /// <summary>
        /// Trenutno prijavljeni korisnik.
        /// </summary>
        private IEntitet prijavljeniKorisnik = null;

        /// <summary>
        /// Niti clanova koji su povezani na sistem.
        /// </summary>
        private List<ClanObrada> klijentiClanovi = new List<ClanObrada>();

        /// <summary>
        /// Niti bibliotekara koji su povezani na sistem.
        /// </summary>
        private List<BibliotekarObrada> klijentiBibliotekari = new List<BibliotekarObrada>();

        /// <summary>
        /// Getter za vracanje liste bibliotekara.
        /// </summary>
        public BindingList<Bibliotekar> Bibliotekari
        {
            get { return bibliotekari; }
        }

        /// <summary>
        /// Getter za vracanje liste clanova.
        /// </summary>
        public BindingList<Clan> Clanovi
        {
            get { return clanovi; }
        }

        /// <summary>
        /// Postavlja osluskujuci soket na odgovarajuci IPEndPoint sa adresom i portom. Nakon toga soket pocinje sa osluskivanjem.
        /// </summary>
        internal void PoveziSe()
        {
            osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000));
            osluskujuciSoket.Listen(10);
        }

        /// <summary>
        /// Sluzi za primanje klijentskih zahteva za povezivanje na sistem. Vrsi se prijava na sistem i nakon toga obradjuje proveru da li je korisnik koji se upravo prijavio clan ili bibliotekar i zavisnosti od toga pokrece se odgovarajuca nit za obradu klijentskih zahteva.
        /// </summary>
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

        /// <summary>
        /// Metoda koja vrsi obradu prijave na sistem.
        /// </summary>
        private void ObradiPrijavu()
        {
            Zahtev zahtev = (Zahtev)receiver.Primi();
            List<IEntitet> entitetiZaProveru = (List<IEntitet>)zahtev.Objekat;
            prijavljeniKorisnik = Kontroler.Kontroler.Instance.Login(entitetiZaProveru);
            Odgovor odgovor = new Odgovor { Rezultat = prijavljeniKorisnik };

            //serijalizacija objekta u json-u
            string jsonStr = JsonConvert.SerializeObject(odgovor.Rezultat);
            Console.WriteLine(jsonStr);

            sender.Posalji(odgovor);
        }

        /// <summary>
        /// Nakon prekida rada servera sve niti bez obzira da li su clanske ili bibliotekarske prestaju sa radom i sam soket staje sa osluskivanjem.
        /// </summary>
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
