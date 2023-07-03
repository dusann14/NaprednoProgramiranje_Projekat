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
    /// Klasa koja vrsi obradu klijentskih zahteva koje salje clan.
    /// </summary>
    public class ClanObrada
    {
        /// <summary>
        /// Soket koji sluzi za postavljanje toka i formattera.
        /// </summary>
        private Socket soket;

        /// <summary>
        /// Lista clanova za koje se vrsi obrada.
        /// </summary>
        private BindingList<Clan> list;

        /// <summary>
        /// Tok sa kog se skidaju klijentski zahtevi i na koji se salju serverski odgovori.
        /// </summary>
        private NetworkStream tok;

        /// <summary>
        /// BinaryFormatter koji sluzi za slanje i skidanje zahteva sa toka.
        /// </summary>
        private BinaryFormatter formatter;

        /// <summary>
        /// Konstruktor kojim se postavlja polje soketa i liste clanova.
        /// </summary>
        /// <param name="soket">Prihvaceni klijentski soket.</param>
        /// <param name="list">Lista prijavljenih clanova.</param>
        public ClanObrada(Socket soket, System.ComponentModel.BindingList<Clan> list)
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

                    if (zahtev.Operacija == Operacije.PromeniPodatkeClana)
                    {
                        Kontroler.Kontroler.Instance.PromeniPodatkeClana((Clan)zahtev.Objekat);
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
                case Operacije.PrikaziSveRezervacije:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiSveRezervacije((Rezervacija)zahtev.Objekat);
                    break;
                case Operacije.VratiStavkeRezervacije:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiStavkeRezervacije((Stavka)zahtev.Objekat);
                    break;
                case Operacije.KreirajRezervaciju:
                    Kontroler.Kontroler.Instance.KreirajRezervaciju((Rezervacija)zahtev.Objekat);
                    break;
                case Operacije.VratiBibliotekeClana:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.VratiBibliotekeClana((ClanBiblioteka)zahtev.Objekat);
                    break;
                case Operacije.PromeniKnjigu:
                    Kontroler.Kontroler.Instance.PromeniKnjigu((Knjiga)zahtev.Objekat);
                    break;
                case Operacije.PrikaziSveBiblioteke:
                    odgovor.Rezultat = Kontroler.Kontroler.Instance.PrikaziSveBiblioteke((Biblioteka)zahtev.Objekat);
                    break;
                case Operacije.OtkaziClanstvo:
                    Kontroler.Kontroler.Instance.OtkaziClanstvo((ClanBiblioteka)zahtev.Objekat);
                    break;
                case Operacije.UclaniSe:
                    Kontroler.Kontroler.Instance.UclaniSe((ClanBiblioteka)zahtev.Objekat);
                    break;
            }

            return odgovor;
        }

        /// <summary>
        /// Vrsi se provera da li je clan iskazao zelju da se odjavi sa sistema ili je samo zeleo da promeni podatke.
        /// </summary>
        /// <param name="zahtev">Klijentski zahtev.</param>
        /// <returns>true - ako je clan zeleo da se odjavi, false ako clan nije zeleo da se odjavi</returns>
        private bool Provera(Zahtev zahtev)
        {
            Clan clan = (Clan)zahtev.Objekat;
            if (clan.Prijavljen == false)
            {
                Stop(clan);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Izbacuje clana iz liste ukoliko se clan odjavio sa sistema.
        /// </summary>
        /// <param name="clan"></param>
        private void Stop(Clan clan)
        {
            foreach (Clan c in list)
            {
                if (c.IDClan == clan.IDClan)
                {
                    list.Remove(c);
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
