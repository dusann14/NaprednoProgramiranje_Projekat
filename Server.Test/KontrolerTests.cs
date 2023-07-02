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

        [Fact]
        public void Kontroler_VratiKnjigeIzBibliotekePoAutoru_ReturnListKnjiga()
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
                    IDAutor = 3
                }
            };

            //upisivanje u bazu
            DodajKnjiguSO operacijaZaDodavanje = new DodajKnjiguSO();

            operacijaZaDodavanje.Template(knjiga1);
            knjiga1.IDKnjiga = operacijaZaDodavanje.Rezultat;
            operacijaZaDodavanje.Template(knjiga2);
            knjiga2.IDKnjiga = operacijaZaDodavanje.Rezultat;
            operacijaZaDodavanje.Template(knjiga3);
            knjiga3.IDKnjiga = operacijaZaDodavanje.Rezultat;


            //citanje dodatih knjiga iz baze po autoru
            VratiKnjigePoAutoruSO operacijaZaCitanje = new VratiKnjigePoAutoruSO();

            operacijaZaCitanje.Template(new Knjiga
            {
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                },
                Autor = new Autor
                {
                    ImePrezime = "Robert"
                }
            });
            List<Knjiga> procitaneKnjige = operacijaZaCitanje.Rezultat;

            //Assert
            procitaneKnjige.Should().NotBeNullOrEmpty();
            procitaneKnjige.Should().HaveCount(1);

            //brisanje unetih knjiga
            ObrisiKnjiguSO operacijaZaBrisanje = new ObrisiKnjiguSO();
            operacijaZaBrisanje.Template(knjiga1);
            operacijaZaBrisanje.Template(knjiga2);
            operacijaZaBrisanje.Template(knjiga3);
        }

        [Fact]
        public void Kontroler_DodajKnjigu()
        {
            //Act
            //dodavanje knjige u bazu
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

            //upisivanje u bazu
            DodajKnjiguSO operacijaZaDodavanje = new DodajKnjiguSO();

            operacijaZaDodavanje.Template(knjiga1);
            knjiga1.IDKnjiga = operacijaZaDodavanje.Rezultat;

            //citanje dodate knjiga iz baze
            VratiSveKnjigeSO operacijaZaCitanje = new VratiSveKnjigeSO();

            operacijaZaCitanje.Template(new Knjiga
            {
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                }
            });

            Knjiga procitanaKnjiga = operacijaZaCitanje.Rezultat[0];

            //Assert
            operacijaZaCitanje.Rezultat.Should().NotBeNullOrEmpty();
            operacijaZaCitanje.Rezultat.Should().HaveCount(1);

            procitanaKnjiga.IDKnjiga.Should().Be(knjiga1.IDKnjiga);
            procitanaKnjiga.Naslov.Should().Be(knjiga1.Naslov);
            procitanaKnjiga.BrojPrimeraka.Should().Be(knjiga1.BrojPrimeraka);
            procitanaKnjiga.Biblioteka.IDBiblioteka.Should().Be(knjiga1.Biblioteka.IDBiblioteka);
            procitanaKnjiga.Autor.IDAutor.Should().Be(knjiga1.Autor.IDAutor);

            //brisanje unete knjige
            ObrisiKnjiguSO operacijaZaBrisanje = new ObrisiKnjiguSO();
            operacijaZaBrisanje.Template(knjiga1);
        }

        [Fact]
        public void Kontroler_ObrisiKnjigu()
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
                    IDAutor = 3
                }
            };

            //upisivanje u bazu
            DodajKnjiguSO operacijaZaDodavanje = new DodajKnjiguSO();

            operacijaZaDodavanje.Template(knjiga1);
            knjiga1.IDKnjiga = operacijaZaDodavanje.Rezultat;
            operacijaZaDodavanje.Template(knjiga2);
            knjiga2.IDKnjiga = operacijaZaDodavanje.Rezultat;
            operacijaZaDodavanje.Template(knjiga3);
            knjiga3.IDKnjiga = operacijaZaDodavanje.Rezultat;

            //brisanje jedne knjige iz baze
            ObrisiKnjiguSO operacijaZaBrisanje = new ObrisiKnjiguSO();
            operacijaZaBrisanje.Template(knjiga1);

            //citanje ostaliha iz baze
            VratiSveKnjigeSO operacijaZaCitanje = new VratiSveKnjigeSO();

            operacijaZaCitanje.Template(new Knjiga
            {
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                }
            });
            
            //Assert
            operacijaZaCitanje.Rezultat.Should().NotBeNullOrEmpty();
            operacijaZaCitanje.Rezultat.Should().HaveCount(2);
            operacijaZaCitanje.Rezultat.Should().NotContain(knjiga1);

            //brisanje ostalih knjiga
            operacijaZaBrisanje.Template(knjiga2);
            operacijaZaBrisanje.Template(knjiga3);
        }


    }
}