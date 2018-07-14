using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.state_odsetki
{
    // rachunek
    public class Originator
    {
        
        public Originator() {
            
        }

        // historia rachunku
        class Memento {
            private int saldo = 0;
            private int memSaldo = 0;
            private int resSaldo = 0;

            Memento()
            {
            }

            private void SetOdsetki()
            {
              if (saldo < 10000)
                  memSaldo = (int)0.01 * saldo;

                  resSaldo = memSaldo;
            }

            private void RestoreOdsetki()
            {
                memSaldo = resSaldo;
            }
        }
    }
}
