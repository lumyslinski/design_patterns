using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using WzorceProj.command_operacje;

namespace WzorceProj
{
    public class Bank
    {
        private Dictionary<object, object> rachunki = new Dictionary<object, object>();

        /**
         * Zakładanie rachunku. Rachunek zostanie stworzony i zapamiętany przez bank.
         * @param numer
         * @param imie
         * @param nazwisko
         * @return
         */
        public Rachunek ZalozRachunek(String numer, String imie, String nazwisko)
        {
            Rachunek rach = new Rachunek(numer, imie, nazwisko);
            
            rachunki.Add(numer, rach);
            return rach;
        }

        /**
         * Wyszukiwanie rachunku
         * @param numer
         * @return obiekt rachunku, jeżeli zostanie znaleziony, i null, jeżeli go nie ma
         */
        public Rachunek Szukaj(String numer)
        {
            if (rachunki.Keys.Where(k => k.Equals(numer)).Count() == 0)
            {
                return (Rachunek)rachunki.Keys.Where(k => k.Equals(numer));
            }
            else
            {
                return null;
            }
        }
    }
}

