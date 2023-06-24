using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan.Kontroler
{
    public class ClanKontroler
    {
        public FrmClan FrmClan { get; set; }
        public Common.Domen.Clan Clan { get; set; }

        public List<Biblioteka> BibliotekeClana { get; set; }

        public Biblioteka IzabranaBiblioteka { get; set; }

        public FrmClan NapraviClanFormu()
        {
            FrmClan = new FrmClan();
            
            return FrmClan;
        }

        internal void OdjaviSe()
        {
            try
            {
                Komunikacija.Instance.OdjaviSe(Clan);
                MessageBox.Show("Uspesno ste se odjavili");
                FrmClan.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
