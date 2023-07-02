using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije.RezervacijaSO
{
    /// <summary>
    /// Klasa KreirajRezervacijuSO koja nasledjuje klasu SistemskaOperacijaBaza i implementira na odogovarajuci nacin metodu Izvrsi.
    /// </summary>
    public class KreirajRezervacijuSO : SistemskaOperacijaBaza
    {
        /// <summary>
        /// Jedinstveni identifikator unetog sloga u bazu podataka.
        /// </summary>
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
