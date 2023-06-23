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
    public class Clan : IEntitet
    {
        [Browsable(false)]
        public int IDClan { get; set; }


        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }


        public string ImePrezime { get; set; }

        public bool Prijavljen { get; set; }


        public DateTime DatumRodjenja { get; set; }

        public override string ToString()
        {
            return $"{ImePrezime}";
        }

        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Clan";
        [Browsable(false)]
        public string UbaciVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "c";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => $"KorisnickoIme = '{KorisnickoIme}', Lozinka = '{Lozinka}', ImePrezime = '{ImePrezime}', Prijavljen = '{Prijavljen}', DatumRodjenja = '{DatumRodjenja}'";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            return new Clan
            {
                IDClan = (int)reader[0],
                ImePrezime = (string)reader[1],
                KorisnickoIme = (string)reader[2],
                Lozinka = (string)reader[3],
                Prijavljen = (bool)reader[4],
                DatumRodjenja = (DateTime)reader[5],
            };
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read())
            {
                entiteti.Add(new Clan
                {
                    IDClan = (int)reader[0],
                    ImePrezime = (string)reader[1],
                    KorisnickoIme = (string)reader[2],
                    Lozinka = (string)reader[3],
                    DatumRodjenja = (DateTime)reader[4],
                    Prijavljen = (bool)reader[5]
                });

            }
            return entiteti;
        }
    }
}
