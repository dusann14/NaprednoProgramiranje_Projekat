using Common.Domen;
using Common.SistemskeOperacije.AutorSO;
using Common.SistemskeOperacije.BibliotekarSO;
using Common.SistemskeOperacije.BibliotekaSO;
using Common.SistemskeOperacije.ClanBibliotekaSO;
using Common.SistemskeOperacije.ClanSO;
using Common.SistemskeOperacije.KnjigaSO;
using Common.SistemskeOperacije.LoginSO;
using Common.SistemskeOperacije.RezervacijaSO;
using Common.SistemskeOperacije.StavkaSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Kontroler
{
    public class Kontroler
    {

        private static Kontroler instance;

        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }
        private Kontroler() { }

        public IEntitet Login(List<IEntitet> entiteti)
        {
            LoginSO o = new LoginSO();
            foreach (IEntitet entitet in entiteti)
            {
                o.Template(entitet);
                if (o.Rezultat != null)
                    return o.Rezultat;
            }
            return o.Rezultat;
        }

        public List<Knjiga> VratiKnjigeIzBiblioteke(Knjiga knjiga)
        {
            VratiSveKnjigeSO o = new VratiSveKnjigeSO();
            o.Template(knjiga);
            return o.Rezultat;
        }

        public List<Knjiga> VratiKnjigeIzBibliotekePoAutoru(Knjiga knjiga)
        {
            VratiKnjigePoAutoruSO o = new VratiKnjigePoAutoruSO();
            o.Template(knjiga);
            return o.Rezultat;
        }

        public void DodajKnjigu(Knjiga knjiga)
        {
            DodajKnjiguSO o = new DodajKnjiguSO();
            o.Template(knjiga);
        }

        public void ObrisiKnjigu(Knjiga knjiga)
        {
            ObrisiKnjiguSO o = new ObrisiKnjiguSO();
            o.Template(knjiga);
        }

        public void PromeniKnjigu(Knjiga knjiga)
        {
            PromeniKnjiguSO o = new PromeniKnjiguSO();
            o.Template(knjiga);
        }

        public void PromeniPodatkeBibliotekara(Bibliotekar bibliotekar)
        {
            PromeniPodatkeBibliotekaraSO o = new PromeniPodatkeBibliotekaraSO();
            o.Template(bibliotekar);
        }

        public List<ClanBiblioteka> PrikaziSveClanove(ClanBiblioteka clanBiblioteka)
        {
            VratiSveClanoveIzBibliotekeSO o = new VratiSveClanoveIzBibliotekeSO();
            o.Template(clanBiblioteka);
            return o.Rezultat;
        }

        public List<ClanBiblioteka> PrikaziClanovePoImenu(ClanBiblioteka clanBiblioteka)
        {
            VratiClanovePoImenuSO o = new VratiClanovePoImenuSO();
            o.Template(clanBiblioteka);
            return o.Rezultat;
        }

        public List<Biblioteka> VratiBibliotekeClana(ClanBiblioteka clanBiblioteka)
        {
            VratiBibliotekeClanaSO o = new VratiBibliotekeClanaSO();
            o.Template(clanBiblioteka);
            List<Biblioteka> biblioteke = new List<Biblioteka>();
            foreach (ClanBiblioteka cb in o.Rezultat)
            {
                biblioteke.Add(cb.Biblioteka);
            }
            return biblioteke;
        }

        public List<Rezervacija> VratiSveRezervacije(Rezervacija rezervacija)
        {
            VratiSveRezervacijeClanaSO o = new VratiSveRezervacijeClanaSO();
            o.Template(rezervacija);
            return o.Rezultat;
        }

        public void PromeniPodatkeClana(Clan clan)
        {
            PromeniPodatkeClanaSO o = new PromeniPodatkeClanaSO();
            o.Template(clan);
        }

        public void KreirajRezervaciju(Rezervacija rezervacija)
        {
            KreirajRezervacijuSO o = new KreirajRezervacijuSO();
            o.Template(rezervacija);
        }

        public List<Autor> VratiAutore(Autor autor)
        {
            VratiAutoreSO o = new VratiAutoreSO();
            o.Template(autor);
            return o.Rezultat;
        }

        public List<Biblioteka> PrikaziSveBiblioteke(Biblioteka biblioteka)
        {
            VratiSveBibliotekeSO o = new VratiSveBibliotekeSO();
            o.Template(biblioteka);
            return o.Rezultat;
        }

        public void OtkaziClanstvo(ClanBiblioteka clanBiblioteka)
        {
            OtkaziClanstvoSO o = new OtkaziClanstvoSO();
            o.Template(clanBiblioteka);
        }

        public void UclaniSe(ClanBiblioteka clanBiblioteka)
        {
            UclaniSeSO o = new UclaniSeSO();
            o.Template(clanBiblioteka);
        }

        public List<Stavka> VratiStavkeRezervacije(Stavka stavka)
        {
            VratiStavkeRezervacijeSO o = new VratiStavkeRezervacijeSO();
            o.Template(stavka);
            return o.Rezultat;
        }

        public List<Knjiga> VratiKnjigePoNaslovu(Knjiga knjiga)
        {
            VratiKnjigePoNaslovuSO o = new VratiKnjigePoNaslovuSO();
            o.Template(knjiga);
            return o.Rezultat;
        }

        public object VratiNeobradjeneRezervacije(Rezervacija rezervacija)
        {
            VratiNeobradjeneRezervacijeSO o = new VratiNeobradjeneRezervacijeSO();
            o.Template(rezervacija);
            return o.Rezultat;
        }

        public void ObradiRezervaciju(Rezervacija rezervacija)
        {
            ObradiRezervacijuSO o = new ObradiRezervacijuSO();
            o.Template(rezervacija);
        }

        public object VratiObradjeneRezervacije(Rezervacija rezervacija)
        {
            VratiObradjeneRezervacijeSO o = new VratiObradjeneRezervacijeSO();
            o.Template(rezervacija);
            return o.Rezultat;
        }
    }
}
