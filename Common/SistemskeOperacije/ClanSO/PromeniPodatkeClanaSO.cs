using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.ClanSO
{
    public class PromeniPodatkeClanaSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi(IEntitet entitet)
        {
            Clan clan = (Clan)entitet;
            clan.Uslov = $"IDClan = {clan.IDClan}";
            repozitorijum.Promeni(clan);
        }
    }
}
