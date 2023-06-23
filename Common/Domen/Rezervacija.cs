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
    [Serializable]
    public class Rezervacija : IEntitet
    {
        [Browsable(false)]
        public int IDRezervacija { get; set; }

        public DateTime DatumTrajanja { get; set; }

        public Clan Clan { get; set; }

        public Biblioteka Biblioteka { get; set; }

        public StatusRezervacije Status { get; set; }

        public List<Stavka> Stavke { get; set; }


        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Rezervacija";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{DatumTrajanja}', {Clan.IDClan}, {Biblioteka.IDBiblioteka}, {(int)Status}";
        [Browsable(false)]
        public string IdName => "IDRezervacija";
        [Browsable(false)]
        public string JoinUslov => "join clan c on (c.IDClan = r.IDClan) join biblioteka b on (b.IDBiblioteka = r.IDBiblioteka) join StatusRezervacije sr on (sr.IDStatus = r.IDStatus)";
        [Browsable(false)]
        public string Alias => "r";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
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
