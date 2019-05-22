using MoneyManager.Db;
using MoneyManager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Statistics
{
    class Summary
    {
        private IReader _reader;

        public Summary(IReader reader)
        {
            _reader = reader;
        }

        public void DisplayReport(int year, int month)
        {
            IEnumerable<Item> list = GetItems(year, month);

            decimal incomes = SumIncomes(list);
            decimal outcomes = SumOutcomes(list);

            decimal balance = Balance(incomes, outcomes);

            Console.WriteLine("Podsumowanie {0}/{1}", month, year);

            Console.WriteLine("Suma dochodów: {0}zł", incomes);
            Console.WriteLine("Suma wydatków: {0}zł", outcomes);
            Console.WriteLine("====================");
            Console.WriteLine("Bilans: {0}zł", balance);
        }

        private IEnumerable<Item> GetItems(int year, int month)
        {
            IEnumerable<Item> list = _reader.ReadAll();

            List<Item> reportList = new List<Item>();

            foreach (Item item in list)
            {
                if (item.Date.Year == year && item.Date.Month == month)
                {
                    reportList.Add(item);
                }
            }

            return reportList;
        }

        private decimal SumIncomes(IEnumerable<Item> list)
        {
            decimal sum = 0.0M;

            foreach(Item item in list)
            {
                if (item.Type == ItemType.Income)
                {
                    sum += item.Amount;
                }
            }

            return sum;
        }

        private decimal SumOutcomes(IEnumerable<Item> list)
        {
            decimal sum = 0.0M;

            foreach (Item item in list)
            {
                if (item.Type == ItemType.Outcome)
                {
                    sum += item.Amount;
                }
            }

            return sum;
        }

        private decimal Balance(decimal incomes, decimal outcomes)
        {
            return incomes - outcomes;
        }
    }
}
