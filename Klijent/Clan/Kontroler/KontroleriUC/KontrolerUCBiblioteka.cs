using Common.Transfer;
using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCBiblioteka
    {
        public UCBiblioteka UCBiblioteka { get; set; }

        internal UserControl NapraviUCBiblioteka(ClanKontroler clanKontroler)
        {
            UCBiblioteka = new UCBiblioteka();

            return UCBiblioteka;
        }

        
    }
}
