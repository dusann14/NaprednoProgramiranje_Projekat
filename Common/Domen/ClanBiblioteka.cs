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
    public class ClanBiblioteka : IEntitet
    {
        public DateTime DatumUclanjenja { get; set; }

        public Biblioteka Biblioteka { get; set; }

        public Clan Clan { get; set; }

        public override string ToString()
        {
            return $"{Clan}, {DatumUclanjenja}";
        }

        [Browsable(false)]
        public string Uslov { get; set; }

        [Browsable(false)]
        public string ImeTabele => "ClanBiblioteka";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{DatumUclanjenja}', {Biblioteka.IDBiblioteka}, {Clan.IDClan}";
        [Browsable(false)]
        public string IdName => "IDClan";
        [Browsable(false)]
        public string JoinUslov => "join Biblioteka b on (b.IDBiblioteka = cb.IDBiblioteka) join Clan c on (c.IDClan = cb.IDClan)";
        [Browsable(false)]
        public string Alias => "cb";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new ClanBiblioteka
            {
                DatumUclanjenja = (DateTime)reader[0],
                Biblioteka = new Biblioteka
                {
                    IDBiblioteka = (int)reader[3],
                    Ime = (string)reader[4],
                    Adresa = (string)reader[5],
                },
                Clan = new Clan
                {
                    IDClan = (int)reader[6],
                    ImePrezime = (string)reader[7],
                    KorisnickoIme = (string)reader[8],
                    Lozinka = (string)reader[9],
                    Prijavljen = (bool)reader[10],
                    DatumRodjenja = (DateTime)reader[11]
                }
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read())
            {
                entiteti.Add(new ClanBiblioteka
                {
                    DatumUclanjenja = (DateTime)reader[0],
                    Biblioteka = new Biblioteka
                    {
                        IDBiblioteka = (int)reader[3],
                        Ime = (string)reader[4],
                        Adresa = (string)reader[5],
                    },
                    Clan = new Clan
                    {
                        IDClan = (int)reader[6],
                        ImePrezime = (string)reader[7],
                        KorisnickoIme = (string)reader[8],
                        Lozinka = (string)reader[9],
                        Prijavljen = (bool)reader[10],
                        DatumRodjenja = (DateTime)reader[11]
                    }
                });
            }
            return entiteti;
        }
    }
}
