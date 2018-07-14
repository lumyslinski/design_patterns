using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WzorceProj;
using WzorceProj.state_odsetki;

namespace TestProjectWzorceProj
{
    [TestClass]
    public class UnitTestAccountAddInterest
    {
        private AccountAddInterest accountAddInterest;
        private Rachunek r;

        [TestMethod]
        public void Test_AccountAddInterest_WE_wp100_WY_ods1()
        {
            this.accountAddInterest = new WzorceProj.state_odsetki.AccountAddInterest();
            r = new Rachunek("123", "imie", "nazwisko");
            r.Wplata(100);

            Assert.IsTrue(1 == this.accountAddInterest.RunInterest(r),"Błędne naliczanie odsetek dla progu < 10000");
            
        }

        [TestMethod]
        public void Test_AccountAddInterest_WE_wp34211_WY_ods58422()
        {
            this.accountAddInterest = new WzorceProj.state_odsetki.AccountAddInterest();
            r = new Rachunek("123", "imie", "nazwisko");
            r.Wplata(34211);

            Assert.IsTrue(584.22 == this.accountAddInterest.RunInterest(r), "Błędne naliczanie odsetek dla progu < 50000");
        }

        [TestMethod]
        public void Test_AccountAddInterest_WE_wp94211_WY_ods222633()
        {
            this.accountAddInterest = new WzorceProj.state_odsetki.AccountAddInterest();
            r = new Rachunek("123", "imie", "nazwisko");
            r.Wplata(94211);

            Assert.IsTrue(2226.33 == this.accountAddInterest.RunInterest(r), "Błędne naliczanie odsetek dla progu > 50000");
        }
        
    }
}
