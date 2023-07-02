using Common.Domen;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Test.DomenTests
{
    public class BibliotekarTests
    {

        private readonly Bibliotekar _bibliotekar;

        public BibliotekarTests()
        {
            _bibliotekar = new Bibliotekar();
        }

        [Fact]
        public void Bibliotekar_SetIDBibliotekar()
        {
            //Act
            _bibliotekar.IDBibliotekar = 1;
            //Assert
            _bibliotekar.IDBibliotekar.Should().BeGreaterThanOrEqualTo(0);
            _bibliotekar.IDBibliotekar.Should().Be(1);
        }

        [Fact]
        public void Bibliotekar_SetImePrezime()
        {
            //Act
            _bibliotekar.ImePrezime = "Dusan Stoimenovic";
            //Assert
            _bibliotekar.ImePrezime.Should().NotBeNullOrWhiteSpace();
            _bibliotekar.ImePrezime.Should().Be("Dusan Stoimenovic");
        }

        [Fact]
        public void Bibliotekar_SetKorisnickoIme()
        {
            //Act
            _bibliotekar.KorisnickoIme = "dusann14";
            //Assert
            _bibliotekar.KorisnickoIme.Should().NotBeNullOrWhiteSpace();
            _bibliotekar.KorisnickoIme.Should().Be("dusann14");
        }

        [Fact]
        public void Bibliotekar_SetLozinka()
        {
            //Act
            _bibliotekar.Lozinka = "123456";
            //Assert
            _bibliotekar.Lozinka.Should().NotBeNullOrWhiteSpace();
            _bibliotekar.Lozinka.Should().Be("123456");
        }

        [Fact]
        public void Bibliotekar_SetPrijavljen()
        {
            //Act
            _bibliotekar.Prijavljen = true;
            //Assert
            _bibliotekar.Prijavljen.Should().BeTrue();
            _bibliotekar.Prijavljen.Should().NotBe(false);
        }

        [Fact]
        public void Bibliotekar_SetDatumRodjenja()
        {
            //Act
            _bibliotekar.DatumRodjenja = DateTime.Now;
            //Assert
            _bibliotekar.DatumRodjenja.Should().BeAfter(1.January(2010));
            _bibliotekar.DatumRodjenja.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void Bibliotekar_SetBiblioteka()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            _bibliotekar.Biblioteka = biblioteka;
            //Assert
            _bibliotekar.Biblioteka.Should().NotBeNull();
            _bibliotekar.Biblioteka.Should().BeOfType<Biblioteka>();
            _bibliotekar.Biblioteka.Should().Be(biblioteka);
        }

        [Fact]
        public void Bibliotekar_SetUslov()
        {
            //Act
            _bibliotekar.Uslov = "neki uslov";
            //Assert
            _bibliotekar.Uslov.Should().NotBeNullOrWhiteSpace();
            _bibliotekar.Uslov.Should().Be("neki uslov");
        }

    }
}
