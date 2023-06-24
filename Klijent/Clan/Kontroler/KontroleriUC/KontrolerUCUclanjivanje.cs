using Common.Domen;
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
    public class KontrolerUCUclanjivanje
    {
        public UCUclanjivanje UCUclanjivanje { get; set; }

        internal UserControl NapraviUCUclanjivanje(ClanKontroler clanKontroler)
        {
            UCUclanjivanje = new UCUclanjivanje();
            UCUclanjivanje.button1.Click += (s, e) => UclaniSe(clanKontroler);
            UCUclanjivanje.dataGridView1.DataSource = VratiBiblioteke(clanKontroler.BibliotekeClana);
            return UCUclanjivanje;
        }

        private List<Biblioteka> VratiBiblioteke(List<Biblioteka> bibliotekeClana)
        {
            Odgovor o = Komunikacija.Instance.VratiBiblioteke();

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            List<Biblioteka> biblioteke = (List<Biblioteka>)o.Rezultat;

            biblioteke.RemoveAll(b => bibliotekeClana.Contains(b));
            return biblioteke;
        }

        private void UclaniSe(ClanKontroler clanKontroler)
        {
            if (UCUclanjivanje.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali bilbioteku");
                return;
            }

            if (UCUclanjivanje.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu biblioteku");
                return;
            }

            Biblioteka biblioteka = (Biblioteka)UCUclanjivanje.dataGridView1.SelectedRows[0].DataBoundItem;
            Odgovor o = Komunikacija.Instance.UclaniSe(clanKontroler.Clan, biblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show($"Sistem ne moze da zapamti clanstvo {o.Greska}");
                return;
            }

            clanKontroler.IzabranaBiblioteka = biblioteka;
            clanKontroler.BibliotekeClana.Add(biblioteka);

            MessageBox.Show("Sistem je zapamtio clanstvo: Dobrodosli u " + clanKontroler.IzabranaBiblioteka.Ime);
            clanKontroler.FrmClan.menuStrip1.Visible = true;
            Koordinator.Instance.OtvoriUCHomeClan(clanKontroler);
        }

    }
}
