using System;

namespace EksamenOpgaveOOP
{
    public class Product
    {
        private int _id;
        private string _productName;
        private decimal _price;
        private bool _isActive;
        private string _deactiveDate;
        private bool _canBeBoughtOnCredit;

        public Product(int id, string productName, decimal price, bool isActive, string deactiveDate, bool canBeBoughtOnCredit)
        {
            Id = id;
            Name = productName;
            Price = price;
            IsActive = isActive;
            DeactiveDate = deactiveDate;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public int Id
        {
            get => _id;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(_id), "cannot be less than 1");
                }
                _id = value;
            }
        }

        public string Name
        {
            get => _productName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "cannot be null or empty");
                }

                _productName = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot be negative");
                }
                _price = value;
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
            }
        }

        public string DeactiveDate
        {
            get => _deactiveDate;
            set
            {
                if (value == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "cannot be null");
                }
                _deactiveDate = value;
            }
        }

        public bool CanBeBoughtOnCredit
        {
            get => _canBeBoughtOnCredit;
            set
            {
                _canBeBoughtOnCredit = value;
            }
        }
       
        public override string ToString()
        {
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Transaction ID cannot be less than 1");
            }
            if (Name == null)
            {
                throw new NullReferenceException("Could not find product name, null");
            }
            if (Name == "")
            {
                throw new ArgumentException("Product name cannot be empty");
            }
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException("Product price cannot be negative");
            }
            return string.Format("Product ID {0}, Product name {1}, Product price {2}", Id, Name, Price);
        }
    }
}
