using System;
using System.Collections.Generic;

namespace EksamenOpgaveOOP
{
    public interface IStregsystem
    {
        ICollection<User> FullUserList { get; set; }
        ICollection<Product> FullProductList { get; set; }
        ICollection<Transaction> TransactionList { get; set; }
        ICollection<Product> ActiveProductList { get; set; }

        IEnumerable<Transaction> GetTransactions(User user, int count);
        Product GetProductByID(int id);
        User GetUserByUsername(string username);
        BuyTransaction MultiBuyProduct(User user, int count, Product product);
        BuyTransaction BuyProduct(User user, Product product);
        InsertCashTransaction AddCredits(User user, decimal amount);
        Transaction ExecuteTransaction(Transaction transaction);
        void ChangeCreditProductState(string state, int productId);
        void ChangeActivateProductState(string state, int productId);
        void LoadActiveProducts();
    }
}

