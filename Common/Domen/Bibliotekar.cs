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
    /// Predstavlja entitet bibliotekara. Implementira interfejs IEntitet i serijabilna je klasa.
    /// </summary>
    [Serializable]
    public class Bibliotekar : IEntitet
    {
        /// <summary>
        /// Jedinstveni identifikator bibliotekara kao celobrojna vrednost. Ne prikazuje se na korisnickom interfejsu. 
        /// </summary>
        [Browsable(false)]
        public int IDBibliotekar { get; set; }

        /// <summary>
        /// Ime i prezime bibliotekara kao string.
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
        /// Korisnicko ime bibliotekara kao string.
        /// </summary>
        public string KorisnickoIme { get; set; }

        /// <summary>
        /// Lozinka bibliotekara kao string.
        /// </summary>
        public string Lozinka { get; set; }

        /// <summary>
        /// Pokazuje da li je bibliotekar trenutno prijavljen ili nije kao bool.
        /// </summary>
        public bool Prijavljen { get; set; }

        /// <summary>
        /// Datum rodjenja bibliotekara kao DateTime.
        /// </summary>
        /// <exception cref="FormatException">Ako se unese datum u buducnosti</exception>
        public DateTime DatumRodjenja
        {
            get { return DatumRodjenja; }
            set
            {
                if(value > DateTime.Now) 
                    throw new FormatException("Datum mora biti u proslosti");

                DatumRodjenja = value;
            }
        }

        /// <summary>
        /// <see cref="Domen.Biblioteka"/> Oznacava pripadajucu biblioteku bibliotekara.
        /// </summary>
        public Biblioteka Biblioteka { get; set; }

        /// <summary>
        /// Uslov za upit u bazi podataka kao string. Ne prikazuje se na korisnickom interfejsu.
        /// </summary>
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
