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
    public class Knjiga : IEntitet
    {
        [Browsable(false)]
        public int IDKnjiga { get; set; }

        public string Naslov { get; set; }

        public int BrojPrimeraka { get; set; }

        public Autor Autor { get; set; }

        public Biblioteka Biblioteka { get; set; }

        public override string ToString()
        {
            return $"{Naslov}";
        }

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
