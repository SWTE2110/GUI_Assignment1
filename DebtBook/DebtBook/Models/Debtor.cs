using System;
using System.Collections.Generic;
using System.Text;

namespace DebtBook.Models
{
    public class Debtor
    {
        private List<Debt> _debts;
        private readonly string _name;
        private int _sum;

        public Debtor()
        {
            _debts = new List<Debt>();
            _name = "";
            _sum = 0;

        }

        public Debtor(Debt d, string name)
        {
            _debts = new List<Debt>();
            AddDebt(d);
            _name = name;
            _sum = 0;
        }

        public void AddDebt(Debt d)
        {
            _debts.Add(d);
        }

        public void SumDebt()
        {
            int _sum = 0;
            foreach (Debt d in _debts)
            {
                _sum += d.Amount;
            }
        }

        public override string ToString()
        {
            return _name + "                  " + _sum;
        }
    }
}
