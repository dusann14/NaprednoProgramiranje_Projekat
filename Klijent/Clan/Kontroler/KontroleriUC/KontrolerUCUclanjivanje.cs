using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCUclanjivanje
    {
        public UCUclanjivanje UCUclanjivanje { get; set; }

        internal UserControl NapraviUCUclanjivanje(ClanKontroler clanKontroler)
        {
            UCUclanjivanje = new UCUclanjivanje();
            return UCUclanjivanje;
        }
    }
}
