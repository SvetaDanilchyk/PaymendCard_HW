
namespace HW_Cards.PaymentCards
{
    internal class CreditCard : PaymentCards
    {
        public float CreditPercent { get; set; }
        public float Limit { get; set; }

        private float BalanceLimit; 
        public CreditCard(string namberCard, DateTime data, short ccvCard,float balance, float creditPercent, float limit) : base(namberCard, data, ccvCard, balance)
        {
            CreditPercent = creditPercent;
            Limit = limit;
            BalanceLimit = Limit + Balance;
        }
        public override  bool Pay(float amount)
        {
            BalanceLimit = Balance + Limit;

            if (BalanceLimit > amount )
            {
                BalanceLimit -= amount;
                return true;
            }
            return false;
        }

       public override bool TopUp(float sum)
        {
            if (sum > 0)
            {
                Balance += sum;
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return string.Format(" Credit Card available funds : {0}", BalanceLimit);
        }
    }
}
