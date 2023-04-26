using HW_Cards;
using HW_Cards.BankCore;
using HW_Cards.PaymentCards;
using HW_Cards.PaymentMeans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Card.Comparers
{
    internal class AllMeansComparer : IComparer<BankClient>
    {
        private float AllMeans(BankClient? client)
        {
            float allMeans = 0;

            foreach (PaymentCards i in Helper.GetClientPaymentCards(client))
            {
                allMeans += i.Balance;
            }
            foreach (Cash i in Helper.GetClientsPaymendMeans(client))
            {
                allMeans += i.CashMeans;
            }

            return allMeans;
        }
        public int Compare(BankClient? client1, BankClient? client2)
        {
            
            return AllMeans(client1).CompareTo(AllMeans(client2));
        }
    }
}
