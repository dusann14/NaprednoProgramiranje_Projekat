using Common.Domen;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Test.DomenTests
{
    public class IEntitetTests
    {
        private readonly IEntitet _entitetAutor;
        private readonly IEntitet _entitetBiblioteka;
        private readonly IEntitet _entitetBibliotekar;
        private readonly IEntitet _entitetClan;
        private readonly IEntitet _entitetClanBiblitoteka;
        private readonly IEntitet _entitetKnjiga;
        private readonly IEntitet _entitetRezervacija;
        private readonly IEntitet _entitetStavka;

        public IEntitetTests()
        {
            _entitetAutor = new Autor();
            _entitetBiblioteka = new Biblioteka();
            _entitetBibliotekar = new Bibliotekar();    
            _entitetClan = new Clan();
            _entitetClanBiblitoteka = new ClanBiblioteka();
            _entitetKnjiga = new Knjiga();
            _entitetRezervacija = new Rezervacija();
            _entitetStavka = new Stavka();
        }

        [Fact]
        public void Autor_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetAutor.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetAutor.ImeTabele.Should().Be("Autor");
        }

        [Fact]
        public void Autor_UbaciVrednosti_ReturnString()
        {
            //Act
            //Assert
            _entitetAutor.UbaciVrednosti.Should().NotBeNull();
            _entitetAutor.UbaciVrednosti.Should().BeEmpty();
        }

        [Fact]
        public void Autor_IdName_ReturnString()
        {
            //Act
            //Assert
            _entitetAutor.IdName.Should().NotBeNullOrWhiteSpace();
            _entitetAutor.IdName.Should().Be("IDAutor");
        }

        [Fact]
        public void Autor_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetAutor.JoinUslov.Should().NotBeNullOrWhiteSpace();
            _entitetAutor.JoinUslov.Should().Be("join Biblioteka b on (b.IDBiblioteka = a.IDBiblioteka)");
        }

        [Fact]
        public void Autor_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetAutor.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetAutor.Alias.Should().Be("a");
        }

        [Fact]
        public void Autor_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetAutor.Select.Should().NotBeNullOrWhiteSpace();
            _entitetAutor.Select.Should().Be("*");
        }

        [Fact]
        public void Autor_WhereUslov_ReturnString()
        {
            //Act
            Autor autor = (Autor)_entitetAutor;
            autor.Uslov = "neki uslov";
            //Assert
            _entitetAutor.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetAutor.WhereUslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void Autor_UpdateVrednosti_ReturnString()
        {
            //Act
            //Assert
            _entitetAutor.UpdateVrednosti.Should().NotBeNull();
            _entitetAutor.UpdateVrednosti.Should().BeEmpty();
        }

        //----------------------------------------------------------------

        [Fact]
        public void Biblioteka_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetBiblioteka.ImeTabele.Should().Be("Biblioteka");
        }

        [Fact]
        public void Biblioteka_UbaciVrednosti_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.UbaciVrednosti.Should().NotBeNull();
            _entitetBiblioteka.UbaciVrednosti.Should().BeEmpty();
        }

        [Fact]
        public void Biblioteka_IdName_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.IdName.Should().NotBeNullOrWhiteSpace();
            _entitetBiblioteka.IdName.Should().Be("IDBiblioteka");
        }

        [Fact]
        public void Biblioteka_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.JoinUslov.Should().NotBeNull();
            _entitetBiblioteka.JoinUslov.Should().BeEmpty();
        }

        [Fact]
        public void Biblioteka_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetBiblioteka.Alias.Should().Be("b");
        }

        [Fact]
        public void Biblioteka_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.Select.Should().NotBeNullOrWhiteSpace();
            _entitetBiblioteka.Select.Should().Be("*");
        }

        [Fact]
        public void Biblioteka_WhereUslov_ReturnString()
        {
            //Act
            Biblioteka biblioteka = (Biblioteka)_entitetBiblioteka;
            biblioteka.Uslov = "neki uslov";
            //Assert
            _entitetBiblioteka.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetBiblioteka.WhereUslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void Biblioteka_UpdateVrednosti_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.UpdateVrednosti.Should().NotBeNull();
            _entitetBiblioteka.UpdateVrednosti.Should().BeEmpty();
        }

        //--------------------------------------------------------------------------

        [Fact]
        public void Bibliotekar_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetBibliotekar.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetBibliotekar.ImeTabele.Should().Be("Bibliotekar");
        }

        [Fact]
        public void Bibliotekar_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetBibliotekar.JoinUslov.Should().NotBeNullOrWhiteSpace();
            _entitetBibliotekar.JoinUslov.Should().Be("join Biblioteka b on (bib.IDBiblioteka = b.IDBiblioteka)");
        }

        [Fact]
        public void Bibliotekar_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetBibliotekar.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetBibliotekar.Alias.Should().Be("bib");
        }

        [Fact]
        public void Bibliotekar_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetBibliotekar.Select.Should().NotBeNullOrWhiteSpace();
            _entitetBibliotekar.Select.Should().Be("*");
        }

        [Fact]
        public void Bibliotekar_WhereUslov_ReturnString()
        {
            //Act
            Bibliotekar bibliotekar = (Bibliotekar)_entitetBibliotekar;
            bibliotekar.Uslov = "neki uslov";
            //Assert
            _entitetBibliotekar.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetBibliotekar.WhereUslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void Bibliotekar_UpdateVrednosti_ReturnString()
        {
            //Act
            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Bibliotekar bibliotekar = (Bibliotekar)_entitetBibliotekar;
            bibliotekar.ImePrezime = "Dusan Stoimenovic";
            bibliotekar.KorisnickoIme = "dusann14";
            bibliotekar.Lozinka = "123456";
            bibliotekar.Prijavljen = true;
            bibliotekar.DatumRodjenja = DateTime.Now;
            bibliotekar.Biblioteka = biblioteka;
            //Assert
            _entitetBibliotekar.UpdateVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetBibliotekar.UpdateVrednosti.Should().Contain(bibliotekar.KorisnickoIme);
            _entitetBibliotekar.UpdateVrednosti.Should().Contain(bibliotekar.ImePrezime);
            _entitetBibliotekar.UpdateVrednosti.Should().Contain(bibliotekar.Lozinka);
            _entitetBibliotekar.UpdateVrednosti.Should().Contain(bibliotekar.Prijavljen.ToString());
            _entitetBibliotekar.UpdateVrednosti.Should().Contain(bibliotekar.DatumRodjenja.ToString());
            _entitetBibliotekar.UpdateVrednosti.Should().Contain(bibliotekar.Biblioteka.IDBiblioteka.ToString());
        }

        //-------------------------------------------------------------------------------------------

        [Fact]
        public void Clan_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetClan.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetClan.ImeTabele.Should().Be("Clan");
        }

        [Fact]
        public void Clan_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetClan.JoinUslov.Should().NotBeNull();
            _entitetClan.JoinUslov.Should().BeEmpty();
        }

        [Fact]
        public void Clan_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetClan.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetClan.Alias.Should().Be("c");
        }

        [Fact]
        public void Clan_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetClan.Select.Should().NotBeNullOrWhiteSpace();
            _entitetClan.Select.Should().Be("*");
        }

        [Fact]
        public void Clan_WhereUslov_ReturnString()
        {
            //Act
            Clan clan = (Clan)_entitetClan;
            clan.Uslov = "neki uslov";
            //Assert
            _entitetClan.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetClan.WhereUslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void Clan_UpdateVrednosti_ReturnString()
        {
            //Act
            Clan clan = (Clan)_entitetClan;
            clan.ImePrezime = "Dusan Stoimenovic";
            clan.KorisnickoIme = "dusann14";
            clan.Lozinka = "123456";
            clan.Prijavljen = true;
            clan.DatumRodjenja = DateTime.Now;
            //Assert
            _entitetClan.UpdateVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetClan.UpdateVrednosti.Should().Contain(clan.KorisnickoIme);
            _entitetClan.UpdateVrednosti.Should().Contain(clan.ImePrezime);
            _entitetClan.UpdateVrednosti.Should().Contain(clan.Lozinka);
            _entitetClan.UpdateVrednosti.Should().Contain(clan.Prijavljen.ToString());
            _entitetClan.UpdateVrednosti.Should().Contain(clan.DatumRodjenja.ToString());
        }

        //------------------------------------------------------------------------------

        [Fact]
        public void ClanBiblioteka_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetClanBiblitoteka.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetClanBiblitoteka.ImeTabele.Should().Be("ClanBiblioteka");
        }

        [Fact]
        public void ClanBiblioteka_UbaciVrednosti_ReturnString()
        {
            //Act

            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Clan clan = new Clan
            {
                IDClan = 1,
                ImePrezime = "Dusan Stoimenovic",
                KorisnickoIme = "dusann14",
                Lozinka = "123456",
                Prijavljen = true,
                DatumRodjenja = DateTime.Now,
            };

            ClanBiblioteka cb = (ClanBiblioteka)_entitetClanBiblitoteka;
            cb.DatumUclanjenja = DateTime.Now;
            cb.Biblioteka = biblioteka;
            cb.Clan = clan;
            //Assert
            _entitetClanBiblitoteka.UbaciVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetClanBiblitoteka.UbaciVrednosti.Should().Contain(cb.DatumUclanjenja.ToString());
            _entitetClanBiblitoteka.UbaciVrednosti.Should().Contain(cb.Clan.IDClan.ToString());
            _entitetClanBiblitoteka.UbaciVrednosti.Should().Contain(cb.Biblioteka.IDBiblioteka.ToString());
        }

        [Fact]
        public void ClanBiblioteka_IdName_ReturnString()
        {
            //Act
            //Assert
            _entitetClanBiblitoteka.IdName.Should().NotBeNullOrWhiteSpace();
            _entitetClanBiblitoteka.IdName.Should().Be("IDClan");
        }

        [Fact]
        public void ClanBiblioteka_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetClanBiblitoteka.JoinUslov.Should().NotBeNullOrWhiteSpace();
            _entitetClanBiblitoteka.JoinUslov.Should().Be("join Biblioteka b on (b.IDBiblioteka = cb.IDBiblioteka) join Clan c on (c.IDClan = cb.IDClan)");
        }

        [Fact]
        public void ClanBiblioteka_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetClanBiblitoteka.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetClanBiblitoteka.Alias.Should().Be("cb");
        }

        [Fact]
        public void ClanBiblioteka_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetClanBiblitoteka.Select.Should().NotBeNullOrWhiteSpace();
            _entitetClanBiblitoteka.Select.Should().Be("*");
        }

        [Fact]
        public void ClanBiblioteka_WhereUslov_ReturnString()
        {
            //Act
            ClanBiblioteka cb = (ClanBiblioteka)_entitetClanBiblitoteka;
            cb.Uslov = "neki uslov";
            //Assert
            _entitetClanBiblitoteka.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetClanBiblitoteka.WhereUslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void ClanBiblioteka_UpdateVrednosti_ReturnString()
        {
            //Act
            //Assert
            _entitetBiblioteka.UpdateVrednosti.Should().NotBeNull();
            _entitetBiblioteka.UpdateVrednosti.Should().BeEmpty();
        }

        //-------------------------------------------------------------------------

        [Fact]
        public void Knjiga_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetKnjiga.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.ImeTabele.Should().Be("Knjiga");
        }

        [Fact]
        public void Knjiga_UbaciVrednosti_ReturnString()
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

            Knjiga k = (Knjiga)_entitetKnjiga;
            k.Autor = autor;
            k.Biblioteka = biblioteka;
            k.Naslov = "Naslov";
            k.BrojPrimeraka = 100;

            //Assert
            _entitetKnjiga.UbaciVrednosti.Should().NotBeNull();
            _entitetKnjiga.UbaciVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.UbaciVrednosti.Should().Contain(k.Autor.IDAutor.ToString());
            _entitetKnjiga.UbaciVrednosti.Should().Contain(k.Naslov);
            _entitetKnjiga.UbaciVrednosti.Should().Contain(k.Biblioteka.IDBiblioteka.ToString());
            _entitetKnjiga.UbaciVrednosti.Should().Contain(k.BrojPrimeraka.ToString());
        }

        [Fact]
        public void Knjiga_IdName_ReturnString()
        {
            //Act
            //Assert
            _entitetKnjiga.IdName.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.IdName.Should().Be("IDKnjiga");
        }

        [Fact]
        public void Knjiga_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetKnjiga.JoinUslov.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.JoinUslov.Should().Be("join Autor a on (a.IDAutor = k.IDAutor) join Biblioteka b on (b.IDBiblioteka = k.IDBiblioteka)");
        }

        [Fact]
        public void Knjiga_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetKnjiga.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.Alias.Should().Be("k");
        }

        [Fact]
        public void Knjiga_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetKnjiga.Select.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.Select.Should().Be("*");
        }

        [Fact]
        public void Knjiga_WhereUslov_ReturnString()
        {
            //Act
            Knjiga knjiga = (Knjiga)_entitetKnjiga;
            knjiga.Uslov = "neki uslov";
            //Assert
            _entitetKnjiga.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.WhereUslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void Knjiga_UpdateVrednosti_ReturnString()
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

            Knjiga k = (Knjiga)_entitetKnjiga;
            k.Autor = autor;
            k.Biblioteka = biblioteka;
            k.Naslov = "Naslov";
            k.BrojPrimeraka = 100;

            //Assert
            _entitetKnjiga.UpdateVrednosti.Should().NotBeNull();
            _entitetKnjiga.UpdateVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetKnjiga.UpdateVrednosti.Should().Contain(k.Autor.IDAutor.ToString());
            _entitetKnjiga.UpdateVrednosti.Should().Contain(k.Naslov);
            _entitetKnjiga.UpdateVrednosti.Should().Contain(k.Biblioteka.IDBiblioteka.ToString());
            _entitetKnjiga.UpdateVrednosti.Should().Contain(k.BrojPrimeraka.ToString());
        }

        //--------------------------------------------------------------------------

        [Fact]
        public void Rezervacija_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetRezervacija.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.ImeTabele.Should().Be("Rezervacija");
        }

        [Fact]
        public void Rezervacija_UbaciVrednosti_ReturnString()
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


            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Rezervacija rezervacija = (Rezervacija)_entitetRezervacija;

            rezervacija.DatumTrajanja = DateTime.Now;
            rezervacija.Clan = clan;
            rezervacija.Biblioteka = biblioteka;
            
            //Assert
            _entitetRezervacija.UbaciVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.UbaciVrednosti.Should().Contain(rezervacija.DatumTrajanja.ToString());
            _entitetRezervacija.UbaciVrednosti.Should().Contain(rezervacija.Clan.IDClan.ToString());
            _entitetRezervacija.UbaciVrednosti.Should().Contain(rezervacija.Biblioteka.IDBiblioteka.ToString());
        }

        [Fact]
        public void Rezervacija_IdName_ReturnString()
        {
            //Act
            //Assert
            _entitetRezervacija.IdName.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.IdName.Should().Be("IDRezervacija");
        }

        [Fact]
        public void Rezervacija_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetRezervacija.JoinUslov.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.JoinUslov.Should().Be("join clan c on (c.IDClan = r.IDClan) join biblioteka b on (b.IDBiblioteka = r.IDBiblioteka) join StatusRezervacije sr on (sr.IDStatus = r.IDStatus)");
        }

        [Fact]
        public void Rezervacija_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetRezervacija.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.Alias.Should().Be("r");
        }

        [Fact]
        public void Rezervacija_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetRezervacija.Select.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.Select.Should().Be("*");
        }

        [Fact]
        public void Rezervacija_WhereUslov_ReturnString()
        {
            //Act
            Rezervacija rezervacija = (Rezervacija)_entitetRezervacija;
            rezervacija.Uslov = "neki uslov";
            //Assert
            _entitetRezervacija.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.WhereUslov.Should().Contain("neki uslov");
        }

        [Fact]
        public void Rezervacija_UpdateVrednosti_ReturnString()
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


            Biblioteka biblioteka = new Biblioteka
            {
                IDBiblioteka = 1,
                Ime = "Laguna",
                Adresa = "Jove Ilica 153"
            };

            Rezervacija rezervacija = (Rezervacija)_entitetRezervacija;

            rezervacija.DatumTrajanja = DateTime.Now;
            rezervacija.Clan = clan;
            rezervacija.Biblioteka = biblioteka;

            //Assert
            _entitetRezervacija.UpdateVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetRezervacija.UpdateVrednosti.Should().Contain(rezervacija.DatumTrajanja.ToString());
            _entitetRezervacija.UpdateVrednosti.Should().Contain(rezervacija.Clan.IDClan.ToString());
            _entitetRezervacija.UpdateVrednosti.Should().Contain(rezervacija.Biblioteka.IDBiblioteka.ToString());
        }

        //----------------------------------------------------------------------

        [Fact]
        public void Stavka_ImeTabele_ReturnString()
        {
            //Act
            //Assert
            _entitetStavka.ImeTabele.Should().NotBeNullOrWhiteSpace();
            _entitetStavka.ImeTabele.Should().Be("Stavka");
        }

        [Fact]
        public void Stavka_UbaciVrednosti_ReturnString()
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

            Stavka stavka = (Stavka)_entitetStavka;
            stavka.Rezervacija = rezervacija;
            stavka.Knjiga = knjiga;

            //Assert
            _entitetStavka.UbaciVrednosti.Should().NotBeNullOrWhiteSpace();
            _entitetStavka.UbaciVrednosti.Should().Contain(stavka.Rezervacija.IDRezervacija.ToString());
            _entitetStavka.UbaciVrednosti.Should().Contain(stavka.Knjiga.IDKnjiga.ToString());
        }

        [Fact]
        public void Stavka_IdName_ReturnString()
        {
            //Act
            //Assert
            _entitetStavka.IdName.Should().NotBeNullOrWhiteSpace();
            _entitetStavka.IdName.Should().Be("IDStavka");
        }

        [Fact]
        public void Stavka_JoinUslov_ReturnString()
        {
            //Act
            //Assert
            _entitetStavka.JoinUslov.Should().NotBeNullOrWhiteSpace();
            _entitetStavka.JoinUslov.Should().Be("join Rezervacija r on (s.IDRezervacija = r.IDRezervacija) join clan c on (c.IDClan = r.IDClan) join Knjiga k on (s.IDKnjiga = k.IDKnjiga) join Autor a on (a.IDAutor = k.IDAutor) join Biblioteka b on (b.IDBiblioteka = k.IDBiblioteka)");
        }

        [Fact]
        public void Stavka_Alias_ReturnString()
        {
            //Act
            //Assert
            _entitetStavka.Alias.Should().NotBeNullOrWhiteSpace();
            _entitetStavka.Alias.Should().Be("s");
        }

        [Fact]
        public void Stavka_Select_ReturnString()
        {
            //Act
            //Assert
            _entitetStavka.Select.Should().NotBeNullOrWhiteSpace();
            _entitetStavka.Select.Should().Be("*");
        }

        [Fact]
        public void Stavka_WhereUslov_ReturnString()
        {
            //Act
            Stavka stavka = (Stavka)_entitetStavka;
            stavka.Uslov = "neki uslov";
            //Assert
            _entitetStavka.WhereUslov.Should().NotBeNullOrWhiteSpace();
            _entitetStavka.WhereUslov.Should().Contain("neki uslov");
        }

    }
}
