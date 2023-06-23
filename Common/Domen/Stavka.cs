using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    [Serializable]
    public class Stavka : IEntitet
    {
        [Browsable(false)]
        public int IDStavka { get; set; }

        [Browsable(false)]
        public Rezervacija Rezervacija { get; set; }

        public Knjiga Knjiga { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Stavka";
        [Browsable(false)]
        public string UbaciVrednosti => $"{Rezervacija.IDRezervacija}, {Knjiga.IDKnjiga}";
        [Browsable(false)]
        public string IdName => "IDStavka";
        [Browsable(false)]
        public string JoinUslov => "join Rezervacija r on (s.IDRezervacija = r.IDRezervacija) join clan c on (c.IDClan = r.IDClan) join Knjiga k on (s.IDKnjiga = k.IDKnjiga) join Autor a on (a.IDAutor = k.IDAutor) join Biblioteka b on (b.IDBiblioteka = k.IDBiblioteka)";
        [Browsable(false)]
        public string Alias => "s";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => throw new NotImplementedException();

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                Stavka stavka = new Stavka();

                stavka.IDStavka = (int)reader[0];

                Rezervacija rezervacija = new Rezervacija();
                rezervacija.IDRezervacija = (int)reader[3];
                rezervacija.DatumTrajanja = (DateTime)reader[4];

                Clan clan = new Clan();
                clan.IDClan = (int)reader[8];
                clan.ImePrezime = (string)reader[9];
                clan.KorisnickoIme = (string)reader[10];
                clan.Lozinka = (string)reader[11];
                clan.Prijavljen = (bool)reader[12];
                clan.DatumRodjenja = (DateTime)reader[13];

                Knjiga knjiga = new Knjiga();
                knjiga.IDKnjiga = (int)reader[14];
                knjiga.Naslov = (string)reader[15];
                knjiga.BrojPrimeraka = (int)reader[16];

                Autor autor = new Autor();
                autor.IDAutor = (int)reader[19];
                autor.ImePrezime = (string)reader[20];

                Biblioteka biblioteka = new Biblioteka();
                biblioteka.IDBiblioteka = (int)reader[22];
                biblioteka.Ime = (string)reader[23];
                biblioteka.Adresa = (string)reader[24];

                autor.Biblioteka = biblioteka;
                knjiga.Biblioteka = biblioteka;
                knjiga.Autor = autor;

                stavka.Rezervacija = rezervacija;
                stavka.Knjiga = knjiga;

                entiteti.Add(stavka);
            }

            return entiteti;
        }
    }
}
