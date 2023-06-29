using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    /// <summary>
    /// Klasa Odgovor koja predstavlja serverski odgovor na osnovu unete operacije. Serijablina je klasa.
    /// </summary>
    [Serializable]
    public class Odgovor
    {
        /// <summary>
        /// Oznacava da li je uspesno izvrsena sistemska operacija kao bool.
        /// </summary>
        public bool Uspesno { get; set; }

        /// <summary>
        /// Ukoliko sistemska operacija nije uspesno izvrsena greska se upisuje u ovo polje kao string, ako jeste polje je null.
        /// </summary>
        public string Greska { get; set; }

        /// <summary>
        /// Entitet/Entiteti koji su vraceni sa servera kao odgovor na osnovu klijentskog zahteva.
        /// </summary>
        public object Rezultat { get; set; }
    }
}
