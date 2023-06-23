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
    public class BibliotekarObrada
    {
        private Socket soket;
        private BindingList<Bibliotekar> list;
        private NetworkStream tok;
        private BinaryFormatter formatter;

        public BibliotekarObrada(Socket soket, System.ComponentModel.BindingList<Bibliotekar> list)
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

                    if (zahtev.Operacija == Operacije.PromeniPodatkeBibliotekara)
                    {
                        Kontroler.Kontroler.Instance.PromeniPodatkeBibliotekara((Bibliotekar)zahtev.Objekat);
                        odgovor = new Odgovor();
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

        internal void Stop()
        {
            soket.Close();
        }
    }
}
