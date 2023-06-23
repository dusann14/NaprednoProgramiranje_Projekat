using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.RezervacijaSO
{
    public class KreirajRezervacijuSO : SistemskaOperacijaBaza
    {
        public int Rezultat { get; set; }
        protected override void Izvrsi(IEntitet entitet)
        {
            Rezervacija rezervacija = (Rezervacija)entitet;
            Rezultat = repozitorijum.Dodaj(rezervacija);

            foreach (Stavka stavka in rezervacija.Stavke)
            {
                stavka.Rezervacija.IDRezervacija = Rezultat;
                int id = repozitorijum.Dodaj(stavka);
            }

        }
    }
}
