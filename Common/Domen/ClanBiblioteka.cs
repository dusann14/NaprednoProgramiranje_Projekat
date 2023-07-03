using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Predstavlja entitet objekta koji predstvalja clana koji je uclanjen u jednu specificu biblioteku. Implementira interfejs IEntitet i serijabilna je klasa.
    /// </summary>
    [Serializable]
    public class ClanBiblioteka : IEntitet
    {
        /// <summary>
        /// Datum uclanjenja clana u biblioteku kao DateTime.
        /// </summary>
        public DateTime DatumUclanjenja { get; set; }

        /// <summary>
        /// <see cref="Domen.Biblioteka"/> Biblioteka u koju je uclanjen clan.
        /// </summary>
        public Biblioteka Biblioteka { get; set; }

        /// <summary>
        /// <see cref="Domen.Clan"/> Clan koji je uclanjen u biblioteku
        /// </summary>
        public Clan Clan { get; set; }

        /// <summary>
        /// Prikazuje objekat klase ClanBiblioteka kao njegov clan i datum uclanjenja clana. Kada se ispisuje objekat klase ClanBiblioteka ispisuje se njegov clan i datum uclanjenja clana.
        /// </summary>
        /// <returns>Ime i prezime clana</returns>
        public override string ToString()
        {
            return $"{Clan}, {DatumUclanjenja}";
        }

        /// <summary>
        /// Uslov za upit u bazi podataka kao string. Ne prikazuje se na korisnickom interfejsu.
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public string Uslov { get; set; }

        [Browsable(false)]
        [JsonIgnore]
        public string ImeTabele => "ClanBiblioteka";
        [Browsable(false)]
        [JsonIgnore]
        public string UbaciVrednosti => $"'{DatumUclanjenja}', {Biblioteka.IDBiblioteka}, {Clan.IDClan}";
        [Browsable(false)]
        [JsonIgnore]
        public string IdName => "IDClan";
        [Browsable(false)]
        [JsonIgnore]
        public string JoinUslov => "join Biblioteka b on (b.IDBiblioteka = cb.IDBiblioteka) join Clan c on (c.IDClan = cb.IDClan)";
        [Browsable(false)]
        [JsonIgnore]
        public string Alias => "cb";
        [Browsable(false)]
        [JsonIgnore]
        public string Select => "*";
        [Browsable(false)]
        [JsonIgnore]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        [JsonIgnore]
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
