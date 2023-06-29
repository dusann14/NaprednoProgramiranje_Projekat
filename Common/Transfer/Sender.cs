using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Transfer
{
    /// <summary>
    /// Klasa Sender koristi se slanje objekata na tok podataka, omogucava komunikaciju izmedju klijenta i servera.
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// Tok podataka na koji se salje objekat.
        /// </summary>
        private NetworkStream tok;

        /// <summary>
        /// BinaryFormatter pomocu koga se objekat salje na tok podataka.
        /// </summary>
        private BinaryFormatter formatter;

        /// <summary>
        /// Konstruktor pomocu kog se inicijalizuju polja klase, soket se postavlja na tok podataka.
        /// </summary>
        /// <param name="soket">Soket koji se postavlja na tok podataka.</param>
        public Sender(Socket soket)
        {
            tok = new NetworkStream(soket);
            formatter = new BinaryFormatter();
        }

        /// <summary>
        /// Metoda kojom se objekat salje na tok podataka.
        /// </summary>
        /// <param name="poruka">Objekat koji se salje na tok podataka i to dalje na drugu stranu.</param>
        public void Posalji(object poruka)
        {
            formatter.Serialize(tok, poruka);
        }
    }
}
