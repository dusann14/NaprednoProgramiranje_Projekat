using Common.Domen;
using Common.SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Test
{
    public class ObrisiRezervacijeClanaSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezervacija rezervacija = (Rezervacija)entitet;
            rezervacija.Uslov = $"IDClan = {rezervacija.Clan.IDClan}";
            repozitorijum.Obrisi(rezervacija);
        }
    }
}
