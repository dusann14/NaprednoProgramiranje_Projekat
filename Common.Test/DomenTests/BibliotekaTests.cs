using Common.Domen;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Test.DomenTests
{
    public class BibliotekaTests
    {

        private readonly Biblioteka _biblioteka;

        public BibliotekaTests()
        {
            _biblioteka = new Biblioteka(); 
        }

        [Fact]
        public void Biblioteka_SetIDBiblioteka()
        {
            //Act
            _biblioteka.IDBiblioteka = 1;
            //Asssert
            _biblioteka.IDBiblioteka.Should().BeGreaterThanOrEqualTo(0);
            _biblioteka.IDBiblioteka.Should().Be(1);
        }

        [Fact]
        public void Biblioteka_SetIme()
        {
            //Act
            _biblioteka.Ime = "Laguna";
            //Asssert
            _biblioteka.Ime.Should().NotBeNullOrWhiteSpace();
            _biblioteka.Ime.Should().Be("Laguna");
        }

        [Fact]
        public void Biblioteka_SetAdresa()
        {
            //Act
            _biblioteka.Ime = "Jove Ilica 153";
            //Asssert
            _biblioteka.Ime.Should().NotBeNullOrWhiteSpace();
            _biblioteka.Ime.Should().Be("Jove Ilica 153");
        }

        [Fact]
        public void Biblioteka_SetUslov()
        {
            //Act
            _biblioteka.Uslov = "neki uslov";
            //Asssert
            _biblioteka.Uslov.Should().NotBeNullOrWhiteSpace();
            _biblioteka.Uslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void Biblioteka_ToString_ReturnString()
        {
            //Act
            _biblioteka.Ime = "Laguna";
            //Asssert
            _biblioteka.ToString().Should().NotBeNullOrWhiteSpace();
            _biblioteka.ToString().Should().Contain(_biblioteka.Ime);
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        public void Biblioteka_Equals_ReturnBool(int a, int b, bool result)
        {
            //Act
            _biblioteka.IDBiblioteka = a;

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = b
            };
            //Asssert
            _biblioteka.Equals(biblioteka).Should().Be(result);
        }

        [Fact]
        public void Biblioteka_EqualsNull_ReturnBool()
        {
            //Act
            //Asssert
            _biblioteka.Equals(null).Should().BeFalse();
        }


        [Fact]
        public void Biblioteka_EqualsDrugaKlasa_ReturnBool()
        {
            //Act
            //Asssert
            _biblioteka.Equals(new Autor()).Should().BeFalse();
        }

    }
}
