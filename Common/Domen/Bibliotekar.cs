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
    public class Bibliotekar : IEntitet
    {
        [Browsable(false)]
        public int IDBibliotekar { get; set; }

        public string ImePrezime { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }

        public bool Prijavljen { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public Biblioteka Biblioteka { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Bibliotekar";
        [Browsable(false)]
        public string UbaciVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinUslov => "join Biblioteka b on (bib.IDBiblioteka = b.IDBiblioteka)";
        [Browsable(false)]
        public string Alias => "bib";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => $"ImePrezime = '{ImePrezime}', KorisnickoIme = '{KorisnickoIme}', Lozinka = '{Lozinka}', DatumRodjenja = '{DatumRodjenja}', IDBiblioteka = {Biblioteka.IDBiblioteka}, Prijavljen = '{Prijavljen}'";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Bibliotekar
            {
                IDBibliotekar = (int)reader[0],
                ImePrezime = (string)reader[1],
                KorisnickoIme = (string)reader[2],
                Lozinka = (string)reader[3],
                Prijavljen = (bool)reader[4],
                DatumRodjenja = (DateTime)reader[5],
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = (int)reader[7],
                    Ime = (string)reader[8],
                    Adresa = (string)reader[9],
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read())
            {
                entiteti.Add(new Bibliotekar
                {
                    IDBibliotekar = (int)reader[0],
                    ImePrezime = (string)reader[1],
                    KorisnickoIme = (string)reader[2],
                    Lozinka = (string)reader[3],
                    Prijavljen = (bool)reader[4],
                    DatumRodjenja = (DateTime)reader[5],
                    Biblioteka = new Biblioteka
                    {
                        IDBiblioteka = (int)reader[7],
                        Ime = (string)reader[8],
                        Adresa = (string)reader[9],
                    }
                });

            }
            return entiteti;
        }
    }
}
