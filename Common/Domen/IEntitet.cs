using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    /// <summary>
    /// Interfejs kojeg implementiraju svi domeski objekti i predstavlja genericki entitet sa zajednickim osobinama svih domenskih objekata.
    /// </summary>
    public interface IEntitet
    {
        /// <summary>
        /// Ime tabele domeskog objekta u bazi podataka.
        /// </summary>
        string ImeTabele { get; }

        /// <summary>
        /// Vrednosti koje se ubacuju u bazu podataka.
        /// </summary>
        string UbaciVrednosti { get; }

        /// <summary>
        /// Naziv jedinstvenog identifikatora domeskog objekta u bazi podataka.
        /// </summary>
        string IdName { get; }

        /// <summary>
        /// Join uslov.
        /// </summary>
        string JoinUslov { get; }

        /// <summary>
        /// Alias tabele domenskog objekta u bazi podataka
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Imena kolona koje citaju iz baze podataka.
        /// </summary>
        string Select { get; }

        /// <summary>
        /// Where uslov.
        /// </summary>
        string WhereUslov { get; }

        /// <summary>
        /// Vrednosti koje se menjaju u bazi podataka.
        /// </summary>
        string UpdateVrednosti { get; }

        /// <summary>
        /// Genericka metoda za citanje vise slogova iz baze podataka.
        /// </summary>
        /// <param name="reader">SqlReader koji je izvrsio upit na bazom nad osnovu SQL-a.</param>
        /// <returns>Vraceni entiteti iz baze podataka.</returns>
        List<IEntitet> VratiVise(SqlDataReader reader);

        /// <summary>
        /// Genericka metoda za citanje samo jednog sloga iz baze podataka.
        /// </summary>
        /// <param name="reader">SqlReader koji je izvrsio upit nad bazom podataka na osnovu SQL-a.</param>
        /// <returns>Entitet iz baze podataka</returns>
        IEntitet VratiJednog(SqlDataReader reader);
    }
}
