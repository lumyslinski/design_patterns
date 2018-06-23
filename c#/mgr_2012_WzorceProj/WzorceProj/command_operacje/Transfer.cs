using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.command_operacje
{
    class Transfer : Command
    {
        private int kwota = 0;
        private string zKonta;
        private string DoKonta;
        private Income inc;
        private Payment pay;

        public Transfer(int amount, string zr, string dor)
        {
            kwota = amount;
            zKonta = zr;
            DoKonta = dor;
        }

        public override int execute(Bank b)
        {
            var rach1 = b.szukaj(zKonta);

            if (rach1 != null && rach1.saldo() > 0)
            {
                inc = new Income(kwota);
                inc.execute(rach1);
                pay = new Payment(kwota);
                var rach2 = b.szukaj(DoKonta);
                if (rach2 != null)
                {
                    pay.execute(rach2);
                    Console.WriteLine("Przelew kwoty " + kwota + " z konta o numerze " + rach1.numer() + " na konto o numerze: " +rach2.numer()+" wykonany poprawnie!");
                    return 0;
                } else {
                    return -1;
                }
            }

            return -1;
        }
    }
}
