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
    public class KontrolerUCProfilClan
    {
        public UCProfilClan UCProfil { get; set; }

        internal UserControl NapraviUCProfil(ClanKontroler clanKontroler)
        {
            UCProfil = new UCProfilClan();

            return UCProfil;
        }
    }
}
