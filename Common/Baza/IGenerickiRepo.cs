using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Baza
{
    public interface IGenerickiRepo
    {
        void Promeni(IEntitet entitet);
        void Obrisi(IEntitet entitet);
        int Dodaj(IEntitet entitet);
        List<IEntitet> VratiSve(IEntitet entitet);

        List<IEntitet> VratiPoUslovu(IEntitet entitet);
        IEntitet PronadjiJednog(IEntitet entitet);
        void OtvoriKonekciju();

        void ZatvoriKonekciju();

        void PokreniTransakciju();

        void Commit();

        void Rollback();
    }
}
