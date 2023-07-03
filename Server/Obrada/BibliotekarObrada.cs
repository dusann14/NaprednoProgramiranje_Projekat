using Common.Domen;
using Common.Transfer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.Obrada
{
    /// <summary>
    /// Klasa koja vrsi obradu klijentskih zahteva koje salje bibliotekar.
    /// </summary>
    public class BibliotekarObrada
    {
        /// <summary>
        /// Soket koji sluzi za postavljanje toka i formattera.
        /// </summary>
        private Socket soket;

        /// <summary>
        /// Lista bibliotekara za koje se vrsi obrada.
        /// </summary>
        private BindingList<Bibliotekar> list;

        /// <summary>
        /// Tok sa kog se skidaju klijentski zahtevi i na koji se salju serverski odgovori.
        /// </summary>
        private NetworkStream tok;

        /// <summary>
        /// BinaryFormatter koji sluzi za slanje i skidanje zahteva sa toka.
        /// </summary>
        private BinaryFormatter formatter;

        /// <summary>
        /// Konstruktor kojim se postavlja polje soketa i liste bibliotekara.
        /// </summary>
        /// <param name="soket">Prihvaceni klijentski soket.</param>
        /// <param name="list">Lista prijavljenih bibliotekara.</param>
        public BibliotekarObrada(Socket soket, System.ComponentModel.BindingList<Bibliotekar> list)
        {
            this.soket = soket;
            this.list = list;
        }

        /// <summary>
        /// Metoda koja prima zahteve sa klijenta i salje odgovarajuci odgovor.
        /// </summary>
        public void Obradi()
        {
            try
            {
                tok = new NetworkStream(soket);
                formatter = new BinaryFormatter();
                while (true)
                {
                    Zahtev zahtev = (Zahtev)formatter.Deserialize(tok);
                    Odgovor odgovor;

                    if (zahtev.Operacija == Operacije.PromeniPodatkeBibliotekara)
                    {
                        Kontroler.Kontroler.Instance.PromeniPodatkeBibliotekara((Bibliotekar)zahtev.Objekat);
                        odgovor = new Odgovor();
                        odgovor.Uspesno = true;
                        formatter.Serialize(tok, odgovor);
                        if (Provera(zahtev))
                        {
                            Stop();
                            break;
                        }
                    }
                    else
                    {
                        try
                        {
                            odgovor = Odgovori(zahtev);
                        }
                        catch (Exception e)
                        {
                            odgovor = new Odgovor();
                            odgovor.Uspesno = false;
                            odgovor.Greska = e.Message;
                        }
                        //serijalizacija objekta u json-u
                        string jsonStr = JsonConvert.SerializeObject(odgovor.Rezultat);
                        Console.WriteLine(jsonStr);
                        formatter.Serialize(tok, odgovor);
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Metoda koja filtrira klijentske zahteve i u zavisnosti od enum-a Operacije poziva odgovarajucu metodu kontrolera koji poziva izvrsenje sistemskih operacija.
        /// </summary>
        /// <param name="zahtev">Klijentski zahtev.</param>
        /// <returns>Serverski odgovor.</returns>
        private Odgovor Odgovori(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Uspesno = true;

            switch (zahtev.Operacija)
            {
                case Operacije.VratiKnjigePoNaslovu:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiKnjigePoNaslovu((Knjiga)zahtev.Objekat);
                    break;
                case Operacije.VratiKnjigeIzBiblioteke:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiKnjigeIzBiblioteke((Knjiga)zahtev.Objekat);
                    break;
                case Operacije.VratiKnjigePoAutoru:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiKnjigeIzBibliotekePoAutoru((Knjiga)zahtev.Objekat);
                    break;
                case Operacije.VratiAutore:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiAutore((Autor)zahtev.Objekat);
                    break;
                case Operacije.DodajKnjigu:
                    Kontroler.Kontroler.Instance.DodajKnjigu((Knjiga)zahtev.Objekat);
                    break;
                case Operacije.ObrisiKnjigu:
                    Kontroler.Kontroler.Instance.ObrisiKnjigu((Knjiga)zahtev.Objekat);
                    break;
                case Operacije.PromeniKnjigu:
                    Kontroler.Kontroler.Instance.PromeniKnjigu((Knjiga)zahtev.Objekat);
                    break;
                case Operacije.PrikaziSveClanoveBiblioteke:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.PrikaziSveClanove((ClanBiblioteka)zahtev.Objekat);
                    break;
                case Operacije.PrikaziClanovePoImenu:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.PrikaziClanovePoImenu((ClanBiblioteka)zahtev.Objekat);
                    break;
                case Operacije.VratiNeobradjeneRezervacije:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiNeobradjeneRezervacije((Rezervacija)zahtev.Objekat);
                    break;
                case Operacije.VratiObradjeneRezervacije:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiObradjeneRezervacije((Rezervacija)zahtev.Objekat);
                    break;
                case Operacije.VratiStavkeRezervacije:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiStavkeRezervacije((Stavka)zahtev.Objekat);
                    break;
                case Operacije.ObradiRezervaciju:
                    Kontroler.Kontroler.Instance.ObradiRezervaciju((Rezervacija)zahtev.Objekat);
                    break;
            }
            return odgovor;
        }

        /// <summary>
        /// Vrsi se provera da li je bibliotekar iskazao zelju da se odjavi sa sistema ili je samo zeleo da promeni podatke.
        /// </summary>
        /// <param name="zahtev">Klijentski zahtev.</param>
        /// <returns>true - ako je bibliotekar zeleo da se odjavi, false - ako bibliotekar nije zeleo da se odjavi</returns>
        private bool Provera(Zahtev zahtev)
        {
            Bibliotekar bibliotekar = (Bibliotekar)zahtev.Objekat;
            if (bibliotekar.Prijavljen == false)
            {
                Stop(bibliotekar);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Izbacuje bibliotekara iz liste ukoliko se bibliotekar odjavio sa sistema.
        /// </summary>
        /// <param name="clan"></param>
        private void Stop(Bibliotekar bibliotekar)
        {
            foreach (Bibliotekar b in list)
            {
                if (b.IDBibliotekar == bibliotekar.IDBibliotekar)
                {
                    list.Remove(b);
                    return;
                }
            }
        }

        /// <summary>
        /// Zatvara klijentski soket.
        /// </summary>
        internal void Stop()
        {
            soket.Close();
        }
    }
}
