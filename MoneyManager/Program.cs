using MoneyManager.Db;
using MoneyManager.Db.Files;
using MoneyManager.Items;
using MoneyManager.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
    class Program
    {
        static IWriter _writer;
        static IReader _reader;
        static void Main(string[] args)
        {
            _reader = new Reader("database.txt");
            _writer = new Writer("database.txt");
            string selected;
            do
            {
                DisplayMenu();
                selected = Console.ReadLine();
                RunSelected(selected);
            }
            while (selected != "6");
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Lista");
            Console.WriteLine("2 - Raport miesięczny");
            Console.WriteLine("3 - Dodaj wydatek");
            Console.WriteLine("4 - Dodaj dochód");
            Console.WriteLine("5 - Usuń pozycję");
            Console.WriteLine("6 - Zakończ");
            Console.WriteLine("Wybrana opcja:");
        }

        private static void RunSelected(string selected)
        {
            switch(selected)
            {
                case "1":
                    ShowList();
                    break;
                case "2":
                    ShowReport();
                    break;
                case "3":
                    AddOutcome();
                    break;
                case "4":
                    AddIncome();
                    break;
                case "5":
                    RemoveItem();
                    break;
            }
        }

        private static void ShowList()
        {
            Console.Clear();

            List list = new List(_reader);

            Console.WriteLine("Wszystkie pozycje:");
            list.DisplayList();

            Console.ReadKey();

        }

        private static void ShowReport()
        {
            Console.Clear();

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            Summary report = new Summary(_reader);

            report.DisplayReport(year, month);

            Console.ReadKey();
        }

        private static void AddOutcome()
        {
            Console.Clear();

            Console.WriteLine("Nowy wydatek");

            Console.WriteLine("Nazwa: ");
            string name = Console.ReadLine();

            Console.WriteLine("Kwota: ");
            string value = Console.ReadLine();
            decimal amount = decimal.Parse(value);

            Console.WriteLine("Data: ");
            value = Console.ReadLine();
            DateTime date = DateTime.Parse(value);

            Service service = new Service(_reader, _writer);

            service.AddOutcome(amount, name, date);
        }

        private static void AddIncome()
        {
            Console.Clear();

            Console.WriteLine("Nowy dochód");

            Console.WriteLine("Nazwa: ");
            string name = Console.ReadLine();

            Console.WriteLine("Kwota: ");
            string value = Console.ReadLine();
            decimal amount = decimal.Parse(value);

            Console.WriteLine("Data: ");
            value = Console.ReadLine();
            DateTime date = DateTime.Parse(value);

            Service service = new Service(_reader, _writer);

            service.AddIncome(amount, name, date);
        }

        private static void RemoveItem()
        {
            Console.Clear();

            Console.WriteLine("Podaj ID do usunięcia: ");

            string value = Console.ReadLine();

            int id = int.Parse(value);

            Service service = new Service(_reader, _writer);

            service.RemoveById(id);
        }
    }
}
