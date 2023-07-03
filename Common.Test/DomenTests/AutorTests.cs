using Common.Domen;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Test.DomenTests
{
    public class AutorTests
    {

        private readonly Autor _autor;

        public AutorTests()
        {
            _autor = new Autor();
        }

        [Fact]
        public void Autor_SetIDAutor()
        {
            //Act
            _autor.IDAutor = 1;
            //Assert
            _autor.IDAutor.Should().BeGreaterThanOrEqualTo(0);
            _autor.IDAutor.Should().Be(1);
        }


        [Theory]
        [InlineData("Dusan Stoimenovic", "Dusan Stoimenovic")]
        [InlineData("Marin Cvetkovic", "Martin Cvetkovic")]
        [InlineData("Stefan Ristic", "Stefan Ristic")]
        public void Autor_SetImePrezime(string imePrezime, string ocekivan)
        {
            //Act
            _autor.ImePrezime = imePrezime;
            //Assert
            _autor.ImePrezime.Should().NotBeNullOrWhiteSpace();
            _autor.ImePrezime.Should().Be(ocekivan);
        }

        [Fact]
        public void Autor_SetImePrezimeNijeDobarUnos_ThrowsException()
        {
            //Act and assert
            Assert.Throws<System.ArgumentNullException>(() => _autor.ImePrezime = null);
            Assert.Throws<System.ArgumentNullException>(() => _autor.ImePrezime = "");
        }

        [Fact]
        public void Autor_SetImePrezimeNisuUnetiIImeIPrezime_ThrowsException()
        {
            //Act and assert
            Assert.Throws<System.FormatException>(() => _autor.ImePrezime = "Dusan");
        }

        [Fact]
        public void Autor_SetBiblioteka()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            _autor.Biblioteka = biblioteka;
            //Assert
            _autor.Biblioteka.Should().NotBeNull();
            _autor.Biblioteka.Should().BeOfType<Biblioteka>();  
            _autor.Biblioteka.Should().Be(biblioteka);
        }

        [Fact]
        public void Autor_SetUslov()
        {
            //Act
            _autor.Uslov = "neki uslov";
            //Assert
            _autor.Uslov.Should().NotBeNullOrWhiteSpace();
            _autor.Uslov.Should().Be("neki uslov");
        }

        [Fact] 
        public void Autor_ToString_ReturnString()
        {
            //Act
            _autor.ImePrezime = "Dusan Stoimenovic";
            //Assert
            _autor.ToString().Should().NotBeNullOrWhiteSpace();
            _autor.ToString().Should().Contain(_autor.ImePrezime);
        }

    }
}
