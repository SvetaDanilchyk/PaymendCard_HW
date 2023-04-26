using HW_Cards;
using HW_Cards.BankCore;
using HW_Cards.PaymentCards;
using HW_Cards.PaymentMeans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Card.Comparers
{
    internal class MaxAmounOnePaymend : IComparer<BankClient>
    {
        private List<float> MaxAmoun(BankClient? client)
        {
            List<float> balance = new List<float>();

            foreach (PaymentCards i in Helper.GetClientPaymentCards(client))
            {
                balance.Add((float)i.Balance);
            }
            foreach (Cash i in Helper.GetClientsPaymendMeans(client))
            {
                balance.Add((float)i.CashMeans);
            }

            return balance;
        }
        public int Compare(BankClient? client1, BankClient? client2)
        {
           
            return MaxAmoun(client1).Max().CompareTo(MaxAmoun(client2).Max());

        }

       
    }
}
