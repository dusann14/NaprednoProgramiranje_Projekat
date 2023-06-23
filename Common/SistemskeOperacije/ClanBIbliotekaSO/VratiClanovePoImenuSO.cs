using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.ClanBibliotekaSO
{
    public class VratiClanovePoImenuSO : SistemskaOperacijaBaza
    {
        public List<ClanBiblioteka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            ClanBiblioteka cb = (ClanBiblioteka)entitet;
            cb.Uslov = $"cb.IDBiblioteka = {cb.Biblioteka.IDBiblioteka} and c.ImePrezime LIKE '%{cb.Clan.ImePrezime}%'";
            Rezultat = repozitorijum.VratiPoUslovu(cb).Cast<ClanBiblioteka>().ToList();
        }
    }
}
