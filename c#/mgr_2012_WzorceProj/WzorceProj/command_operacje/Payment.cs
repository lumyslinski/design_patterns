using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.command_operacje
{

    public class Payment : Command
    {
        private double kwota = 0;

        public Payment(double amount)
        {
            kwota = amount;
        }

        public override double Execute(Rachunek r)
        {
            double saldo = 0;
            saldo = r.Saldo - kwota;
                //r.SetHistoria("Wypłata: " + this.kwota + ", saldo: " + saldo);
            return saldo;
        }
    }
}
