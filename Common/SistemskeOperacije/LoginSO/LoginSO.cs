using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.LoginSO
{
    /// <summary>
    /// Klasa LoginSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class LoginSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Entitet vracen iz baze podataka.
        /// </summary>
        public IEntitet Rezultat { get; private set; }

        protected override void Izvrsi(IEntitet entitet)
        {
            Rezultat = repozitorijum.PronadjiJednog(entitet);
        }
    }
}
