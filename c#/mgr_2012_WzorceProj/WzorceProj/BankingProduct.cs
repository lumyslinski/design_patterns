using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj
{
    public abstract class BankingProduct
    {
        public abstract void Wplata(double kwota);
        public abstract void Wyplata(double kwota);
        public abstract void Przelew(double kwota, Rachunek docelowy);
    }
}
