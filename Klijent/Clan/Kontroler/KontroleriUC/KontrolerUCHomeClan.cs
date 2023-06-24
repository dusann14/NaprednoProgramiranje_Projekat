using Klijent.Bibliotekar.UserControls;
using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCHomeClan
    {
        public UCHomeClan UCHome { get; set; }

        internal UserControl NapraviUCHome(ClanKontroler clanKontroler)
        {
            UCHome = new UCHomeClan();
            
            return UCHome;
        }
    }
}
