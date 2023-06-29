using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.KnjigaSO
{
    /// <summary>
    /// Klasa PromeniKnjiguSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class PromeniKnjiguSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi(IEntitet entitet)
        {
            Knjiga knjiga = (Knjiga)entitet;
            knjiga.Uslov = $"IDKnjiga = {knjiga.IDKnjiga}";
            repozitorijum.Promeni(knjiga);
        }
    }
}
