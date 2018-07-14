using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WzorceProj.state_odsetki;
using WzorceProj;

namespace TestProjectWzorceProj
{
    [TestClass]
    public class UnitTestAccountAddInterestExtra
    {
        private AccountAddInterestExtra accountAddInterestExtra;
        private Rachunek r;


        [TestMethod]
        public void Test_AccountAddInterestExtra_WE_wp1000_WY_ods10()
        {
            this.accountAddInterestExtra = new WzorceProj.state_odsetki.AccountAddInterestExtra();
            r = new Rachunek("123", "imie", "nazwisko");
            r.Wplata(1000);

            Assert.IsTrue(10 == this.accountAddInterestExtra.RunInterest(r), "Błędne naliczanie odsetek dla progu < 1000");

        }

        [TestMethod]
        public void Test_AccountAddInterestExtra_WE_wp4000_WY_ods70()
        {
            this.accountAddInterestExtra = new WzorceProj.state_odsetki.AccountAddInterestExtra();
            r = new Rachunek("123", "imie", "nazwisko");
            r.Wplata(4000);

            Assert.IsTrue(70 == this.accountAddInterestExtra.RunInterest(r), "Błędne naliczanie odsetek dla progu < 5000");

        }

        [TestMethod]
        public void Test_AccountAddInterestExtra_WE_wp8000_WY_ods180()
        {
            this.accountAddInterestExtra = new WzorceProj.state_odsetki.AccountAddInterestExtra();
            r = new Rachunek("123", "imie", "nazwisko");
            r.Wplata(8000);

            Assert.IsTrue(180 == this.accountAddInterestExtra.RunInterest(r), "Błędne naliczanie odsetek dla progu > 5000");

        }
    }
}
