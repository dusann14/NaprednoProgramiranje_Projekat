using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.ClanBibliotekaSO
{
    public class VratiSveClanoveIzBibliotekeSO : SistemskaOperacijaBaza
    {
        public List<ClanBiblioteka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            ClanBiblioteka cb = (ClanBiblioteka)entitet;
            cb.Uslov = $"cb.IDBiblioteka = {cb.Biblioteka.IDBiblioteka}";
            Rezultat = repozitorijum.VratiPoUslovu(cb).Cast<ClanBiblioteka>().ToList();
        }
    }
}
