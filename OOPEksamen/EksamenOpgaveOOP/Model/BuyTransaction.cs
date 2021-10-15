using System;
using EksamenOpgaveOOP.Exceptions;
using EksamenOpgaveOOP;
namespace EksamenOpgaveOOP
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, Product product) : base(user, product.Price)
        {
            Product = product;
        }

        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InsufficientCreditsException"></exception>
        /// <exception cref="ProductIsNotActiveException"></exception>
        public override void Execute()
        {
            if (Product.Price < 0)
            {
                throw new ArgumentException("Product cannot have negative price");
            }
            if (User.Balance - Product.Price < 0 && Product.CanBeBoughtOnCredit == false)
            {
                throw new InsufficientCreditsException();
            }
            if (Product.IsActive == false)
            {
                throw new ProductIsNotActiveException(Product);
            }
            User.Balance -= Product.Price;
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public override string ToString()
        {
            if (ID < 1)
            {
                throw new ArgumentOutOfRangeException("Transaction ID cannot be less than 1");
            }
            if (User.UserName == null)
            {
                throw new NullReferenceException("Could not find user name, null");
            }
            if (User.UserName == "")
            {
                throw new ArgumentException("user name cannot be empty");
            }
            if (Product.Name == null)
            {
                throw new NullReferenceException("Could not find product name, null");
            }
            if (Product.Name == "")
            {
                throw new ArgumentException("product name cannot be empty");
            }
            if (Date == null)
            {
                throw new ArgumentNullException("Date and time cannot be null");
            }
            return string.Format("Id: {0}, User: {1}, Product: {2}, Amount: {3}, Date: {4} - (Buy Transaction)", ID, User.UserName ,Product.Name, Product.Price, Date);
        }

    }
}
