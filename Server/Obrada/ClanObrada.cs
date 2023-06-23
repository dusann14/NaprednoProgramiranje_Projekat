using Common.Domen;
using Common.Transfer;
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
    public class ClanObrada
    {
        private Socket soket;
        private BindingList<Clan> list;
        private NetworkStream tok;
        private BinaryFormatter formatter;
        public ClanObrada(Socket soket, System.ComponentModel.BindingList<Clan> list)
        {
            this.soket = soket;
            this.list = list;
        }
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
                        formatter.Serialize(tok, odgovor);
                    }
                }
            }
            catch
            {

            }
        }

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

        internal void Stop()
        {
            soket.Close();
        }
    }
}
