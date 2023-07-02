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
    /// Predstavlja entitet biblioteke. Implementira interfejs IEntitet i serijabilna je klasa.
    /// </summary>
    [Serializable]
    public class Biblioteka : IEntitet
    {
        /// <summary>
        /// Jedinstveni identifikator biblioteke kao celobrojna vrednost. Ne prikazuje se na korisnickom interfejsu. 
        /// </summary>
        [Browsable(false)]
        public int IDBiblioteka { get; set; }

        /// <summary>
        /// Ime biblioteke kao string.
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Adresa biblioteke kao string
        /// </summary>
        public string Adresa { get; set; }

        /// <summary>
        /// Prikazuje objekat klase Biblioteka kao njeno ime. Kada se ispisuje objekat klase Biblioteka ispisuje se njeno ime.
        /// </summary>
        /// <returns>Ime biblioteke</returns>
        public override string ToString()
        {
            return $"{Ime}";
        }

        /// <summary>
        /// Uslov za upit u bazi podataka kao string. Ne prikazuje se na korisnickom interfejsu.
        /// </summary>
        [Browsable(false)]
        public string Uslov { get; set; }


        [Browsable(false)]
        public string ImeTabele => "Biblioteka";
        [Browsable(false)]
        public string UbaciVrednosti => $"'{Ime}', '{Adresa}'";
        [Browsable(false)]
        public string IdName => "IDBiblioteka";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "b";
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
                entiteti.Add(new Biblioteka
                {
                    IDBiblioteka = (int)reader[0],
                    Ime = (string)reader[1],
                    Adresa = (string)reader[2]
                });
            }
            return entiteti;
        }

        /// <summary>
        /// Poredi dve biblioteke prema jedinstvenom identifikatoru.
        /// </summary>
        /// <param name="obj">Objekat klase Biblioteka sa kojom poredimo ovaj objekat</param>
        /// <returns>true - ako su im isti identifikatori, false - ako objekat sa kojim poredimo nije tipa Biblioteka ili ako je prosledjen null ili nemaju iste identifikatore</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Biblioteka other = (Biblioteka)obj;

            return IDBiblioteka == other.IDBiblioteka;
        }
    }
}
