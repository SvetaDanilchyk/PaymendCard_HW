

namespace HW_Cards.PaymentCards
{
    internal class CashBackCard : PaymentCards
    {
        public float CasBack { get; set; }
        private float BalanceCasBack;
        public CashBackCard(string namberCard, DateTime data,  short ccvCard, float balance,float cashBack) : base(namberCard, data, ccvCard, balance)
        {
            CasBack = cashBack;
            BalanceCasBack = Balance + CasBack;
        }

        public override  bool Pay(float amount)
        {
            if (BalanceCasBack > amount)
            {
                BalanceCasBack -= amount;
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

        public override string ToString()
        {
            return string.Format(" Cash Back card available funds: {0}", BalanceCasBack);
        }



    }
    
}
