using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace DebtBook.Models
{
   public class Debt
    {
        private readonly DateTime _date;
        private readonly int _amount;

        public Debt(DateTime date, int amount)
        {
            _date = date;
            _amount = amount;
        }

        public int Amount => _amount;
    }
}
