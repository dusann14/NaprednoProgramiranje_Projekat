using Common.Domen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Baza
{
    /// <summary>
    /// Klasa BrokerBaze direktno komunicicra sa bazom podataka preko svojih metoda.
    /// </summary>
    public class BrokerBaze
    {
        /// <summary>
        /// Referenca na SqlConnection preko koje vrsi konekcija na bazu.
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Referenca na SqlTransaction pomocu koje se otvara transakcija.
        /// </summary>
        private SqlTransaction transakcija;

        /// <summary>
        /// Konstruktor u kom se aplikacija povezuje sa bazom.
        /// </summary>
        public BrokerBaze()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["psdb"].ConnectionString);
        }

        /// <summary>
        /// Metoda kojom se otvara konekcija.
        /// </summary>
        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        /// <summary>
        /// Metoda kojom se zatvara konekcija.
        /// </summary>
        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        /// <summary>
        /// Metoda kojom se pokrece transakcija.
        /// </summary>
        public void PokreniTransakciju()
        {
            transakcija = connection.BeginTransaction();
        }

        /// <summary>
        /// Metoda kojom se vrsi commit(potvrda) promena u bazi.
        /// </summary>
        public void Commit()
        {
            transakcija?.Commit();
        }

        /// <summary>
        /// Metoda kojom se vrsi rollback(odbacivanje) promena u bazi.
        /// </summary>
        public void Rollback()
        {
            transakcija?.Rollback();
        }

        /// <summary>
        /// Genericka metoda koja nalazi jedan slog u bazi na osnovu prosledjenog entiteta a preko SQL upita nad bazom. Ukoliko takav entitet ne postoji vraca null vrednost. 
        /// </summary>
        /// <param name="entitet">Entitet koji se prosledjuje tipa IEntitet.</param>
        /// <returns>Pronadjeni entitet u bazi.</returns>
        public IEntitet PronadjiJednog(IEntitet entitet)
        {
            IEntitet pronadjeni = null;
            SqlCommand command = new SqlCommand("", connection, transakcija);
            command.CommandText = $"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};";
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                pronadjeni = entitet.VratiJednog(reader);
            }
            reader.Close();
            return pronadjeni;
        }

        /// <summary>
        /// Genericka metoda koja nalazi vise slogova u bazi na osnovu prosledjenog entiteta a preko SQL upita nad bazom. Ukoliko takavi entiteti ne postoje vraca null vrednost. 
        /// </summary>
        /// <param name="entitet">Entitet koji se prosledjuje tipa IEntitet.</param>
        /// <returns>Pronadjeni entiteti u bazi.</returns>
        public List<IEntitet> PretraziTabele(IEntitet entitet)
        {
            List<IEntitet> entiteti = null;
            SqlCommand command = new SqlCommand("", connection, transakcija);
            command.CommandText = $"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};";
            SqlDataReader reader = command.ExecuteReader();
            entiteti = entitet.VratiVise(reader);
            reader.Close();
            return entiteti;
        }

        /// <summary>
        /// Genericka metoda koja vraca sve slogove u bazi iz jedne tabele na osnovu prosledjenog entiteta a preko SQL upita nad bazom. 
        /// </summary>
        /// <param name="entitet">Entitet koji se prosledjuje tipa IEntitet.</param>
        /// <returns>Entiteti iz baze.</returns>
        public List<IEntitet> VratiSve(IEntitet entitet)
        {
            List<IEntitet> entiteti = null;
            SqlCommand command = new SqlCommand("", connection, transakcija);
            command.CommandText = $"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov};";
            SqlDataReader reader = command.ExecuteReader();
            entiteti = entitet.VratiVise(reader);
            reader.Close();
            return entiteti;
        }

        /// <summary>
        /// Genericka metoda kojom se dodaje novi slog u bazu podataka na osnovu prosledjenog entiteta a preko SQL upita nad bazom.
        /// </summary>
        /// <param name="entitet">Entitet koji se prosledjuje tipa IEntitet</param>
        /// <returns>Identifikator novog unetog entiteta u bazi.</returns>
        /// <exception cref="Exception">Ukoliko postoji greska u bazi i pamcenje entiteta u bazi nije uspelo.</exception>
        public int Dodaj(IEntitet entitet)
        {
            SqlCommand command = new SqlCommand("", connection, transakcija);
            command.CommandText = $"insert into {entitet.ImeTabele} output inserted.{entitet.IdName} values ({entitet.UbaciVrednosti})";
            int newID = (int)command.ExecuteScalar();
            if (newID == null)
            {
                throw new Exception("Greska u bazi!");
            }
            return newID;
        }

        /// <summary>
        /// Genericka metoda kojom se brise slog iz baze podatka na osnovu prosledjenog entiteta a preko SQL upita nad bazom.
        /// </summary>
        /// <param name="entitet">Entitet koji se prosledjuje tipa IEntitet.</param>
        /// <exception cref="Exception">Ukoliko postoji greska u bazi i brisanje entiteta u bazi nije uspelo.</exception>
        public void Obrisi(IEntitet entitet)
        {
            SqlCommand command = new SqlCommand("", connection, transakcija);
            command.CommandText = $"delete from {entitet.ImeTabele} where {entitet.WhereUslov}";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Greska u bazi!");
            }
        }

        /// <summary>
        /// Genericka metoda kojom se menja slog iz baze podatka na osnovu prosledjenog entiteta a preko SQL upita nad bazom.
        /// </summary>
        /// <param name="entitet">Entitet koji se prosledjuje tipa IEntitet.</param>
        /// <exception cref="Exception">Ukoliko postoji greska u bazi i promena entiteta u bazi nije uspelo.</exception>
        public void Promeni(IEntitet entitet)
        {
            SqlCommand command = new SqlCommand("", connection, transakcija);
            command.CommandText = $"update {entitet.ImeTabele} set {entitet.UpdateVrednosti} where {entitet.WhereUslov}";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Greska u bazi!");
            }
        }
    }
}
