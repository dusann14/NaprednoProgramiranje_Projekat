using Common.Domen;
using Common.SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Test.DodateSO
{
    public class DodajAutoraSO : SistemskaOperacijaBaza
    {
        public int Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezultat = repozitorijum.Dodaj(entitet);
        }
    }
}
