using System;
namespace EksamenOpgaveOOP
{
    public class SeasonalProduct : Product
    {
        private DateTime _seasonStartDate;
        private DateTime _seasonEndDate;

        public SeasonalProduct(int id, string productName, decimal price, bool isActive, string deactiveDate, bool canBeBoughtOnCredit,DateTime seasonStartDate, DateTime SeasonEndDate)
            : base(id, productName, price, isActive, deactiveDate, canBeBoughtOnCredit)
        {
            _seasonStartDate = seasonStartDate;
            _seasonEndDate = SeasonEndDate;
        }

        public DateTime SeasonStartDate
        {
            get => _seasonStartDate;
            set
            {
                _seasonStartDate = value;
            }
        }

        public DateTime SeasonEndDate
        {
            get => _seasonEndDate;
            set
            {
                _seasonEndDate = value;
            }
        }
    }
}
