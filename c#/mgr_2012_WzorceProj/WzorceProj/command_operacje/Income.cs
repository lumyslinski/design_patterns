using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.command_operacje
{
    public class Income: Command
    {
        private double kwota = 0;

        public Income(double amount)
        {
            kwota = amount;
        }

        public override double Execute(Rachunek r)
        {
            var saldo = r.Saldo + this.kwota;
            //r.SetHistoria("Wpłata: " + this.kwota + ", saldo: " + saldo);
            return saldo;
        }
    }
}
