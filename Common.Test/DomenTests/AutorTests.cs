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


        [Fact]
        public void Autor_SetImePrezime()
        {
            //Act
            _autor.ImePrezime = "Dusan Stoimenovic";
            //Assert
            _autor.ImePrezime.Should().NotBeNullOrWhiteSpace();
            _autor.ImePrezime.Should().Be("Dusan Stoimenovic");
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
        public void Autor_ToString()
        {
            //Act
            _autor.ImePrezime = "Dusan Stoimenovic";
            //Assert
            _autor.ToString().Should().NotBeNullOrWhiteSpace();
            _autor.ToString().Should().Contain("Dusan Stoimenovic");
        }

    }
}
