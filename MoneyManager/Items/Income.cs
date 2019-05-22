using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Items
{
    class Income : Item
    {
        public Income(int id, decimal amount, string name, DateTime date)
        {
            Id = id;
            Amount = amount;
            Name = name;
            Date = date;
            Type = ItemType.Income;
        }
    }
}
