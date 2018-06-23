using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzorceProj
{
    public class Rachunek : BankingProduct
    {
        private String _numer;
        private String imie, nazwisko;
        private double _saldo;

        public String Numer
        {
            get { return _numer; }
        }

        public String ImieNazwisko
        {
            get { return imie + "" + nazwisko; }
        }
        
        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public double WartoscOdsetek
        {
            get {
                WzorceProj.state_odsetki.AccountAddInterest accaddi = new state_odsetki.AccountAddInterest();
                return accaddi.RunInterest(this);
            }
        }
      
        private List<string> historia = new List<string>();

        /**
         * Utworzenie rachunku
         * @param numer
         * @param imie
         * @param nazwisko
         */
        public Rachunek(String numer, String imie, String nazwisko)
        {
            this._numer = numer;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this._saldo = 0;
            
        }

        // Wypisz historię rachunku
        public void PiszHistorie() {
		  Console.WriteLine(historia);
	    }

        // Zwróć ostatnią wiadomość z historii
        public string ZwrocOstatniaWiadomosc()
        {
            if (historia.Count() > 0)
            {
                return historia.First();
            }
            else
            {
                return "Brak historii!";
            } 
        }
        
        // Dodaj wiadomość do historii rachunku
        public void SetHistoria(string h)
        {
            historia.Add(h);
        }

        // Wpłata na rachunek
        public override void Wplata(double kwota)
        {
            WzorceProj.command_operacje.Income income = new WzorceProj.command_operacje.Income(kwota);
            this.Saldo = income.Execute(this);
        }

        // Wypłata na rachunek bez debetu
        public override void Wyplata(double kwota)
        {
            WzorceProj.command_operacje.Payment p = new WzorceProj.command_operacje.Payment(kwota);
            this.Saldo = p.Execute(this);
        }

        // Przelew na rachunek bez debetu
        public override void Przelew(double kwota, Rachunek docelowy)
        {
            this.Wyplata(kwota);
            WzorceProj.command_operacje.Income income = new WzorceProj.command_operacje.Income(kwota);
            docelowy.Saldo = income.Execute(docelowy);
        }
    }
}
