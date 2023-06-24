using Common.Domen;
using Common.Transfer;
using Klijent.Bibliotekar.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Bibliotekar.Kontroler.KontroleriUC
{
    public class KontrolerUCObradjeneRez
    {
        public UCObradjeneRezervacije UCObradjeneRez { get; set; }

        internal UserControl NapraviUCObradjeneRez(Common.Domen.Bibliotekar bibliotekar)
        {
            UCObradjeneRez = new UCObradjeneRezervacije();
            UCObradjeneRez.dataGridView1.DataSource = VratiObradjeneRezervacije(bibliotekar.Biblioteka);
            UCObradjeneRez.dataGridView1.CellClick += (s, e) => VratiStavke(e);
            return UCObradjeneRez;
        }

        private void VratiStavke(DataGridViewCellEventArgs e)
        {
            Rezervacija rezervacija = (Rezervacija)UCObradjeneRez.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Odgovor o = Komunikacija.Instance.VratiStavkeRezervacije(rezervacija);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return;
            }

            UCObradjeneRez.dataGridView2.DataSource = (List<Stavka>)o.Rezultat;
        }

        private List<Rezervacija> VratiObradjeneRezervacije(Biblioteka biblioteka)
        {
            Odgovor o = Komunikacija.Instance.VratiObradjeneRezervacije(biblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<Rezervacija>)o.Rezultat;
        }
    }
}
