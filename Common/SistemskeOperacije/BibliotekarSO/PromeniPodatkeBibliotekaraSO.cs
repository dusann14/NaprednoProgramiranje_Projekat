using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.BibliotekarSO
{
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
