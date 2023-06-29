using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    /// <summary>
    /// Klasa Zahtev koja predstavlja klijentski zahtev. Serijablina je klasa.
    /// </summary>
    [Serializable]
    public class Zahtev
    {
        /// <summary>
        /// Objekat koji klijent salje na server tipa object.
        /// </summary>
        public object Objekat { get; set; }

        /// <summary>
        /// Operacija koja treba da se izvrsi na serveru.
        /// </summary>
        public Operacije Operacija { get; set; }
    }
}
