using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.ClanBibliotekaSO
{
    public class VratiBibliotekeClanaSO : SistemskaOperacijaBaza
    {
        public List<ClanBiblioteka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            ClanBiblioteka clanBiblioteka = (ClanBiblioteka)entitet;
            clanBiblioteka.Uslov = $"c.IDClan = {clanBiblioteka.Clan.IDClan}";
            Rezultat = repozitorijum.VratiPoUslovu(clanBiblioteka).Cast<ClanBiblioteka>().ToList();
        }
    }
}
