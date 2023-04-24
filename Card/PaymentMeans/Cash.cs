
namespace HW_Cards.PaymentMeans
{
    internal class Cash : IPayment
    {
        public float CashMeans { get; set; }

        public Cash(float cashMeans)
        { 
            CashMeans = cashMeans;
        }
        public bool Pay(float amount)
        {
            if (CashMeans - amount > 0)
            {
                CashMeans -= amount;    
                return true;
            }
            return false;
        }

        public bool TopUp(float sum)
        {
            if (sum > 0)
            {
                CashMeans += sum;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format(" Cash balance: {0}", CashMeans);
        }

    }
}
