using EksamenOpgaveOOP.Exceptions;
using EksamenOpgaveOOP.UI;
using System;
using System.Linq;


namespace EksamenOpgaveOOP.CLI
{

    public class StregsystemCLI : IStregsystemUI
    {
        public delegate void CommandEntered(string commandEntered);
        public event CommandEntered commandEntered;

        IStregsystem Stregsystem { get; set; }
        public StregsystemCLI(IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
        }


        public void MainMenu()
        {
            if (Stregsystem.ActiveProductList.Count() < 1)
            {
                Console.WriteLine("No active products");
            } 
            Stregsystem.ActiveProductList.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("1. Enter user name AND a product ID (seperated by space) to purchase from the list ");
            Console.WriteLine("2. Enter user name, amount and a product ID (seperated by space) for multibuy");
            Console.WriteLine("---------------------------------------------------------------------------------" + "\n");

        }

        public void Start()
        {
            Console.Clear();
            MainMenu();
            while (true)
            {
                string consoleString = Console.ReadLine();
                commandEntered(consoleString);
            }
        }

        public void Close()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        public void DisplayProductNotFound(ProductIdNotFoundException product)
        {
            Console.WriteLine($"{product.ProductId}");
        }

        public void DisplayUserInfo(User user)
        {
            Console.Clear();
            MainMenu();
            Console.WriteLine(user + ", balance: = " + user.Balance);
            if (user.Balance < 50)
            {
                Console.WriteLine("Warning! Credit balance is below 50!");
            }
        }

        public void DisplayUserNotFound(string user)
        {
            Console.Clear();
            MainMenu();
            Console.WriteLine($"{user}");
        }

        public void DisplayAdminCommandNotFoundMessage(string command)
        {
            Console.WriteLine($"Admin command ({command}) is invalid");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        public void DisplayInsufficientCash()
        {
            Console.WriteLine("Warning! Insufficient credits to buy product");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.Clear();
            MainMenu();
            Console.WriteLine(transaction + " was sucessfull");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.Clear();
            MainMenu();
            Console.WriteLine("Multibuy " + count + ". "+ transaction + " was sucessfull");
        }

        public void DisplayAdminMessage(string message)
        {
            Console.Clear();
            MainMenu();
            Console.WriteLine(message);
        }

        public void DisplayAdminInsertCredit(decimal amount, User user)
        {
            Console.WriteLine($"{amount} credits has been added to {user.UserName}");
        }

        public void DisplayTransactionList(User user, int count)
        {
            Console.WriteLine("\n" + "Recent transactions:");

            if (Stregsystem.GetTransactions(user, count).Count() == 0)
            {
                Console.WriteLine("No transactions so far");
            }
            foreach (Transaction transaction in Stregsystem.GetTransactions(user, count))
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("");
        }
    }
}
