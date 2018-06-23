using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.state_odsetki
{
    public interface AccountState
    {
        double RunInterest(Rachunek r);
    }
}
