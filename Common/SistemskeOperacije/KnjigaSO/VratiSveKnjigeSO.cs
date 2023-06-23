using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.KnjigaSO
{
    public class VratiSveKnjigeSO : SistemskaOperacijaBaza
    {
        public List<Knjiga> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Knjiga knjiga = (Knjiga)entitet;
            knjiga.Uslov = $"k.IDBiblioteka = {knjiga.Biblioteka.IDBiblioteka}";
            Rezultat = repozitorijum.VratiPoUslovu(knjiga).Cast<Knjiga>().ToList();
        }
    }
}
