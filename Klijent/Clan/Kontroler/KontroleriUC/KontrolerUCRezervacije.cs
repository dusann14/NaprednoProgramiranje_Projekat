using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCRezervacije
    {
        public UCRezervacije UCRezervacije { get; set; }

        internal UserControl NapraviUCRezervacije(ClanKontroler clanKontroler)
        {
            UCRezervacije = new UCRezervacije();
            return UCRezervacije;
        }
    }
}
