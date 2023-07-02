using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Predstavlja status rezervacije kao enum. Vrednosti koje uzima su neobradjena, obradjena i istekla.
    /// </summary>
    public enum StatusRezervacije
    {
        NEOBRADJENA = 1,
        OBRADJENA = 2,
        ISTEKLA = 3,
    }
}
