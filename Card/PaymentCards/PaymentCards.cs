
namespace HW_Cards.PaymentCards
{
    internal abstract class PaymentCards : IPayment
    {
       
        public string NamberCard { get; private set; }
        private DateTime _date;
        public short CcvCard { get; private set; }
        public float Balance { get; protected set; }
        public DateTime ExpirityData
        {
            get
            {
                return _date;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    _date = value;
                }
            }
        }

        public PaymentCards(string namberCard, DateTime data, short ccvCard,  float balance)
        {
            NamberCard = namberCard;
            ExpirityData = data;
            CcvCard = ccvCard;
            Balance = balance;

        }
       
        public abstract bool Pay(float amount);
        public abstract bool TopUp(float sum);

    }
}
