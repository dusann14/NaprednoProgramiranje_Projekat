using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.KnjigaSO
{
    /// <summary>
    /// Klasa VratiSveKnjigeSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class VratiSveKnjigeSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Lista knjiga vracenih iz baze podataka.
        /// </summary>
        public List<Knjiga> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Knjiga knjiga = (Knjiga)entitet;
            knjiga.Uslov = $"k.IDBiblioteka = {knjiga.Biblioteka.IDBiblioteka}";
            Rezultat = repozitorijum.VratiPoUslovu(knjiga).Cast<Knjiga>().ToList();
        }
    }
}
