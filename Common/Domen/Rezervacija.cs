using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Predstavlja entitet rezervacije. Implementira interfejs IEntitet i serijabilna je klasa.
    /// </summary>
    [Serializable]
    public class Rezervacija : IEntitet
    {
        /// <summary>
        /// Jedinstveni identifikator rezervacije kao celobrojna vrednost. Ne prikazuje se na korisnickom interfejsu. 
        /// </summary>
        [Browsable(false)]
        public int IDRezervacija { get; set; }

        /// <summary>
        /// Datum do kada vazi rezervacija kao DateTime.
        /// </summary>
        public DateTime DatumTrajanja { get; set; }

        /// <summary>
        /// <see cref="Domen.Clan"/> Clan koji je napravi rezervaciju.
        /// </summary>
        public Clan Clan { get; set; }

        /// <summary>
        /// <see cref="Domen.Biblioteka"/> Biblioteka u kojoj je registrovana rezervacija.
        /// </summary>
        public Biblioteka Biblioteka { get; set; }

        /// <summary>
        /// <see cref="StatusRezervacije"/> Status rezervacije.
        /// </summary>
        public StatusRezervacije Status { get; set; }

        /// <summary>
        /// <see cref="Stavka"/> Lista stavki u rezervaciji.
        /// </summary>
        public List<Stavka> Stavke { get; set; }

        /// <summary>
        /// Uslov za upit u bazi podataka kao string. Ne prikazuje se na korisnickom interfejsu.
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public string Uslov { get; set; }


        [Browsable(false)]
        [JsonIgnore]
        public string ImeTabele => "Rezervacija";
        [Browsable(false)]
        [JsonIgnore]
        public string UbaciVrednosti => $"'{DatumTrajanja}', {Clan.IDClan}, {Biblioteka.IDBiblioteka}, {(int)Status}";
        [Browsable(false)]
        [JsonIgnore]
        public string IdName => "IDRezervacija";
        [Browsable(false)]
        [JsonIgnore]
        public string JoinUslov => "join clan c on (c.IDClan = r.IDClan) join biblioteka b on (b.IDBiblioteka = r.IDBiblioteka) join StatusRezervacije sr on (sr.IDStatus = r.IDStatus)";
        [Browsable(false)]
        [JsonIgnore]
        public string Alias => "r";
        [Browsable(false)]
        [JsonIgnore]
        public string Select => "*";
        [Browsable(false)]
        [JsonIgnore]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        [JsonIgnore]
        public string UpdateVrednosti => $"DatumTrajanja = '{DatumTrajanja}', IDClan = {Clan.IDClan}, IDBiblioteka = {Biblioteka.IDBiblioteka}, IDStatus = {(int)Status}";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                entiteti.Add(new Rezervacija
                {
                    IDRezervacija = (int)reader[0],
                    DatumTrajanja = (DateTime)reader[1],
                    Clan = new Clan
                    {
                        IDClan = (int)reader[5],
                        ImePrezime = (string)reader[6],
                        KorisnickoIme = (string)reader[7],
                        Lozinka = (string)reader[8],
                        Prijavljen = (bool)reader[9],
                        DatumRodjenja = (DateTime)reader[10],
                    },
                    Biblioteka = new Biblioteka
                    {
                        IDBiblioteka = (int)reader[11],
                        Ime = (string)reader[12],
                        Adresa = (string)reader[13]
                    },
                    Status = (StatusRezervacije)(int)reader[14]
                });
            }

            return entiteti;
        }
    }
}
