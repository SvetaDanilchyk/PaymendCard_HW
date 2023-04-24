

namespace HW_Cards.PaymentCards
{
    internal class DebetCard : PaymentCards
    {
        public float DepositPercent { get; set; }

        public DebetCard (string namberCard, DateTime data, short ccvCard, float balance,float depositPercent):base(namberCard,data,ccvCard, balance)
        {
            DepositPercent = depositPercent;
        }
        public override bool  Pay(float amount)
        {
            if (Balance > amount)
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

        public override string ToString()
        {
            return " DebetCard balanse:  " + Balance; 
        }

    }
}
