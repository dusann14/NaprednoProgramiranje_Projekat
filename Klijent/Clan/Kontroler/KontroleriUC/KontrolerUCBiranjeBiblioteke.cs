using Common.Domen;
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
            UCBiranjeBiblioteke.button1.Click += (s, e) => UdjiUBiblioteku(clanKontroler);
            UCBiranjeBiblioteke.dataGridView1.DataSource = clanKontroler.BibliotekeClana;

            return UCBiranjeBiblioteke;
        }

        private void UdjiUBiblioteku(ClanKontroler clanKontroler)
        {

            if (UCBiranjeBiblioteke.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali biblioteku");
                return;
            }

            if (UCBiranjeBiblioteke.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu biblioteku");
                return;
            }
            clanKontroler.IzabranaBiblioteka = (Biblioteka)UCBiranjeBiblioteke.dataGridView1.SelectedRows[0].DataBoundItem;
            MessageBox.Show("Dobrodosli u " + clanKontroler.IzabranaBiblioteka.Ime);
            clanKontroler.FrmClan.menuStrip1.Visible = true;
            Koordinator.Instance.OtvoriUCHomeClan(clanKontroler);
        }
    }
}
