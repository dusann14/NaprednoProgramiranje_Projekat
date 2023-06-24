using Klijent.Clan.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler.KontroleriUC
{
    public class KontrolerUCBiranjeBiblioteke
    {
        public UCBiranjeBiblioteke UCBiranjeBiblioteke { get; set; }

        internal UserControl NapraviUCBiranjeBiblioteke(ClanKontroler clanKontroler)
        {
            UCBiranjeBiblioteke = new UCBiranjeBiblioteke();

            return UCBiranjeBiblioteke;
        }
    }
}
