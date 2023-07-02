using Common.Baza;
using Common.Domen;
using Common.SistemskeOperacije.BibliotekarSO;
using Common.SistemskeOperacije.ClanBibliotekaSO;
using Common.SistemskeOperacije.KnjigaSO;
using Common.SistemskeOperacije.LoginSO;
using FluentAssertions;

namespace Server.Test
{
    public class KontrolerTests
    {
        private readonly IGenerickiRepo _generickiRepo;

        public KontrolerTests()
        {
            _generickiRepo = new GenerickiRepo();
        }

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
        
        [Fact]
        public void Kontroler_PromeniKnjigu()
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

            //promena knjige u bazi
            knjiga1.Naslov = "neki drugi naslov";
            knjiga1.BrojPrimeraka = 120;
            knjiga1.Autor.IDAutor = 3;

            PromeniKnjiguSO o = new PromeniKnjiguSO();
            o.Template(knjiga1);

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
            procitanaKnjiga.Naslov.Should().Be("neki drugi naslov");
            procitanaKnjiga.BrojPrimeraka.Should().Be(120);
            procitanaKnjiga.Autor.IDAutor.Should().Be(3);

            //brisanje unete knjige
            ObrisiKnjiguSO operacijaZaBrisanje = new ObrisiKnjiguSO();
            operacijaZaBrisanje.Template(knjiga1);
        }
        
        [Fact]
        public void Kontroler_PromeniPodatkeBibliotekara()
        {
            //Act
            //ucitavanje postojeceg bibliotekara iz baze
            Bibliotekar bibliotekar = new Bibliotekar
            {
                KorisnickoIme = "trivic99",
                Lozinka = "123456",
                Uslov = $"bib.KorisnickoIme = 'trivic99' and bib.Lozinka = '123456'"
            };

            LoginSO so = new LoginSO();
            so.Template(bibliotekar);

            bibliotekar = (Bibliotekar)so.Rezultat;

            //promena podataka
            bibliotekar.ImePrezime = "Nikola Simic";
            bibliotekar.KorisnickoIme = "nikola1";
            bibliotekar.Lozinka = "1234";
            bibliotekar.Prijavljen = true;
            bibliotekar.Biblioteka = new Biblioteka
            {
                IDBiblioteka = 2
            };
            bibliotekar.DatumRodjenja = DateTime.Now;

            PromeniPodatkeBibliotekaraSO operacijaZaPromenuPodataka = new PromeniPodatkeBibliotekaraSO();
            operacijaZaPromenuPodataka.Template(bibliotekar);

            //ponovno ucitavanje bibliotekara
            so.Template(bibliotekar);

            bibliotekar = (Bibliotekar)so.Rezultat;

            //Assert
            bibliotekar.Should().NotBeNull();
            bibliotekar.ImePrezime.Should().Be("Nikola Simic");
            bibliotekar.KorisnickoIme.Should().Be("nikola1");
            bibliotekar.Lozinka.Should().Be("1234");
            bibliotekar.Biblioteka.IDBiblioteka.Should().Be(2);
            bibliotekar.Prijavljen.Should().Be(true);
        }

        [Fact]
        public void Kontroler_PrikaziSveClanove()
        {
            //Act
            //dodavanje nekoliko clanstava           
            ClanBiblioteka cb1 = new ClanBiblioteka
            {
                Clan = new Clan
                {
                    IDClan = 4
                },
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                },
                DatumUclanjenja = DateTime.Now
            };

            ClanBiblioteka cb2 = new ClanBiblioteka
            {
                Clan = new Clan
                {
                    IDClan = 5
                },
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                },
                DatumUclanjenja = DateTime.Now
            };

            UclaniSeSO operacijaZaUclanjivanje = new UclaniSeSO();
            operacijaZaUclanjivanje.Template(cb1);
            operacijaZaUclanjivanje.Template(cb2);

            //ucitavanje clanstava
            VratiSveClanoveIzBibliotekeSO operacijaZaCitanje = new VratiSveClanoveIzBibliotekeSO();
            operacijaZaCitanje.Template(new ClanBiblioteka
            {
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = 1
                }
            });

            //Assert
            operacijaZaCitanje.Rezultat.Should().NotBeNullOrEmpty();
            operacijaZaCitanje.Rezultat.Should().HaveCount(2);

            //brisanje clanstava
            OtkaziClanstvoSO operacijaZaOtkazivanje = new OtkaziClanstvoSO();
            operacijaZaOtkazivanje.Template(cb1);
            operacijaZaOtkazivanje.Template(cb2);
        }

    }
}