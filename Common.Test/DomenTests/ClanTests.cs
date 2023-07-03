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
    public class ClanTests
    {
        private readonly Clan _clan;

        public ClanTests()
        {
            _clan = new Clan();
        }

        [Fact]
        public void Clan_SetIDClan()
        {
            //Act
            _clan.IDClan = 1;
            //Assert
            _clan.IDClan.Should().BeGreaterThan(0);
            _clan.IDClan.Should().Be(1);
        }

        [Theory]
        [InlineData("Dusan Stoimenovic", "Dusan Stoimenovic")]
        [InlineData("Marin Cvetkovic", "Martin Cvetkovic")]
        [InlineData("Stefan Ristic", "Stefan Ristic")]
        public void Clan_SetImePrezime(string imePrezime, string ocekivan)
        {
            //Act
            _clan.ImePrezime = imePrezime;
            //Assert
            _clan.ImePrezime.Should().NotBeNullOrWhiteSpace();
            _clan.ImePrezime.Should().Be(ocekivan);
        }

        [Fact]
        public void Clan_SetImePrezimeNijeDobarUnos_ThrowsException()
        {
            //Act and assert
            Assert.Throws<System.ArgumentNullException>(() => _clan.ImePrezime = null);
            Assert.Throws<System.ArgumentNullException>(() => _clan.ImePrezime = "");
        }

        [Fact]
        public void Clan_SetImePrezimeNisuUnetiIImeIPrezime_ThrowsException()
        {
            //Act and assert
            Assert.Throws<System.FormatException>(() => _clan.ImePrezime = "Dusan");
        }

        [Fact]
        public void Clan_SetKorisnickoIme()
        {
            //Act
            _clan.KorisnickoIme = "dusann14";
            //Assert
            _clan.KorisnickoIme.Should().NotBeNullOrWhiteSpace();
            _clan.KorisnickoIme.Should().Be("dusann14");
        }

        [Fact]
        public void Clan_SetLozinka()
        {
            //Act
            _clan.Lozinka = "123456";
            //Assert
            _clan.Lozinka.Should().NotBeNullOrWhiteSpace();
            _clan.Lozinka.Should().Be("123456");
        }

        [Fact]
        public void Clanr_SetPrijavljen()
        {
            //Act
            _clan.Prijavljen = true;
            //Assert
            _clan.Prijavljen.Should().BeTrue();
            _clan.Prijavljen.Should().NotBe(false);
        }

        [Fact]
        public void Clan_SetDatumRodjenja()
        {
            //Act
            _clan.DatumRodjenja = DateTime.Now;
            //Assert
            _clan.DatumRodjenja.Should().BeAfter(1.January(2010));
            _clan.DatumRodjenja.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void Clan_SetDatumRodjenjaNijeDobarUnos_ThrowsException()
        {
            //Act and assert
            Assert.Throws<System.FormatException>(() => _clan.DatumRodjenja = 1.January(2030));
        }

        [Fact]
        public void Clan_SetUslov()
        {
            //Act
            _clan.Uslov = "neki uslov";
            //Assert
            _clan.Uslov.Should().NotBeNullOrWhiteSpace();
            _clan.Uslov.Should().Be("neki uslov");
        }

        [Fact]
        public void Clan_ToString_ReturnString()
        {
            //Act
            _clan.ImePrezime = "Dusan Stoimenovic";
            //Assert
            _clan.ToString().Should().NotBeNullOrWhiteSpace();
            _clan.ToString().Should().Contain(_clan.ImePrezime);
        }

    }
}
