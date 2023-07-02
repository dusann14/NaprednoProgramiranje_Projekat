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
    /// Predstavlja entitet autora u biblioteci. Implementira interfejs IEntitet i serijabilna je klasa.
    /// </summary>
    [Serializable]
    public class Autor : IEntitet
    {
        /// <summary>
        /// Jedinstveni identifikator autora kao celobrojna vrednost. Ne prikazuje se na korisnickom interfejsu. 
        /// </summary>
        [Browsable(false)]
        public int IDAutor { get; set; }

        /// <summary>
        /// Ime i prezime autora kao string.
        /// </summary>
        public string ImePrezime { get; set; }

        /// <summary>
        /// <see cref="Domen.Bibliotekar"/> Pripadajuća biblioteka autora.
        /// </summary>
        public Biblioteka Biblioteka { get; set; }

        /// <summary>
        /// Prikazuje objekat klase Autor kao njegovo ime i prezime. Kada se ispisuje objekat klase Autor ispisuju se njegovo ime i prezime.
        /// </summary>
        /// <returns>Ime i prezime autora.</returns>
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
        public string ImeTabele => "Autor";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{ImePrezime}', {Biblioteka.IDBiblioteka}";
        [Browsable(false)]
        public string IdName => "IDAutor";
        [Browsable(false)]
        public string JoinUslov => "join Biblioteka b on (b.IDBiblioteka = a.IDBiblioteka)";
        [Browsable(false)]
        public string Alias => "a";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();

            while (reader.Read())
            {
                entiteti.Add(new Autor
                {
                    IDAutor = (int)reader[0],
                    ImePrezime = (string)reader[1],
                    Biblioteka = new Biblioteka
                    {
                        IDBiblioteka = (int)reader[3],
                        Ime = (string)reader[4],
                        Adresa = (string)reader[5],
                    }
                });
            }
            return entiteti;
        }
    }
}
