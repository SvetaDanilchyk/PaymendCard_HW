using HW_Cards;
using Card.BankCore;
using HW_Cards.PaymentCards;
using HW_Cards.PaymentMeans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Card.Comparers
{
    internal class MaxAmounOnePaymend : IComparer<BankClient>
    {

        private float MaxAmount(BankClient? client)
        {
           float max = Math.Max( Helper.GetClientsPaymendMeans(client).Select(x => x.Balance).Max(),
                                 Helper.GetClientPaymentBitCoin(client).Select(x => x.Balance).Max());
            return Math.Max( max, MaxAmount(client) );
            /*
            List<float> balance = new List<float>
              foreach (PaymentCards i in Helper.GetClientPaymentCards(client))
            {
                balance.Add((float)i.Balance);
            }
            foreach (Cash i in Helper.GetClientsPaymendMeans(client))
            {
                balance.Add((float)i.CashMeans);
            }*/

        }
        public int Compare(BankClient? client1, BankClient? client2)
        {
            
          return MaxAmount(client1).CompareTo(MaxAmount(client2));

        }

       
    }
}
