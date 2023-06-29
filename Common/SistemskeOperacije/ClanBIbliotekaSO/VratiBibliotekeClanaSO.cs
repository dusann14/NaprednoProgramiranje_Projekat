using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.ClanBibliotekaSO
{
    /// <summary>
    /// Klasa VratiBibliotekeClanaSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class VratiBibliotekeClanaSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Lista biblioteka clana vracenih iz baze podataka.
        /// </summary>
        public List<ClanBiblioteka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            ClanBiblioteka clanBiblioteka = (ClanBiblioteka)entitet;
            clanBiblioteka.Uslov = $"c.IDClan = {clanBiblioteka.Clan.IDClan}";
            Rezultat = repozitorijum.VratiPoUslovu(clanBiblioteka).Cast<ClanBiblioteka>().ToList();
        }
    }
}
