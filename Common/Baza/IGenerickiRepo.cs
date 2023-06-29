using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Baza
{
    /// <summary>
    /// Interfejs IGenerickiRepo koji predstavlja genericki repozitorijum sa kim rade svi domeski objekti. 
    /// </summary>
    public interface IGenerickiRepo
    {
        /// <summary>
        /// Genericka metoda koja zove broker baze da izvrsi promenu prosledjenog entiteta u bazi podataka.
        /// </summary>
        /// <param name="entitet">Entitet nad kojim treba da se izvrsi promena u bazi.</param>
        void Promeni(IEntitet entitet);

        /// <summary>
        /// Genericka metoda koja zove broker baze da izvrsi brisanje prosledjenog entiteta u bazi podataka.
        /// </summary>
        /// <param name="entitet">Entitet koji treba izbrisati u bazi.</param>
        void Obrisi(IEntitet entitet);

        /// <summary>
        /// Genericka metoda koja zove broker baze da izvrsi dodavanje prosledjenog entiteta u bazu podataka.
        /// </summary>
        /// <param name="entitet">Entitet koji treba dodati u bazu.</param>
        /// <returns>Identifikator novog unetog entiteta u bazi.</returns>
        int Dodaj(IEntitet entitet);

        /// <summary>
        /// Genericka metoda koja zove broker baze da vrati sve slogove odredjene tabele iz baze podataka.
        /// </summary>
        /// <param name="entitet">Entitet na osnovu kog baza zna iz koje tabele treba da vrati podatke.</param>
        /// <returns>Lista vracenih entiteta</returns>
        List<IEntitet> VratiSve(IEntitet entitet);

        /// <summary>
        /// Genericka metoda koja zove broker baze da vrati sve slogove odredjene tabele iz baze podataka po nekom uslovu.
        /// </summary>
        /// <param name="entitet">Entitet na osnovu kog baza zna iz koje tabele treba da vrati podatke i postavi uslov.</param>
        /// <returns>Lista vracenih entiteta</returns>
        List<IEntitet> VratiPoUslovu(IEntitet entitet);

        /// <summary>
        /// Genericka metoda koja zove broker baze da vrati jedan slog odredjene tabele iz baze podataka.
        /// </summary>
        /// <param name="entitet">Entitet na osnovu kog baza zna iz koje tabele treba da vrati podatke i postavi uslov.</param>
        /// <returns>Lista vracenih entiteta</returns>
        IEntitet PronadjiJednog(IEntitet entitet);

        /// <summary>
        /// Metoda koja poziva broker baze da otvori konekciju.
        /// </summary>
        void OtvoriKonekciju();

        /// <summary>
        /// Metoda koja poziva broker baze da zatvori konekciju.
        /// </summary>
        void ZatvoriKonekciju();

        /// <summary>
        /// Metoda koja poziva broker baze da pokrene transakciju.
        /// </summary>
        void PokreniTransakciju();

        /// <summary>
        /// Metoda koja poziva broker baze da izvrsi commit.
        /// </summary>
        void Commit();

        /// <summary>
        /// Metoda koja poziva broker baze da izvrsi rollback.
        /// </summary>
        void Rollback();
    }
}
