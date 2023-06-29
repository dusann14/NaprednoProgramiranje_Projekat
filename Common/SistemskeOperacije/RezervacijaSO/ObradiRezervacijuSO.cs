using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.RezervacijaSO
{
    /// <summary>
    /// Klasa ObradiRezervacijuSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class ObradiRezervacijuSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezervacija rezervacija = (Rezervacija)entitet;
            rezervacija.Uslov = $"IDRezervacija = {rezervacija.IDRezervacija}";
            repozitorijum.Promeni(rezervacija);
        }
    }
}
