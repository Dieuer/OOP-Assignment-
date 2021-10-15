using System;
using System.Threading;

namespace EksamenOpgaveOOP
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) :base(user, amount)
        {

        }


        /// <exception cref="Exception"></exception>
        public override void Execute()
        {
            if (Amount <= 0)
            {
                throw new Exception("you can insert negative credits");
            }
            base.Execute();
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
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
            if (Date == null)
            {
                throw new ArgumentNullException("Date and time cannot be null");
            }
            return string.Format("Id: {0}, User: {1}, Amount: {2}, Date: {3} - (Credit Transaction)", ID, User.UserName, Amount, Date);
        }
    }
}
