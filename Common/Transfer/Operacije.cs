using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    /// <summary>
    /// Operacije koje klijent salje i zahteva odgovor na osnovu operacije. Serijablina je klasa.
    /// </summary>
    [Serializable]
    public enum Operacije
    {
        VratiKnjigeIzBiblioteke,
        VratiKnjigePoAutoru,
        DodajKnjigu,
        ObrisiKnjigu,
        PromeniKnjigu,
        PromeniPodatkeBibliotekara,
        PrikaziClanovePoImenu,
        PrikaziSveClanoveBiblioteke,
        PrikaziSveRezervacije,
        PromeniPodatkeClana,
        KreirajRezervaciju,
        VratiAutore,
        VratiBibliotekeClana,
        PrikaziSveBiblioteke,
        OtkaziClanstvo,
        UclaniSe,
        VratiStavkeRezervacije,
        VratiKnjigePoNaslovu,
        VratiNeobradjeneRezervacije,
        ObradiRezervaciju,
        VratiObradjeneRezervacije
    }
}
