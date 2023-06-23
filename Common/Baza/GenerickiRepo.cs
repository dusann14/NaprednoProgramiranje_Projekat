using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Baza
{
    public class GenerickiRepo : IGenerickiRepo
    {
        private BrokerBaze broker = new BrokerBaze();
        public void Commit()
        {
            broker.Commit();
        }

        public void OtvoriKonekciju()
        {
            broker.OtvoriKonekciju();
        }

        public void PokreniTransakciju()
        {
            broker.PokreniTransakciju();
        }

        public void Rollback()
        {
            broker.Rollback();
        }

        public void ZatvoriKonekciju()
        {
            broker.ZatvoriKonekciju();
        }

        public IEntitet PronadjiJednog(IEntitet entitet)
        {
            return broker.PronadjiJednog(entitet);
        }

        public List<IEntitet> VratiSve(IEntitet entitet)
        {
            return broker.VratiSve(entitet);
        }

        public List<IEntitet> VratiPoUslovu(IEntitet entitet)
        {
            return broker.PretraziTabele(entitet);
        }

        public int Dodaj(IEntitet entitet)
        {
            return broker.Dodaj(entitet);
        }

        public void Obrisi(IEntitet entitet)
        {
            broker.Obrisi(entitet);
        }

        public void Promeni(IEntitet entitet)
        {
            broker.Promeni(entitet);
        }
    }
}
