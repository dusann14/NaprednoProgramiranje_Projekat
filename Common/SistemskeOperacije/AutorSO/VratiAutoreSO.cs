using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.AutorSO
{
    /// <summary>
    /// Klasa VratiAutoreSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class VratiAutoreSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Lista autora vracena iz baze podataka.
        /// </summary>
        public List<Autor> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Autor autor = (Autor)entitet;
            autor.Uslov = $"a.IDBiblioteka = {autor.Biblioteka.IDBiblioteka}";
            Rezultat = repozitorijum.VratiPoUslovu(autor).Cast<Autor>().ToList();
        }
    }
}
