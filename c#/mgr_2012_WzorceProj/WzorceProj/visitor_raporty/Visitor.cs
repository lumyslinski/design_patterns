using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.visitor_raporty
{
    interface Visitor
    {
        BankingProduct Getsaldo(Rachunek r);
    }

    public class HighBiling : Visitor {

        BankingProduct Visitor.Getsaldo(Rachunek r)
        {
            if (r.Saldo > 1000)
                return r;
            return null;
        }
    }
}
