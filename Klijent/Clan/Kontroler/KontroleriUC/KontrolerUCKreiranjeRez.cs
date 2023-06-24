using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCKreiranjeRez
    {
        public UCKreiranjeRezervacije UCKreiranjeRezervacije { get; set; }

        internal UserControl NapraviUCKreiranjeRezervacije(ClanKontroler clanKontroler)
        {
            UCKreiranjeRezervacije = new UCKreiranjeRezervacije();
            
            return UCKreiranjeRezervacije;
        }
    }
}
