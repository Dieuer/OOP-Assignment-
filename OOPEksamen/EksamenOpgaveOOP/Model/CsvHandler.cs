using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EksamenOpgaveOOP.Model
{
    public class CsvHandler
    {
        public CsvHandler()
        {
        }

        public ICollection<Product> LoadAllProducts()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "CsvFiles", "Products.csv");

            ICollection<Product> productList = new List<Product>();

            if (File.Exists(path))
            {
                var allProducts = File
                    .ReadAllLines(path)
                    .Skip(1);

                foreach (var product in allProducts)
                {
                    string[] array = product.Split(';');

                    int productId = int.Parse(array[0]);
                    string productName = array[1];
                    decimal productPrice = decimal.Parse(array[2]);
                    bool productIsActive = int.Parse(array[3]) == 0 ? false : true;
                    string productDeactiveDate = array[4];
                    bool productCanBeBoughtOnCredit = false;
                    productList.Add(new Product(productId, productName, productPrice, productIsActive, productDeactiveDate, productCanBeBoughtOnCredit));
                }
            }
            return productList;
        }
        public ICollection<User> LoadAllUsers()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "CsvFiles", "Users.csv");
            ICollection<User> userList = new List<User>();

            if (File.Exists(path))
            {
                var allUsers = File
                    .ReadAllLines(path)
                    .Skip(1);

                foreach (var user in allUsers)
                {
                    string[] array = user.Split(',');

                    int userId = int.Parse(array[0]);
                    string userFirstName = array[1];
                    string userLastName = array[2];
                    string userUserName = array[3];
                    decimal userBalance = decimal.Parse(array[4]);
                    string userEmail = array[5];
                    userList.Add(new User(userId, userFirstName, userLastName, userUserName, userBalance, userEmail));
                }
            }
            return userList;
        }

        public void AddToTransactionCSV(Transaction transaction)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "CsvFiles", "Transactions.csv");

                using StreamWriter file = File.AppendText(path);
                file.WriteLine(transaction);
        }
    }
}
