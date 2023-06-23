using Common.Domen;
using Common.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instance;

        private Socket soket;
        private Receiver receiver;
        private Sender sender;

        public static Komunikacija Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }

        private Komunikacija()
        {

        }

        public void PoveziSe()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soket.Connect("127.0.0.1", 9000);
            receiver = new Receiver(soket);
            sender = new Sender(soket);
        }

        internal void Disconnect()
        {
            soket.Close();
            soket = null;
        }

        internal Odgovor PrijaviSe(string korisnickoIme, string lozinka)
        {

            List<IEntitet> entiteti = new List<IEntitet>();
            entiteti.Add(new Clan
            {
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                Uslov = $"KorisnickoIme = '{korisnickoIme}' and Lozinka = '{lozinka}'"
            });
            entiteti.Add(new Bibliotekar
            {
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                Uslov = $"bib.KorisnickoIme = '{korisnickoIme}' and bib.Lozinka = '{lozinka}'"
            });
            Zahtev zahtev = new Zahtev
            {
                Objekat = entiteti
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }


    }
}
