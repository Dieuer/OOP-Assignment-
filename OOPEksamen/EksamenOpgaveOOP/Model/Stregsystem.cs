using System;
using System.Collections.Generic;
using System.Linq;
using EksamenOpgaveOOP.Exceptions;
using EksamenOpgaveOOP.Model;

namespace EksamenOpgaveOOP
{
    public class Stregsystem : IStregsystem
    {
        readonly CsvHandler csvHandler = new CsvHandler();

        public ICollection<User> FullUserList { get; set; }
        public ICollection<Product> FullProductList { get; set; }
        public ICollection<Transaction> TransactionList { get; set; }
        public ICollection<Product> ActiveProductList  { get; set; }


        public Stregsystem()
        {
            AddProducts(csvHandler.LoadAllProducts());
            AddUsers(csvHandler.LoadAllUsers());
            LoadActiveProducts();
        }

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            if (user == null)
            {
                throw new UserNameNotFoundException($"{user.UserName} not found");
            }
            if (count < 0 || count > 10)
            {
                throw new ArgumentOutOfRangeException("Invalid count");
            }
            return TransactionList
                .Where(x => x.User == user)
                .OrderByDescending(x => x.Date) 
                .Take(count);
        }

        /// <exception cref="ProductIdNotFoundException"></exception>
        public Product GetProductByID(int id)
        {
            if (id == 0 || id < 0)
            {
                throw new ProductIdNotFoundException($"{id} is an invalid product id");
            }
            return ActiveProductList.FirstOrDefault(x => x.Id == id) ?? throw new ProductIdNotFoundException($"Could not find product with id: {id}");
        }

        /// <exception cref="UserNameNotFoundException"></exception>
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new UserNameNotFoundException($"Could not find user: {username}");
            }
            return FullUserList.FirstOrDefault(x => x.UserName == username) ?? throw new UserNameNotFoundException($"Could not find user: {username}");
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public BuyTransaction MultiBuyProduct(User user, int count, Product product)
        {
            if (count < 2)
            {
                throw new ArgumentOutOfRangeException($"{count} cannot be less than 2");
            }

            count--;
            for (int i = 0; i < count; i++)
            {
                BuyProduct(user, product);
            }
            return BuyProduct(user, product);
        }

        /// <exception cref="ArgumentNullException"></exception>
        public BuyTransaction BuyProduct(User user, Product product)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Could not find user");
            }

            if (product == null)
            {
                throw new ArgumentNullException("Could not find product");
            }

            BuyTransaction buyTransaction = new BuyTransaction(user, product);

            ExecuteTransaction(buyTransaction);
            return buyTransaction;
        }

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public InsertCashTransaction AddCredits(User user, decimal amount)
        {
            if (user == null)
            {
                throw new UserNameNotFoundException($"Could not find user {user}");
            }
            if (amount < 1)
            {
                throw new ArgumentException("Warning! Could not add credits to balance");
            }

            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, amount);

            ExecuteTransaction(insertCashTransaction);
            return insertCashTransaction;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public Transaction ExecuteTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("Transaction is null");
            }
            transaction.Execute();
            csvHandler.AddToTransactionCSV(transaction);
            TransactionList.Add(transaction);

            return transaction;
        }

        /// <exception cref="ProductIdNotFoundException"></exception>
        /// <exception cref="AdminCommandNotFoundException"></exception>
        public void ChangeCreditProductState(string state, int productId)
        {
            Product product = FullProductList.FirstOrDefault(x => x.Id == productId) ?? throw new ProductIdNotFoundException($"Could not find product with id: {productId}");

            if (state == ":crediton")
            {
                product.CanBeBoughtOnCredit = true;
            }
            else if (state == ":creditoff")
            {
                product.CanBeBoughtOnCredit = false;
            }
            else
            {
                throw new AdminCommandNotFoundException($"Invalid admin command: {state}");
            }
        }

        /// <exception cref="ProductIdNotFoundException"></exception>
        /// <exception cref="AdminCommandNotFoundException"></exception>
        public void ChangeActivateProductState(string state, int productId)
        {
            Product product = FullProductList.FirstOrDefault(x => x.Id == productId) ?? throw new ProductIdNotFoundException($"Could not find product with id: {productId}"); ;

            if (state == ":activate")
            {
                product.IsActive = true;
            }
            else if(state == ":deactivate")
            {
                product.IsActive = false;
            }
            else
            {
                throw new AdminCommandNotFoundException($"Invalid admin command: {state}");
            }
        }

        /// <exception cref="NullReferenceException"></exception>
        public void LoadActiveProducts()
        {
            if (FullProductList == null)
            {
                throw new NullReferenceException($"Could not find fullProductList {FullProductList}");
            }
            if (ActiveProductList == null)
            {
                throw new NullReferenceException($"Could not find activeProductList {ActiveProductList}");
            }
            if (ActiveProductList.Count() > 0)
            {
                ActiveProductList.Clear();
            }

           
            foreach (Product product in FullProductList)
            {
                if (product.IsActive == true && product.DeactiveDate == "")
                {
                    ActiveProductList.Add(product);
                }
            }
        }

        /// <exception cref="ArgumentNullException"></exception>
        private void AddProducts(ICollection<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException($"Product {products} is null");
            }
            foreach (Product product in products)
            {
                FullProductList.Add(product);
            }
        }

        /// <exception cref="ArgumentNullException"></exception>
        private void AddUsers(ICollection<User> users)
        {
            if (users == null)
            {
                throw new ArgumentNullException($"Product {users} is null");
            }
            foreach (User user in users)
            {
                FullUserList.Add(user);
            }
        }
    }
}
