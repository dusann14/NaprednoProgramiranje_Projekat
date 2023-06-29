using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.BibliotekarSO
{
    /// <summary>
    /// Klasa PromeniPodatkeBibliotekaraSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class PromeniPodatkeBibliotekaraSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi(IEntitet entitet)
        {
            Bibliotekar bibliotekar = (Bibliotekar)entitet;
            bibliotekar.Uslov = $"IDBibliotekar = {bibliotekar.IDBibliotekar}";
            repozitorijum.Promeni(bibliotekar);
        }
    }
}
