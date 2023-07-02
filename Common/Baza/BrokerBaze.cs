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
    public class BrokerBaze
    {
        private SqlConnection connection;
        private SqlTransaction transakcija;

        public BrokerBaze()
        {
            //connection = new SqlConnection(ConfigurationManager.ConnectionStrings["psdb"].ConnectionString);
            connection = new SqlConnection("Data Source=DESKTOP-BP1HPT2;Initial Catalog=Projekat_Biblioteka;Integrated Security=true");
        }

        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void PokreniTransakciju()
        {
            transakcija = connection.BeginTransaction();
        }

        public void Commit()
        {
            transakcija?.Commit();
        }

        public void Rollback()
        {
            transakcija?.Rollback();
        }

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

        public void Obrisi(IEntitet entitet)
        {
            SqlCommand command = new SqlCommand("", connection, transakcija);
            command.CommandText = $"delete from {entitet.ImeTabele} where {entitet.WhereUslov}";
            command.ExecuteNonQuery();
        }

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
