using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Items
{
    abstract class Item
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Amount { get; protected set; }
        public DateTime Date { get; protected set; }
        public ItemType Type { get; protected set; }
    }
}
