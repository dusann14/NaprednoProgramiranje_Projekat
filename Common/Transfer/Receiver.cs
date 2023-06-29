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
    /// Klasa Receiver koristi se skidanje objekata sa toka podataka, omogucava komunikaciju izmedju klijenta i servera.
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Tok podataka na kom se nalazi objekat koji treba procitati.
        /// </summary>
        private NetworkStream tok;

        /// <summary>
        /// BinaryFormatter pomocu koga se objekat skida sa toka podataka.
        /// </summary>
        private BinaryFormatter formatter;

        /// <summary>
        /// Konstruktor pomocu kog se inicijalizuju polja klase, soket se postavlja na tok podataka.
        /// </summary>
        /// <param name="soket">Soket koji se postavlja na tok podataka.</param>
        public Receiver(Socket soket)
        {
            tok = new NetworkStream(soket);
            formatter = new BinaryFormatter();
        }

        /// <summary>
        /// Metoda kojom se objekat skida sa toka podataka.
        /// </summary>
        public object Primi()
        {
            return formatter.Deserialize(tok);
        }
    }
}
