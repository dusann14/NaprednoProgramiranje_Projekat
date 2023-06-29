using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.ClanBibliotekaSO
{
    /// <summary>
    /// Klasa UclaniSeSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class UclaniSeSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Jedinstveni identifikator unetog sloga u bazu podataka.
        /// </summary>
        public int Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezultat = repozitorijum.Dodaj(entitet);
        }
    }
}
