using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WzorceProj.decorator_debet;
using WzorceProj;

namespace TestProjectWzorceProj
{
    [TestClass]
    public class UnitTestDecoratorDebt
    {
        RachunekDebetowy d;
        RachunekDebetowy d_dest;
        Rachunek r;
        Rachunek r_dest;

        [TestMethod]
        public void Test_RachunekDebetowy_WE_MaxDebet300_wp100_wyp150_WY_0()
        {
            double MaxDebet = 300;
            r = new Rachunek("123","imie","nazwisko");
            d = new RachunekDebetowy(r, MaxDebet);

            d.Wplata(100);
            d.Wyplata(150);

            d.Wplata(50);

            Assert.IsTrue(0 == d.Debt, "Błędne naliczanie debetu != 0");
        }

        [TestMethod]
        public void Test_RachunekDebetowy_WE_MaxDebet300_wp100_wyp100_WY_0()
        {
            double MaxDebet = 300;
            r = new Rachunek("123", "imie", "nazwisko");
            d = new RachunekDebetowy(r, MaxDebet);

            d.Wplata(100);
            d.Wyplata(100);

            Assert.IsTrue(0 == d.Debt, "Błędne naliczanie debetu != 0", null);
        }

        [TestMethod]
        public void Test_RachunekDebetowy_WE_MaxDebet300_wp100_przelew100_WY_0()
        {
            double MaxDebet = 300;
            r = new Rachunek("123", "imie", "nazwisko");
            d = new RachunekDebetowy(r, MaxDebet);

            r_dest = new Rachunek("456", "imie", "nazwisko");

            d.Wplata(100);
            d.Przelew(100, r_dest);

            d_dest = new RachunekDebetowy(r_dest, MaxDebet);
            d_dest.Przelew(100, r);
            r.Wyplata(100);

            Assert.IsTrue(0 == d.Debt, "Błąd w naliczeniu debetu z rachunku źródłowego!", null);
            Assert.IsTrue(0 == d_dest.Debt, "Błąd w naliczeniu debetu z rachunku docelowego!", null);
            Assert.IsTrue(r.Saldo == 0, "Błąd w naliczaniu salda z rachunku źródłowego!", null);
            Assert.IsTrue(r_dest.Saldo == 0, "Błąd w naliczaniu salda z rachunku docelowego!", null);
        }
    }
}
