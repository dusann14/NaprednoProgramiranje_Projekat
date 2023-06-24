using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Bibliotekar.Kontroler
{
    public class BibliotekarKontroler
    {
        public FrmBibliotekar FrmBibliotekar { get; set; }
        public Common.Domen.Bibliotekar  Bibliotekar { get; set; }

        public FrmBibliotekar NapraviBibliotekarFormu()
        {
            FrmBibliotekar = new FrmBibliotekar();
            
            return FrmBibliotekar;
        }

    }
}
