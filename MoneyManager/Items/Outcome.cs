using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Items
{
    class Outcome : Item
    {
        public Outcome(int id, decimal amount, string name, DateTime date)
        {
            Id = id;
            Amount = amount;
            Name = name;
            Date = date;
            Type = ItemType.Outcome;
        }
    }
}
