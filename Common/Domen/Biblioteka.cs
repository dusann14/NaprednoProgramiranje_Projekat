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
    public class Biblioteka : IEntitet
    {
        [Browsable(false)]
        public int IDBiblioteka { get; set; }

        public string Ime { get; set; }

        public string Adresa { get; set; }

        public override string ToString()
        {
            return $"{Ime}";
        }

        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Biblioteka";
        [Browsable(false)]
        public string UbaciVrednosti => "";
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Biblioteka other = (Biblioteka)obj;

            return IDBiblioteka == other.IDBiblioteka;
        }
    }
}
