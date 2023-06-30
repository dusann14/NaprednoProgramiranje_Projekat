using Common.Domen;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Test.DomenTests
{
    public class RezervacijaTests
    {

        private readonly Rezervacija _rezervacija;

        public RezervacijaTests()
        {
            _rezervacija = new Rezervacija();   
        }


        [Fact]
        public void Rezervacija_SetIDRezervacija()
        {
            //Act
            _rezervacija.IDRezervacija = 1;
            //Assert
            _rezervacija.IDRezervacija.Should().BeGreaterThanOrEqualTo(0);
            _rezervacija.IDRezervacija.Should().Be(1);
        }

        [Fact]
        public void Clan_SetDatumRodjenja()
        {
            //Act
            _rezervacija.DatumTrajanja = DateTime.Now;
            //Assert
            _rezervacija.DatumTrajanja.Should().BeAfter(1.January(2010));
            _rezervacija.DatumTrajanja.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void Rezervacija_SetClan()
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
            _rezervacija.Clan = clan;
            //Assert
            _rezervacija.Clan.Should().NotBeNull();
            _rezervacija.Clan.Should().BeOfType<Clan>();
            _rezervacija.Clan.Should().Be(clan);
        }

        [Fact]
        public void Rezervacija_SetBiblioteka()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            _rezervacija.Biblioteka = biblioteka;
            //Assert
            _rezervacija.Biblioteka.Should().NotBeNull();
            _rezervacija.Biblioteka.Should().BeOfType<Biblioteka>();
            _rezervacija.Biblioteka.Should().Be(biblioteka);
        }


        [Fact]
        public void Rezervacija_SetStatus()
        {
            //Act
            _rezervacija.Status = StatusRezervacije.NEOBRADJENA;
            //Assert
            _rezervacija.Status.Should().NotBe(StatusRezervacije.OBRADJENA);
            _rezervacija.Status.Should().NotBe(StatusRezervacije.ISTEKLA);
            _rezervacija.Status.Should().Be(StatusRezervacije.NEOBRADJENA);
        }

        [Fact]
        public void Rezervacija_SetStavke()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Stavka s1 = new Stavka
            {
                IDStavka = 1,
                Knjiga = new Knjiga
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
                },
                Rezervacija = _rezervacija
            };

            Stavka s2 = new Stavka
            {
                IDStavka = 2,
                Knjiga = new Knjiga
                {
                    IDKnjiga = 2,
                    Naslov = "Bogati otac, siromasni otac",
                    Biblioteka = biblioteka,
                    Autor = new Autor
                    {
                        IDAutor = 2,
                        Biblioteka = biblioteka,
                        ImePrezime = "Rober Kiosaki"
                    },
                    BrojPrimeraka = 100
                },
                Rezervacija = _rezervacija
            };

            _rezervacija.Stavke = new List<Stavka>();

            _rezervacija.Stavke.Add(s1);
            _rezervacija.Stavke.Add(s2);
            
            //Assert
            _rezervacija.Stavke.Count.Should().Be(2);
            _rezervacija.Stavke[0].Should().Be(s1);
            _rezervacija.Stavke[1].Should().NotBe(s1);
        }

        [Fact]
        public void ClanBibliotek_SetUslov()
        {
            //Act
            _rezervacija.Uslov = "neki uslov";
            //Assert
            _rezervacija.Uslov.Should().NotBeNullOrWhiteSpace();
            _rezervacija.Uslov.Should().Be("neki uslov");
        }

    }
}
