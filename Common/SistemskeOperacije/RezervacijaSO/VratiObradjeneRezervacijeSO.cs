using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.RezervacijaSO
{
    public class VratiObradjeneRezervacijeSO : SistemskaOperacijaBaza
    {
        public List<Rezervacija> Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezervacija rezervacija = (Rezervacija)entitet;
            rezervacija.Uslov = $"b.IDBiblioteka = {rezervacija.Biblioteka.IDBiblioteka} and sr.IDStatus = {(int)rezervacija.Status}";
            Rezultat = repozitorijum.VratiPoUslovu(rezervacija).Cast<Rezervacija>().ToList();
        }
    }
}
