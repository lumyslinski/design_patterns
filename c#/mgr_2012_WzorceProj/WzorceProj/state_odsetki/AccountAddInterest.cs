using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.state_odsetki
{
    public class AccountAddInterest: AccountState
    {
        public double RunInterest(Rachunek r)
        {
            double odsetki = 0;

            if (r.Saldo < 10000)
                odsetki = 0.01 * r.Saldo;
            else if (r.Saldo < 50000)
                odsetki = 100 + 0.02 * (r.Saldo - 10000);
            else
                odsetki = 100 + 800 + 0.03 * (r.Saldo - 50000);

            r.SetHistoria("Naliczono odsetki w kwocie " + odsetki);
            return odsetki;
        }
    }


    public class AccountAddInterestExtra : AccountState
    {
        public double RunInterest(Rachunek r)
        {
            double odsetki = 0;

            if (r.Saldo < 1000)
                odsetki = 0.01 * r.Saldo;
            else if (r.Saldo < 5000)
                odsetki = 10 + 0.02 * (r.Saldo - 1000);
            else
                odsetki = 10 + 80 + 0.03 * (r.Saldo - 5000);

            r.SetHistoria("Naliczono odsetki w kwocie " + odsetki);
            return odsetki;
        }
    }
}
