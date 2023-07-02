using Common.Domen;
using Common.SistemskeOperacije.KnjigaSO;
using FluentAssertions;

namespace Server.Test
{
    public class KontrolerTests
    {

        [Fact]
        public void Kontroler_VratiKnjigeIzBiblioteke_ReturnListKnjiga()
        {
            //Act
            //dodavanje nekoliko knjiga u bazu
            Knjiga knjiga1 = new Knjiga
            {
                Naslov = "Naslov1",
                BrojPrimeraka = 100,
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                },
                Autor = new Autor
                {
                    IDAutor = 1
                }
            };

            Knjiga knjiga2 = new Knjiga
            {
                Naslov = "Naslov2",
                BrojPrimeraka = 100,
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                },
                Autor = new Autor
                {
                    IDAutor = 1
                }
            };

            Knjiga knjiga3 = new Knjiga
            {
                Naslov = "Naslov3",
                BrojPrimeraka = 100,
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                },
                Autor = new Autor
                {
                    IDAutor = 1
                }
            };

            List<Knjiga> listaZaDodavanje = new List<Knjiga>();

            listaZaDodavanje.Add(knjiga1);
            listaZaDodavanje.Add(knjiga2);
            listaZaDodavanje.Add(knjiga3);

            //upisivanje u bazu
            DodajKnjiguSO operacijaZaDodavanje = new DodajKnjiguSO();

            operacijaZaDodavanje.Template(knjiga1);
            knjiga1.IDKnjiga = operacijaZaDodavanje.Rezultat;
            operacijaZaDodavanje.Template(knjiga2);
            knjiga2.IDKnjiga = operacijaZaDodavanje.Rezultat;
            operacijaZaDodavanje.Template(knjiga3);
            knjiga3.IDKnjiga = operacijaZaDodavanje.Rezultat;

            //citanje dodatih knjiga iz baze
            VratiSveKnjigeSO operacijaZaCitanje = new VratiSveKnjigeSO();
            
            operacijaZaCitanje.Template(new Knjiga
            {
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                }
            });
            List<Knjiga> procitaneKnjige = operacijaZaCitanje.Rezultat;

            //Assert
            procitaneKnjige.Should().NotBeNullOrEmpty();
            procitaneKnjige.Should().HaveCount(3);

            //brisanje unetih knjiga
            ObrisiKnjiguSO operacijaZaBrisanje = new ObrisiKnjiguSO();
            operacijaZaBrisanje.Template(knjiga1);
            operacijaZaBrisanje.Template(knjiga2);
            operacijaZaBrisanje.Template(knjiga3);
        }

    }
}