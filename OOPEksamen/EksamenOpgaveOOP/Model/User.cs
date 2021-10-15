using System;
using System.Text.RegularExpressions;

namespace EksamenOpgaveOOP
{
    public delegate void UserBlanaceNotification(User user, decimal balance);

    public class User 
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _username;
        private decimal _balance;
        private string _email;

        public User(int id, string firstname, string lastname, string username, decimal balance, string email)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Balance = balance;
            Email = email;
        }

        public int Id
        {
            get => _id;
            set
            {
                if(value < 1)
                {
                    throw new ArgumentException(nameof(value), "cannot be less than 1");
                }
                _id = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "cannot be null or empty");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "cannot be null or empty");
                }
                _lastName = value;
            }
        }

        public string UserName
        {
            get => _username;
            set
            {
                string strRegex = @"[0-9a-z_]";
                Regex regex = new Regex(strRegex, RegexOptions.Compiled);
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "cannot be null or empty");
                }
                if (regex.IsMatch(value))
                {
                    _username = value;
                }
                else
                {
                    throw new ArgumentException("User name did not pass pattern check");
                }
                
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                string strRegex = @"(^[\w-,]+)@(([\w]+.)+[\w]+(?=[\s]|$))";
                Regex regex = new Regex(strRegex, RegexOptions.Compiled);

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "cannot be null or empty");
                }
                if (regex.IsMatch(value))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email did not pass pattern check");
                }
            }
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
            }
        }

        public override string ToString()
        {
            if (FirstName == "")
            {
                throw new ArgumentException("User first name cannot be empty");
            }
            if (FirstName == null)
            {
                throw new NullReferenceException("User first name cannot be null");
            }
            if (Email == "")
            {
                throw new ArgumentException("User email cannot be empty");
            }
            if (Email == null)
            {
                throw new NullReferenceException("User email cannot be null");
            }
            return string.Format("Firstname {0}, Email {1}, Balance", FirstName, Email, Balance);
        }
    }
}
