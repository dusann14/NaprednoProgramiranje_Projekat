using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.StavkaSO
{
    /// <summary>
    /// Klasa VratiStavkeRezervacijeSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class VratiStavkeRezervacijeSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Lista stavki vracenih iz baze podataka.
        /// </summary>
        public List<Stavka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Stavka stavka = (Stavka)entitet;
            stavka.Uslov = $"s.IDRezervacija = {stavka.Rezervacija.IDRezervacija}";
            Rezultat = repozitorijum.VratiPoUslovu(stavka).Cast<Stavka>().ToList();
        }
    }
}
