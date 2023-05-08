﻿
namespace HW_Cards.PaymentMeans
{
    internal class Cash : IPayment
    {
        public float Balance { get; set; } //CashMeans

        public Cash(float balance)
        { 
            Balance = balance;
        }
        public bool Pay(float amount)
        {
            if (Balance - amount > 0)
            {
                Balance -= amount;    
                return true;
            }
            return false;
        }

        public bool TopUp(float sum)
        {
            if (sum > 0)
            {
                Balance += sum;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format(" Cash balance: {0}", Balance);
        }

    }
}
