using System;
namespace EksamenOpgaveOOP
{
    public abstract class Transaction
    {
        public static int GlobalId = 1;
        public User User { get; }
        public Product Product { get; set;}
        public DateTime Date { get; } 
        public decimal Amount { get; }

        public Transaction(User user, decimal amount)
        {
            User = user;
            Amount = amount;
            Date = DateTime.Now;
        }

        public int ID { get; } = GlobalId++;


        /// <exception cref="ArgumentNullException"></exception>
        public virtual void Execute()
        {
            if (User == null)
            {
                throw new ArgumentNullException("User not found during transaction (null)");
            }
            User.Balance += Amount;
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
            if (Amount == 0)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be 0");
            }
            if (Date == null)
            {
                throw new ArgumentNullException("Date and time cannot be null");
            }
            return string.Format("Id: ({0}, User: {1}, Amount: {2}, Date: {3}", ID, User.UserName, Amount ,Date);
        }
    }
}
