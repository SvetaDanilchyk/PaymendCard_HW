using HW_Cards.PaymentCards;
using HW_Cards;
using HW_Cards.BankCore;
using HW_Cards.PaymentMeans;

namespace Card.Comparers
{
    internal class Helper
    {
        public static List<Cash> GetClientsPaymendMeans(BankClient? client)
        {
            List<Cash> clientCash = new List<Cash>();
            
            foreach (IPayment i in client.PaymentMeans)
            {
                if (i is Cash)
                {
                    clientCash.Add((Cash)i);
                }
            }
            return clientCash;
        }
        public static  List<PaymentCards> GetClientPaymentCards(BankClient? client)
        {

            List<PaymentCards> clientPaymentCards = new List<PaymentCards>();
            foreach (IPayment i in client.PaymentMeans)
            {
                if (i is PaymentCards)
                {
                    clientPaymentCards.Add((PaymentCards)i);
                }
            }

            return clientPaymentCards;
        }
    }
}
