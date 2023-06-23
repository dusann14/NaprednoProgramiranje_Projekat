using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.StavkaSO
{
    public class VratiStavkeRezervacijeSO : SistemskaOperacijaBaza
    {
        public List<Stavka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Stavka stavka = (Stavka)entitet;
            stavka.Uslov = $"s.IDRezervacija = {stavka.Rezervacija.IDRezervacija}";
            Rezultat = repozitorijum.VratiPoUslovu(stavka).Cast<Stavka>().ToList();
        }
    }
}
