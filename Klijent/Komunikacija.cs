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
            entiteti.Add(new Common.Domen.Clan
            {
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                Uslov = $"KorisnickoIme = '{korisnickoIme}' and Lozinka = '{lozinka}'"
            });
            entiteti.Add(new Common.Domen.Bibliotekar
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

        internal Odgovor VratiClanove(Biblioteka biblioteka)
        {
            ClanBiblioteka cb = new ClanBiblioteka { Biblioteka = biblioteka };
            Zahtev zahtev = new Zahtev
            {
                Objekat = cb,
                Operacija = Operacije.PrikaziSveClanoveBiblioteke
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiClanovePoImenu(Common.Domen.Clan clan, Biblioteka biblioteka)
        {
            ClanBiblioteka cb = new ClanBiblioteka
            {
                Biblioteka = biblioteka,
                Clan = clan
            };
            Zahtev zahtev = new Zahtev
            {
                Objekat = cb,
                Operacija = Operacije.PrikaziClanovePoImenu
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiAutore(Biblioteka biblioteka)
        {
            Autor autor = new Autor { Biblioteka = biblioteka };
            Zahtev zahtev = new Zahtev { Objekat = autor, Operacija = Operacije.VratiAutore };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor DodajKnjigu(Knjiga k)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = k,
                Operacija = Operacije.DodajKnjigu,
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiKnjigePoNaslovu(Knjiga knjiga)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = knjiga,
                Operacija = Operacije.VratiKnjigePoNaslovu
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor ObrisiKnjigu(Knjiga k)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = k,
                Operacija = Operacije.ObrisiKnjigu,
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiKnjige(Biblioteka biblioteka)
        {
            Knjiga knjiga = new Knjiga { Biblioteka = biblioteka };
            Zahtev zahtev = new Zahtev { Objekat = knjiga, Operacija = Operacije.VratiKnjigeIzBiblioteke };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiKnjigePoAutoru(Autor autor, Biblioteka biblioteka)
        {
            Knjiga knjiga = new Knjiga { Autor = autor, Biblioteka = biblioteka };
            Zahtev zahtev = new Zahtev { Objekat = knjiga, Operacija = Operacije.VratiKnjigePoAutoru };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor IzmeniKnjigu(Knjiga k)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = k,
                Operacija = Operacije.PromeniKnjigu,
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiStavkeRezervacije(Rezervacija rezervacija)
        {
            Stavka stavka = new Stavka
            {
                Rezervacija = rezervacija
            };
            Zahtev zahtev = new Zahtev
            {
                Objekat = stavka,
                Operacija = Operacije.VratiStavkeRezervacije
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiObradjeneRezervacije(Biblioteka biblioteka)
        {
            Rezervacija rezervacija = new Rezervacija
            {
                Biblioteka = biblioteka,
                Status = StatusRezervacije.OBRADJENA
            };
            Zahtev zahtev = new Zahtev
            {
                Objekat = rezervacija,
                Operacija = Operacije.VratiObradjeneRezervacije
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }
        internal Odgovor ObradiRezervaciju(Rezervacija rezervacija)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = rezervacija,
                Operacija = Operacije.ObradiRezervaciju
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }
        internal Odgovor VratiNeobradjeneRezervacije(Biblioteka biblioteka)
        {
            Rezervacija rezervacija = new Rezervacija
            {
                Biblioteka = biblioteka,
                Status = StatusRezervacije.NEOBRADJENA
            };
            Zahtev zahtev = new Zahtev
            {
                Objekat = rezervacija,
                Operacija = Operacije.VratiNeobradjeneRezervacije
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor PromeniPodatkeBibliotekara(Common.Domen.Bibliotekar bibliotekar)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = bibliotekar,
                Operacija = Operacije.PromeniPodatkeBibliotekara
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal void OdjaviSe(IEntitet entitet)
        {
            
            if(entitet is Common.Domen.Bibliotekar)
            {
                Common.Domen.Bibliotekar bibliotekar = (Common.Domen.Bibliotekar)entitet;
                bibliotekar.Prijavljen = false;
                Zahtev zahtev = new Zahtev
                {
                    Objekat = bibliotekar,
                    Operacija = Operacije.PromeniPodatkeBibliotekara
                };
                sender.Posalji(zahtev);
                receiver.Primi();
                soket.Close();
                soket = null;
            }else if(entitet is Common.Domen.Clan)
            {
                Common.Domen.Clan clan = (Common.Domen.Clan)entitet;
                clan.Prijavljen = false;
                Zahtev zahtev = new Zahtev
                {
                    Objekat = clan,
                    Operacija = Operacije.PromeniPodatkeClana
                };
                sender.Posalji(zahtev);
                receiver.Primi();
                soket.Close();
                soket = null;
            }
        }

        internal List<Biblioteka> VratiBibliotekeClana(Common.Domen.Clan clan)
        {
            ClanBiblioteka clanBiblioteka = new ClanBiblioteka
            {
                Clan = clan
            };

            Zahtev zahtev = new Zahtev
            {
                Objekat = clanBiblioteka,
                Operacija = Operacije.VratiBibliotekeClana
            };
            sender.Posalji(zahtev);
            Odgovor odgovor = (Odgovor)receiver.Primi();
            return (List<Biblioteka>)odgovor.Rezultat;
        }

        internal Odgovor OtkaziClanstvo(Common.Domen.Clan clan, Biblioteka izabranaBiblioteka)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = new ClanBiblioteka
                {
                    Clan = clan,
                    Biblioteka = izabranaBiblioteka
                },
                Operacija = Operacije.OtkaziClanstvo
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor KreirajRezervaciju(Rezervacija rezervacija)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = rezervacija,
                Operacija = Operacije.KreirajRezervaciju
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor PromeniPodatkeClana(Common.Domen.Clan clan)
        {
            Zahtev zahtev = new Zahtev
            {
                Objekat = clan,
                Operacija = Operacije.PromeniPodatkeClana
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor VratiRezervacijeClana(Common.Domen.Clan clan, Biblioteka izabranaBiblioteka)
        {
            Rezervacija rezervacija = new Rezervacija
            {
                Clan = clan,
                Biblioteka = izabranaBiblioteka
            };
            Zahtev zahtev = new Zahtev
            {
                Objekat = rezervacija,
                Operacija = Operacije.PrikaziSveRezervacije
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal Odgovor UclaniSe(Common.Domen.Clan clan, Biblioteka izabranaBiblioteka)
        {
            ClanBiblioteka clanBiblioteka = new ClanBiblioteka
            {
                Clan = clan,
                Biblioteka = izabranaBiblioteka,
                DatumUclanjenja = DateTime.Now
            };
            Zahtev zahtev = new Zahtev
            {
                Objekat = clanBiblioteka,
                Operacija = Operacije.UclaniSe
            };
            sender.Posalji(zahtev);
            return (Odgovor)receiver.Primi();
        }

        internal List<Biblioteka> VratiBibliotekeClana(Domen.Clan clan)
        {
            ClanBiblioteka clanBiblioteka = new ClanBiblioteka
            {
                Clan = clan
            };

            Zahtev zahtev = new Zahtev
            {
                Objekat = clanBiblioteka,
                Operacija = Operacije.VratiBibliotekeClana
            };
            sender.Posalji(zahtev);
            Odgovor odgovor = (Odgovor)receiver.Primi();
            return (List<Biblioteka>)odgovor.Rezultat;
        }

    }
}
