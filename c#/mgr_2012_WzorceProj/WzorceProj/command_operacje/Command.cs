using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.command_operacje
{
    abstract public class Command
    {
        public abstract double Execute(Rachunek r); // wykonuje operacje w zależności od typu
  
    }


}
