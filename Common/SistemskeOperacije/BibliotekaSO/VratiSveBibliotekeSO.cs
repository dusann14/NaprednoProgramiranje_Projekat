using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.BibliotekaSO
{
    /// <summary>
    /// Klasa VratiSveBibliotekeSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class VratiSveBibliotekeSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Lista biblioteka vracena iz baze podataka.
        /// </summary>
        public List<Biblioteka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezultat = repozitorijum.VratiSve(entitet).Cast<Biblioteka>().ToList();
        }
    }
}
