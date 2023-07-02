using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.RezervacijaSO
{
    /// <summary>
    /// Klasa VratiSveRezervacijeClanaSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class VratiSveRezervacijeClanaSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Lista rezervacija vracenih iz baze podataka.
        /// </summary>
        public List<Rezervacija> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezervacija rezervacija = (Rezervacija)entitet;
            rezervacija.Uslov = $"c.IDClan = {rezervacija.Clan.IDClan} and b.IDBiblioteka = {rezervacija.Biblioteka.IDBiblioteka}";
            Rezultat = repozitorijum.VratiPoUslovu(rezervacija).Cast<Rezervacija>().ToList();
        }
    }
}
