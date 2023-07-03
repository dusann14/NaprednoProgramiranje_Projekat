using Common.Domen;
using Common.SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Test.DodateSO
{
    public class ObrisiStavkuKnjigeSO : SistemskaOperacijaBaza
    {
        protected override void Izvrsi(IEntitet entitet)
        {
            Stavka stavka = (Stavka)entitet;
            stavka.Uslov = $"IDKnjiga = {stavka.Knjiga.IDKnjiga}";
            repozitorijum.Obrisi(stavka);
        }
    }
}
