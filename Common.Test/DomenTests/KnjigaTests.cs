using Common.Domen;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Test.DomenTests
{
    public class KnjigaTests
    {
        private readonly Knjiga _knjiga;

        public KnjigaTests()
        {
            _knjiga = new Knjiga();
        }

        [Fact]
        public void Knjiga_SetIDKnjiga()
        {
            //Act
            _knjiga.IDKnjiga = 1;
            //Assert
            _knjiga.IDKnjiga.Should().BeGreaterThanOrEqualTo(0);
            _knjiga.IDKnjiga.Should().Be(1);
        }

        [Fact]
        public void Knjiga_SetNaslov()
        {
            //Act
            _knjiga.Naslov = "Bela griva";
            //Assert
            _knjiga.Naslov.Should().NotBeNullOrWhiteSpace();
            _knjiga.Naslov.Should().Be("Bela griva");
        }

        [Fact]
        public void Knjiga_SetBrojPrimeraka()
        {
            //Act
            _knjiga.BrojPrimeraka = 100;
            //Assert
            _knjiga.BrojPrimeraka.Should().BeGreaterThanOrEqualTo(0);
            _knjiga.BrojPrimeraka.Should().Be(100);
        }

        [Fact]
        public void Knjiga_SetAutor()
        {
            //Act
            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Autor autor = new Autor
            {
                IDAutor = 1,
                ImePrezime = "Dusan Stoimenovic",
                Biblioteka = biblioteka
            };
            _knjiga.Autor = autor;

            //Assert
            _knjiga.Autor.Should().NotBeNull();
            _knjiga.Autor.Should().BeOfType<Autor>();
            _knjiga.Autor.Should().Be(autor);
        }

        [Fact]
        public void Knjiga_SetBiblioteka()
        {
            //Act
            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            _knjiga.Biblioteka = biblioteka;
            //Assert
            _knjiga.Biblioteka.Should().NotBeNull();
            _knjiga.Biblioteka.Should().BeOfType<Biblioteka>();
            _knjiga.Biblioteka.Should().Be(biblioteka);
        }

        [Fact]
        public void Bibliotekar_SetUslov()
        {
            //Act
            _knjiga.Uslov = "neki uslov";
            //Assert
            _knjiga.Uslov.Should().NotBeNullOrWhiteSpace();
            _knjiga.Uslov.Should().Be("neki uslov");
        }

        [Fact]
        public void Knjiga_ToString_ReturnString()
        {
            //Act
            _knjiga.Naslov = "Bela griva";
            //Assert
            _knjiga.ToString().Should().NotBeNullOrWhiteSpace();
            _knjiga.ToString().Should().Contain(_knjiga.Naslov);
        }

    }
}
