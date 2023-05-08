using HW_Cards.PaymentCards;
using HW_Cards;
using Card.BankCore;
using HW_Cards.PaymentMeans;
using System.Collections.Generic;

namespace Card.Comparers
{
    internal class Helper
    {
        public static List<Cash> GetClientsPaymendMeans(BankClient? client) //public static List<Cash> GetClientsPaymendMeans(BankClient? client)
        {
            return client.PaymentMeans.Where(x => x is Cash).Select(x => (x as Cash)).ToList();
            
            //List<Cash> clientCash = new List<Cash>();

            //foreach (IPayment i in client.PaymentMeans)
            //{
            //    if (i is Cash)
            //    {
            //        clientCash.Add((Cash)i);
            //    }
            //}
            //return clientCash;
        }
        public static List<PaymentCards> GetClientPaymentCards(BankClient? client) /// public static List<Cash> GetClientPaymentCards(BankClient? client)
        {
            return client.PaymentMeans.Where(x => x is PaymentCards).Select(x => (x as PaymentCards)).ToList();

           /* List<PaymentCards> clientPaymentCards = new List<PaymentCards>();
            foreach (IPayment i in client.PaymentMeans)
            {
                if (i is PaymentCards)
                {
                    clientPaymentCards.Add((PaymentCards)i);
                }
            }

            return clientPaymentCards;*/
        }
        public static List<BitCoin> GetClientPaymentBitCoin(BankClient? client)
        {
            return client.PaymentMeans.Where(x => x is BitCoin).Select(x => (x as BitCoin)).ToList();
        }
    }
}
