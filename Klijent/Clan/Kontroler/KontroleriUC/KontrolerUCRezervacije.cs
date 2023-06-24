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
    public class KontrolerUCRezervacije
    {
        public UCRezervacije UCRezervacije { get; set; }

        internal UserControl NapraviUCRezervacije(ClanKontroler clanKontroler)
        {
            UCRezervacije = new UCRezervacije();
            UCRezervacije.dataGridView1.CellClick += (s, e) => VratiStavke(clanKontroler, e);
            UCRezervacije.dataGridView1.DataSource = VratiRezervacijeClana(clanKontroler);
            return UCRezervacije;
        }

        private void VratiStavke(ClanKontroler clanKontroler, DataGridViewCellEventArgs e)
        {
            Rezervacija rezervacija = (Rezervacija)UCRezervacije.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Odgovor o = Komunikacija.Instance.VratiStavkeRezervacije(rezervacija);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return;
            }

            UCRezervacije.dataGridView2.DataSource = (List<Stavka>)o.Rezultat;
        }

        private List<Rezervacija> VratiRezervacijeClana(ClanKontroler clanKontroler)
        {
            Odgovor o = Komunikacija.Instance.VratiRezervacijeClana(clanKontroler.Clan, clanKontroler.IzabranaBiblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<Rezervacija>)o.Rezultat;
        }
    }
}
