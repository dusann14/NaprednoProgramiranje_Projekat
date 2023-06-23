using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.BibliotekaSO
{
    public class VratiSveBibliotekeSO : SistemskaOperacijaBaza
    {
        public List<Biblioteka> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezultat = repozitorijum.VratiSve(entitet).Cast<Biblioteka>().ToList();
        }
    }
}
