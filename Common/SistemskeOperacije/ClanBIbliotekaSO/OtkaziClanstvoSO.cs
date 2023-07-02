using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.ClanBibliotekaSO
{
    /// <summary>
    /// Klasa OtkaziClanstvoSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>v
    public class OtkaziClanstvoSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi(IEntitet entitet)
        {
            ClanBiblioteka clanBiblioteka = (ClanBiblioteka)entitet;
            clanBiblioteka.Uslov = $"IDBiblioteka = {clanBiblioteka.Biblioteka.IDBiblioteka} and IDClan = {clanBiblioteka.Clan.IDClan}";
            repozitorijum.Obrisi(clanBiblioteka);
        }
    }
}
