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
        /// <summary>
        /// Static instanca kontrolera.
        /// </summary>
        private static Kontroler instance;

        /// <summary>
        /// Definisanje singleton-a.
        /// </summary>
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

        /// <summary>
        /// Privatni konstruktor.
        /// </summary>
        private Kontroler() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entiteti"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za citanje svih knjiga iz biblioteke.
        /// </summary>
        /// <param name="knjiga">Knjiga iz koje se vidi iz koje biblioteke se traze knjige.</param>
        /// <returns>Lista knjiga iz biblioteke.</returns>
        public List<Knjiga> VratiKnjigeIzBiblioteke(Knjiga knjiga)
        {
            VratiSveKnjigeSO o = new VratiSveKnjigeSO();
            o.Template(knjiga);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za citanje svih knjiga iz biblioteke po autoru.
        /// </summary>
        /// <param name="knjiga">Knjiga iz koje se vidi iz koje biblioteke se traze knjige i za kog autora.</param>
        /// <returns>Lista knjiga iz biblioteke.</returns>
        public List<Knjiga> VratiKnjigeIzBibliotekePoAutoru(Knjiga knjiga)
        {
            VratiKnjigePoAutoruSO o = new VratiKnjigePoAutoruSO();
            o.Template(knjiga);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za dodavanje knjige u biblioteku.
        /// </summary>
        /// <param name="knjiga">Knjiga koju treba dodati u biblioteku.</param>
        public void DodajKnjigu(Knjiga knjiga)
        {
            DodajKnjiguSO o = new DodajKnjiguSO();
            o.Template(knjiga);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za brisanje knjige u biblioteku.
        /// </summary>
        /// <param name="knjiga">Knjiga koju treba obrisati iz biblioteku.</param>
        public void ObrisiKnjigu(Knjiga knjiga)
        {
            ObrisiKnjiguSO o = new ObrisiKnjiguSO();
            o.Template(knjiga);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za promenu knjige iz biblioteke.
        /// </summary>
        /// <param name="knjiga">Knjiga koju treba promeniti iz biblioteke.</param>
        public void PromeniKnjigu(Knjiga knjiga)
        {
            PromeniKnjiguSO o = new PromeniKnjiguSO();
            o.Template(knjiga);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za promenu podataka bibliotekara.
        /// </summary>
        /// <param name="bibliotekar">Bibliotekar cije podatke treba promeniti.</param>
        public void PromeniPodatkeBibliotekara(Bibliotekar bibliotekar)
        {
            PromeniPodatkeBibliotekaraSO o = new PromeniPodatkeBibliotekaraSO();
            o.Template(bibliotekar);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz svih clanova iz odredjene biblioteke.
        /// </summary>
        /// <param name="clanBiblioteka">Objekat tipa ClanBiblioteka sa kog se vidi iz koje biblioteke se traze clanovi.</param>
        /// <returns>Lista clanova iz biblioteke.</returns>
        public List<ClanBiblioteka> PrikaziSveClanove(ClanBiblioteka clanBiblioteka)
        {
            VratiSveClanoveIzBibliotekeSO o = new VratiSveClanoveIzBibliotekeSO();
            o.Template(clanBiblioteka);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz svih clanova iz odredjene biblioteke po imenu.
        /// </summary>
        /// <param name="clanBiblioteka">Objekat tipa ClanBiblioteka sa kog se vidi iz koje biblioteke se traze clanovi.</param>
        /// <returns>Lista clanova iz biblioteke.</returns>
        public List<ClanBiblioteka> PrikaziClanovePoImenu(ClanBiblioteka clanBiblioteka)
        {
            VratiClanovePoImenuSO o = new VratiClanovePoImenuSO();
            o.Template(clanBiblioteka);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz svih biblioteka clana.
        /// </summary>
        /// <param name="clanBiblioteka">Objekat tipa ClanBiblioteka sa kog se vidi iz koje biblioteke se traze clanovi.</param>
        /// <returns>Lista clanova iz biblioteke.</returns>
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

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz svih rezervacija clana.
        /// </summary>
        /// <param name="rezervacija">Rezervacija iz koje se vidi za kog clana su potrebne rezervacije.</param>
        /// <returns>Lista rezervacija clana.</returns>
        public List<Rezervacija> VratiSveRezervacije(Rezervacija rezervacija)
        {
            VratiSveRezervacijeClanaSO o = new VratiSveRezervacijeClanaSO();
            o.Template(rezervacija);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za promenu podataka clana.
        /// </summary>
        /// <param name="clan">Clan cije podatke treba promeniti.</param>
        public void PromeniPodatkeClana(Clan clan)
        {
            PromeniPodatkeClanaSO o = new PromeniPodatkeClanaSO();
            o.Template(clan);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za kreiranje rezervacije clana.
        /// </summary>
        /// <param name="rezervacija">Rezervacija koju treba kreirati.</param>
        public void KreirajRezervaciju(Rezervacija rezervacija)
        {
            KreirajRezervacijuSO o = new KreirajRezervacijuSO();
            o.Template(rezervacija);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz svih autora iz biblioteke.
        /// </summary>
        /// <param name="autor">Autor iz kog se vidi iz koje biblioteke su potrebni autori.</param>
        /// <returns>Lista autora iz biblioteke.</returns>
        public List<Autor> VratiAutore(Autor autor)
        {
            VratiAutoreSO o = new VratiAutoreSO();
            o.Template(autor);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz svih biblioteka.
        /// </summary>
        /// <param name="biblioteka">Biblioteka u sistemu.</param>
        /// <returns>Lista biblioteka.</returns>
        public List<Biblioteka> PrikaziSveBiblioteke(Biblioteka biblioteka)
        {
            VratiSveBibliotekeSO o = new VratiSveBibliotekeSO();
            o.Template(biblioteka);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za otkazivanje clanstva.
        /// </summary>
        /// <param name="clanBiblioteka">Objekat iz kog se vidi za kog clana i u kojoj biblioteci treba otkazati clanstvo.</param>
        public void OtkaziClanstvo(ClanBiblioteka clanBiblioteka)
        {
            OtkaziClanstvoSO o = new OtkaziClanstvoSO();
            o.Template(clanBiblioteka);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za dodavanje clanstva.
        /// </summary>
        /// <param name="clanBiblioteka">Objekat iz kog se vidi za kog clana i u kojoj biblioteci treba dodati clanstvo.</param>
        public void UclaniSe(ClanBiblioteka clanBiblioteka)
        {
            UclaniSeSO o = new UclaniSeSO();
            o.Template(clanBiblioteka);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz stavki rezervacije.
        /// </summary>
        /// <param name="stavka">Stavka iz koje se vidi iz koje rezervacije treba prikazati stavke.</param>
        /// <returns>Lista stavki rezervacije.</returns>
        public List<Stavka> VratiStavkeRezervacije(Stavka stavka)
        {
            VratiStavkeRezervacijeSO o = new VratiStavkeRezervacijeSO();
            o.Template(stavka);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz knjiga po naslovu. 
        /// </summary>
        /// <param name="knjiga">Knjiga iz koje se vidi iz koje biblioteke i koji naslov treba vratiti.</param>
        /// <returns>Lista knjiga iz biblioteke po naslovu.</returns>
        public List<Knjiga> VratiKnjigePoNaslovu(Knjiga knjiga)
        {
            VratiKnjigePoNaslovuSO o = new VratiKnjigePoNaslovuSO();
            o.Template(knjiga);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz rezervacija koje su neobradjene. 
        /// </summary>
        /// <param name="rezervacija">Rezervacija iz koje se vidi koje rezervacije treba vratiti.</param>
        /// <returns>Lista neobradjenih rezervacija.</returns>
        public object VratiNeobradjeneRezervacije(Rezervacija rezervacija)
        {
            VratiNeobradjeneRezervacijeSO o = new VratiNeobradjeneRezervacijeSO();
            o.Template(rezervacija);
            return o.Rezultat;
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za obradu rezervacije. 
        /// </summary>
        /// <param name="rezervacija">Rezervacija koju treba obraditi.</param>
        public void ObradiRezervaciju(Rezervacija rezervacija)
        {
            ObradiRezervacijuSO o = new ObradiRezervacijuSO();
            o.Template(rezervacija);
        }

        /// <summary>
        /// Zove i izvrsava sistemsku operaciju za prikaz rezervacija koje su obradjene. 
        /// </summary>
        /// <param name="rezervacija">Rezervacija iz koje se vidi koje rezervacije treba vratiti.</param>
        /// <returns>Lista obradjenih rezervacija.</returns>
        public object VratiObradjeneRezervacije(Rezervacija rezervacija)
        {
            VratiObradjeneRezervacijeSO o = new VratiObradjeneRezervacijeSO();
            o.Template(rezervacija);
            return o.Rezultat;
        }
    }
}
