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
    public class ClanBibliotekaTests
    {
        private readonly ClanBiblioteka _clanBiblioteka;

        public ClanBibliotekaTests()
        {
            _clanBiblioteka = new ClanBiblioteka(); 
        }

        public void ClanBiblioteka_SetDatumUclanjenja()
        {
            //Act
            _clanBiblioteka.DatumUclanjenja = DateTime.Now;
            //Assert
            _clanBiblioteka.DatumUclanjenja.Should().BeAfter(1.January(2010));
            _clanBiblioteka.DatumUclanjenja.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void ClanBiblioteka_SetBiblioteka()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            _clanBiblioteka.Biblioteka = biblioteka;
            //Assert
            _clanBiblioteka.Biblioteka.Should().NotBeNull();
            _clanBiblioteka.Biblioteka.Should().BeOfType<Biblioteka>();
            _clanBiblioteka.Biblioteka.Should().Be(biblioteka);
        }

        [Fact]
        public void ClanBiblioteka_SetClan()
        {
            //Act
            Clan clan = new Clan
            {
                IDClan = 1,
                ImePrezime = "Dusan Stoimenovic",
                KorisnickoIme = "dusann14",
                Lozinka = "123456",
                Prijavljen = true,
                DatumRodjenja = DateTime.Now,
            };
            _clanBiblioteka.Clan = clan;    
            //Assert
            _clanBiblioteka.Clan.Should().NotBeNull();
            _clanBiblioteka.Clan.Should().BeOfType<Clan>();
            _clanBiblioteka.Clan.Should().Be(clan);
        }

        [Fact]
        public void ClanBiblioteka_SetUslov()
        {
            //Act
            _clanBiblioteka.Uslov = "neki uslov";
            //Assert
            _clanBiblioteka.Uslov.Should().NotBeNullOrWhiteSpace();
            _clanBiblioteka.Uslov.Should().Be("neki uslov");
        }

        [Fact]
        public void ClanBiblioteka_ToString_ReturnString()
        {
            //Act
            Clan clan = new Clan
            {
                IDClan = 1,
                ImePrezime = "Dusan Stoimenovic",
                KorisnickoIme = "dusann14",
                Lozinka = "123456",
                Prijavljen = true,
                DatumRodjenja = DateTime.Now,
            };
            _clanBiblioteka.Clan = clan;
            _clanBiblioteka.DatumUclanjenja = DateTime.Now;
            //Assert
            _clanBiblioteka.ToString().Should().NotBeNullOrWhiteSpace();
            _clanBiblioteka.ToString().Should().Contain(_clanBiblioteka.Clan.ImePrezime);
            _clanBiblioteka.ToString().Should().Contain(_clanBiblioteka.DatumUclanjenja.ToString());
        }

    }
}
