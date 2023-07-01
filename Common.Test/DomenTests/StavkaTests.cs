using Common.Domen;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Test.DomenTests
{
    public class StavkaTests
    {

        private readonly Stavka _stavka;

        public StavkaTests()
        {
            _stavka = new Stavka();
        }

        [Fact]
        public void Stavka_SetIDStavka()
        {
            //Act
            _stavka.IDStavka = 1;
            //Assert
            _stavka.IDStavka.Should().BeGreaterThanOrEqualTo(0);
            _stavka.IDStavka.Should().Be(1);
        }

        [Fact]
        public void Stavka_SetKnjiga()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Knjiga knjiga = new Knjiga
            {
                IDKnjiga = 1,
                Naslov = "Bela griva",
                Biblioteka = biblioteka,
                Autor = new Autor
                {
                    IDAutor = 1,
                    Biblioteka = biblioteka,
                    ImePrezime = "Rene Gijo"
                },
                BrojPrimeraka = 100
            };

            _stavka.Knjiga = knjiga;

            //Assert
            _stavka.Knjiga.Should().NotBeNull();
            _stavka.Knjiga.Should().BeOfType<Knjiga>();
            _stavka.Knjiga.Should().Be(knjiga);
        }

        [Fact]
        public void Stavka_SetRezervacija()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Rezervacija rezervacija = new Rezervacija
            {
                Biblioteka = biblioteka,
                DatumTrajanja = DateTime.Now,
                IDRezervacija = 1,
                Clan = new Clan
                {
                    IDClan = 1,
                    ImePrezime = "Dusan Stoimenovic",
                    KorisnickoIme = "dusann14",
                    Lozinka = "123456",
                    Prijavljen = true,
                    DatumRodjenja = DateTime.Now,
                }
            };

            _stavka.Rezervacija = rezervacija;

            //Assert
            _stavka.Rezervacija.Should().NotBeNull();
            _stavka.Rezervacija.Should().BeOfType<Rezervacija>();
            _stavka.Rezervacija.Should().Be(rezervacija);
        }

        [Fact]
        public void Stavka_SetUslov()
        {
            //Act
            _stavka.Uslov = "neki uslov";
            //Assert
            _stavka.Uslov.Should().NotBeNullOrWhiteSpace();
            _stavka.Uslov.Should().Be("neki uslov");
        }

    }
}
