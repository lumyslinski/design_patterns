using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj.decorator_debet
{
    /// <summary>
    /// Klasa Decorator służąca do obsługiwania operacji kasowych na rachunku z debetem
    /// </summary>
    public abstract class Decorator : BankingProduct
    {
        // produkt bankowy, w tym wypadku rachunek
        protected BankingProduct component;

        public void SetComponent(BankingProduct component)
        {
            this.component = component;
        }
    }

    // rachunek z debetem
    public class RachunekDebetowy : Decorator
    {
        private double _debt = 0;
        private double _maxDebt = 0;
        private const double _maxDebtValue = 1000;

        public double MaxDebt
        {
            get { return _maxDebt; }
            set { if (value <= _maxDebtValue) { _maxDebt = value; }; }
        }

        public double Debt
        {
            get { return _debt; }
            set { _debt = value; }
        }

        public RachunekDebetowy(BankingProduct b, double MaxDebt)
        {
            this.SetComponent(b);
            this.MaxDebt = MaxDebt;
        }

        // Operacja wpłaty z debetem
        public override void Wplata(double kwota)
        {
            if (component != null)
            {
                Rachunek r = (Rachunek)component;

                if (this.Debt > 0)
                {
                    this.Debt -= kwota;
                }
                else
                {
                    r.Wplata(kwota);
                }
            }
        }

        // Operacja wypłaty z debetem
        public override void Wyplata(double kwota)
        {
            if (component != null)
            {
                Rachunek r = (Rachunek)component;
                WzorceProj.command_operacje.Payment p = new WzorceProj.command_operacje.Payment(kwota);
                double saldo_po_wyplacie = p.Execute(r);

                if (saldo_po_wyplacie < 0 && this.Debt <= this.MaxDebt)
                {
                    this.Debt = Math.Abs(saldo_po_wyplacie);
                    r.Saldo = 0;
                }
                else
                {
                    if (this.Debt <= this.MaxDebt)
                    {
                        r.SetHistoria("Przekroczono dopuszczalny limit debetu! (" + this.MaxDebt.ToString() + ")");
                    }
                    if (saldo_po_wyplacie >= 0)
                    {
                        r.Wyplata(kwota);
                    }
                }
            }
        }

        // Operacja przelewu z debetem 
        public override void Przelew(double kwota, Rachunek docelowy)
        {
            if (component != null)
            {
                Rachunek r = (Rachunek)component;
                WzorceProj.command_operacje.Payment p = new WzorceProj.command_operacje.Payment(kwota);
                double saldo_po_wyplacie = p.Execute(r);

                if (saldo_po_wyplacie < 0 && this.Debt <= this.MaxDebt)
                {
                    this.Debt = Math.Abs(saldo_po_wyplacie);
                    r.Saldo = 0;
                }
                else
                {
                    if (this.Debt <= this.MaxDebt)
                    {
                        r.SetHistoria("Przekroczono dopuszczalny limit debetu! (" + this.MaxDebt.ToString() + ")");
                    }
                    if (saldo_po_wyplacie >= 0)
                    {
                        r.Przelew(kwota, docelowy);
                    }
                }
            }
        }
      
    }
}
