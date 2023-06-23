using Common.Baza;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SistemskeOperacije
{
    public abstract class SistemskaOperacijaBaza
    {
        protected IGenerickiRepo repozitorijum;

        public SistemskaOperacijaBaza()
        {
            repozitorijum = new GenerickiRepo();
        }

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

        protected abstract void Izvrsi(IEntitet entitet);
    }
}
