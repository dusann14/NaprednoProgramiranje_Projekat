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
    /// Predstavlja entitet knjige. Implementira interfejs IEntitet i serijabilna je klasa.
    /// </summary>
    [Serializable]
    public class Knjiga : IEntitet
    {
        /// <summary>
        /// Jedinstveni identifikator knjige kao celobrojna vrednost. Ne prikazuje se na korisnickom interfejsu. 
        /// </summary>
        [Browsable(false)]
        public int IDKnjiga { get; set; }

        /// <summary>
        /// Naslov knjige kao string.
        /// </summary>
        public string Naslov { get; set; }

        /// <summary>
        /// Broj primeraka knjige u biblioteci kao celobrojna vrednost.
        /// </summary>
        public int BrojPrimeraka { get; set; }

        /// <summary>
        /// <see cref="Domen.Autor"/> Autor knjige.
        /// </summary>
        public Autor Autor { get; set; }

        /// <summary>
        /// <see cref="Domen.Biblioteka"/> Biblioteka u kojoj se nalazi knjiga.
        /// </summary>
        public Biblioteka Biblioteka { get; set; }

        /// <summary>
        /// Prikazuje objekat klase Knjiga kao njen naslov. Kada se ispisuje objekat klase Knjiga ispisuje se njen naslov.
        /// </summary>
        /// <returns>Ime i prezime clana</returns>
        public override string ToString()
        {
            return $"{Naslov}";
        }

        /// <summary>
        /// Uslov za upit u bazi podataka kao string. Ne prikazuje se na korisnickom interfejsu.
        /// </summary>
        [Browsable(false)]
        public string Uslov { get; set; }


        [Browsable(false)]
        public string ImeTabele => "Knjiga";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{Naslov}', {BrojPrimeraka}, {Autor.IDAutor}, {Biblioteka.IDBiblioteka}";
        [Browsable(false)]
        public string IdName => "IDKnjiga";
        [Browsable(false)]
        public string JoinUslov => "join Autor a on (a.IDAutor = k.IDAutor) join Biblioteka b on (b.IDBiblioteka = k.IDBiblioteka)";
        [Browsable(false)]
        public string Alias => "k";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => $"Naslov = '{Naslov}', BrojPrimeraka = {BrojPrimeraka}, IDAutor = {Autor.IDAutor}, IDBiblioteka = {Biblioteka.IDBiblioteka}";

        public IEntitet VratiJednog(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntitet> VratiVise(SqlDataReader reader)
        {
            List<IEntitet> entiteti = new List<IEntitet>();
            while (reader.Read())
            {
                entiteti.Add(new Knjiga
                {
                    IDKnjiga = (int)reader[0],
                    Naslov = (string)reader[1],
                    BrojPrimeraka = (int)reader[2],
                    Autor = new Autor
                    {
                        IDAutor = (int)reader[5],
                        ImePrezime = (string)reader[6],
                        Biblioteka = new Biblioteka
                        {
                            IDBiblioteka = (int)reader[8],
                            Ime = (string)reader[9],
                            Adresa = (string)reader[10]
                        }
                    },
                    Biblioteka = new Biblioteka
                    {
                        IDBiblioteka = (int)reader[8],
                        Ime = (string)reader[9],
                        Adresa = (string)reader[10]
                    }
                });
            }
            return entiteti;
        }
    }
}
