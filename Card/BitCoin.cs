using HW_Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    internal class BitCoin : IPayment
    {
        public float Balance { get; set; }

        public BitCoin(float balance) 
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
            return string.Format(" Bitcoin: {0}", Balance);
        }
    }
}
