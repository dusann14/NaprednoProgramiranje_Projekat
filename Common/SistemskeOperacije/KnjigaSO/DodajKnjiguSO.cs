using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.KnjigaSO
{
    public class DodajKnjiguSO : SistemskaOperacijaBaza
    {
        public int Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezultat = repozitorijum.Dodaj(entitet);
        }
    }
}
