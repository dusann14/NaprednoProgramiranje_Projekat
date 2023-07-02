using Common.Baza;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije
{
    /// <summary>
    /// Apstraktna klasa SistemskaOperacijaBaza koju sve sistemske operacije nasledjuju.
    /// </summary>
    public abstract class SistemskaOperacijaBaza
    {
        /// <summary>
        /// Referenca ka generickom repozitorijumu koji poziva metode iz brokera baze.
        /// </summary>
        protected IGenerickiRepo repozitorijum;

        /// <summary>
        /// Konstruktorom se inicijalizuje genericki repozitorijum.
        /// </summary>
        public SistemskaOperacijaBaza()
        {
            repozitorijum = new GenerickiRepo();
        }

        /// <summary>
        /// Genericka metoda koja je jedinstvena za sve sistemske operacije. Otvara konekciju na pocetku, pokrece transakciju, izvrsava se sistemska operacija gde se poziva neka metoda iz repozitorijuma u zavisnosti od sistemske operacije.
        /// </summary>
        /// <param name="entitet">Entitet koji je primljen sa klijenta.</param>
        public void Template(IEntitet entitet)
        {
            try
            {
                repozitorijum.OtvoriKonekciju();
                repozitorijum.PokreniTransakciju();
                Izvrsi(entitet);
                repozitorijum.Commit();
            }
            catch (Exception e)
            {
                repozitorijum.Rollback();
                throw e;
            }
            finally
            {
                repozitorijum.ZatvoriKonekciju();
            }
        }

        /// <summary>
        /// Apstraktna metoda koja je implementirana u svakoj sistemskoj operaciji drugacije u zavisnosti od sistemske operacije.
        /// </summary>
        /// <param name="entitet">Entitet koji je primljen sa klijenta.</param>
        protected abstract void Izvrsi(IEntitet entitet);
    }
}
