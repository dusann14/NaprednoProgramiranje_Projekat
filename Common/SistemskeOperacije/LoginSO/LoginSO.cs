using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.LoginSO
{
    public class LoginSO : SistemskaOperacijaBaza
    {
        public IEntitet Rezultat { get; private set; }

        protected override void Izvrsi(IEntitet entitet)
        {
            Rezultat = repozitorijum.PronadjiJednog(entitet);
        }
    }
}
