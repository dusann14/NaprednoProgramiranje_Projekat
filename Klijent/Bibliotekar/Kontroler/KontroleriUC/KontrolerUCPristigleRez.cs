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
    public class KontrolerUCPristigleRez
    {
        public UCPristigleRezervacije UCPristigleRezervacije { get; set; }
        internal UserControl NapraviUCPristigleRez(Common.Domen.Bibliotekar bibliotekar)
        {
            UCPristigleRezervacije = new UCPristigleRezervacije();
            UCPristigleRezervacije.dataGridView1.DataSource = VratiNeobradjeneRezervacije(bibliotekar.Biblioteka);
            UCPristigleRezervacije.button1.Click += (s, e) => ObradiRezervaciju(bibliotekar.Biblioteka);
            UCPristigleRezervacije.dataGridView1.CellClick += (s, e) => VratiStavke(e);
            return UCPristigleRezervacije;
        }

        private void ObradiRezervaciju(Biblioteka biblioteka)
        {
            if (UCPristigleRezervacije.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste odabrali rezervaciju");
                return;
            }

            if (UCPristigleRezervacije.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu rezervaciju");
                return;
            }

            Rezervacija rezervacija = (Rezervacija)UCPristigleRezervacije.dataGridView1.SelectedRows[0].DataBoundItem;
            rezervacija.Status = StatusRezervacije.OBRADJENA;
            Odgovor o = Komunikacija.Instance.ObradiRezervaciju(rezervacija);

            if (!o.Uspesno)
            {
                MessageBox.Show($"Sistem ne moze da obradi rezervaciju: {o.Greska}");
                return;
            }

            MessageBox.Show("Sistem je obradio rezervaciju");
            UCPristigleRezervacije.dataGridView1.DataSource = VratiNeobradjeneRezervacije(biblioteka);
        }

        private void VratiStavke(DataGridViewCellEventArgs e)
        {
            Rezervacija rezervacija = (Rezervacija)UCPristigleRezervacije.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Odgovor o = Komunikacija.Instance.VratiStavkeRezervacije(rezervacija);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return;
            }

            UCPristigleRezervacije.dataGridView2.DataSource = (List<Stavka>)o.Rezultat;
        }

        private List<Rezervacija> VratiNeobradjeneRezervacije(Biblioteka biblioteka)
        {
            Odgovor o = Komunikacija.Instance.VratiNeobradjeneRezervacije(biblioteka);

            if (!o.Uspesno)
            {
                MessageBox.Show(o.Greska);
                return null;
            }

            return (List<Rezervacija>)o.Rezultat;
        }
    }
}
