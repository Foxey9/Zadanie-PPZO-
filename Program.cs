using System;
using System.Collections.Generic;

namespace ExpenseTracker
{
    public class Expense
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }

    public class ExpenseTracker
    {
        private List<Expense> expenses;

        public ExpenseTracker()
        {
            expenses = new List<Expense>();
        }

        public void AddExpense(DateTime date, string description, decimal amount, string comment)
        {
            Expense expense = new Expense
            {
                Date = date,
                Description = description,
                Amount = amount,
                Comment = comment
            };

            expenses.Add(expense);
        }

        public void RemoveExpense(int Numer)
        {
            if (Numer >= 0 && Numer < expenses.Count)
            {
                expenses.RemoveAt(Numer);
                Console.WriteLine("dodatek jest usunięty");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy indeks");
            }
        }

        public List<Expense> GetExpenses()
        {
            return expenses;
        }

        public decimal GetTotalAmount()
        {
            decimal total = 0;
            foreach (var expense in expenses)
            {
                total += expense.Amount;
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExpenseTracker expenseTracker = new ExpenseTracker();

            while (true)
            {
                Console.WriteLine("Lista wydatków");
                Console.WriteLine("1. Dodaj wydatek");
                Console.WriteLine("2. Zobać historię wydatków");
                Console.WriteLine("3. Usuń wydatek");
                Console.WriteLine("4. Suma koszów");
                Console.WriteLine("5. Wyjście");
                Console.Write("Wprowadż commandę: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Wprowadż datę (dd-mm-rrrr): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Wpisz nazwę: ");
                        string description = Console.ReadLine();
                        Console.Write("Wpisz sumę w PLN: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        Console.Write("Wpisz commentarz: ");
                        string comment = Console.ReadLine();

                        expenseTracker.AddExpense(date, description, amount, comment);
                        Console.WriteLine("Wydatek dodano");
                        break;
                    case "2":
                        List<Expense> expenses = expenseTracker.GetExpenses();
                        Console.WriteLine("Historia wydatków:");
                        for (int i = 0; i < expenses.Count; i++)
                        {
                            Console.WriteLine($"Numer: {i}, Data: {expenses[i].Date.ToShortDateString()}, Nazwa: {expenses[i].Description}, Suma: {expenses[i].Amount}, Commentarz: {expenses[i].Comment}");
                        }
                        break;
                    case "3":
                        Console.Write("Wpisz jaki wydatek chcesz usunąć: ");
                        int Numer = int.Parse(Console.ReadLine());
                        expenseTracker.RemoveExpense(Numer);
                        break;
                    case "4":
                        decimal totalAmount = expenseTracker.GetTotalAmount();
                        Console.WriteLine($"Suma: {totalAmount}");
                        break;
                    case "5":
                        Console.WriteLine("wychodzimy z applikacji");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
