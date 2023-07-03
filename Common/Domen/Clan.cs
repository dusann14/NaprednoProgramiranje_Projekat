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
    /// Predstavlja entitet clana. Implementira interfejs IEntitet i serijabilna je klasa.
    /// </summary>
    [Serializable]
    public class Clan : IEntitet
    {
        /// <summary>
        /// Jedinstveni identifikator clana kao celobrojna vrednost. Ne prikazuje se na korisnickom interfejsu. 
        /// </summary>
        [Browsable(false)]
        public int IDClan { get; set; }

        /// <summary>
        /// Korisnicko ime clana kao string.
        /// </summary>
        public string KorisnickoIme { get; set; }

        /// <summary>
        /// Lozinka clana kao string.
        /// </summary>
        public string Lozinka { get; set; }

        /// <summary>
        /// Ime i prezime clana kao string.
        /// </summary>
        /// <exception cref="ArgumentNullException">Ako se unese null ili prazan string</exception>
        /// <exception cref="FormatException">Ako se ne unese i ime i prezime</exception>
        public string ImePrezime
        {
            get { return ImePrezime; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Null ili prazan string");

                string[] niz = value.Split(' ');

                if (!(niz.Length < 2))
                    throw new FormatException("Niste uneli ime i prezime");

                ImePrezime = value;
            }
        }

        /// <summary>
        /// Pokazuje da li je clan trenutno prijavljen ili nije kao bool.
        /// </summary>
        public bool Prijavljen { get; set; }

        /// <summary>
        /// Datum rodjenja clana kao DateTime.
        /// </summary>
        /// <exception cref="FormatException">Ako se unese datum u buducnosti</exception>
        public DateTime DatumRodjenja
        {
            get { return DatumRodjenja; }
            set
            {
                if (value > DateTime.Now)
                    throw new FormatException("Datum mora biti u proslosti");

                DatumRodjenja = value;
            }
        }

        /// <summary>
        /// Prikazuje objekat klase Clan kao njegovo ime i prezime. Kada se ispisuje objekat klase Clan ispisuje se njegovo ime i prezime.
        /// </summary>
        /// <returns>Ime i prezime clana</returns>
        public override string ToString()
        {
            return $"{ImePrezime}";
        }

        /// <summary>
        /// Uslov za upit u bazi podataka kao string. Ne prikazuje se na korisnickom interfejsu.
        /// </summary>
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
