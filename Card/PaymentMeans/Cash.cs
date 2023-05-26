
namespace Card.PaymentMeans
{
    public class Cash : PaymentTool
    {
        public Cash(float balance) : base(balance) { }

        public override bool Pay(float amount)
        {
            if (Balance - amount > 0)
            {
                Balance -= amount;    
                return true;
            }
            return false;
        }

        public override bool TopUp(float sum)
        {
            if (sum > 0)
            {
                Balance += sum;
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj is BitCoin)
            {
                return Balance == ((BitCoin)obj).Balance;
            }
            return false;

        }

        public override string ToString()
        {
            return string.Format("Cash balance: {0} ", Balance);
        }

    }
}
