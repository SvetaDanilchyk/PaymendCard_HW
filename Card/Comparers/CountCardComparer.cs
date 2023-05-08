using HW_Cards;
using Card.BankCore;
using HW_Cards.PaymentCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Card.Comparers
{
    internal class CountCardComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? client1, BankClient? client2)
        {
            // return Helper.GetClientPaymentCards(client1).Count.CompareTo(Helper.GetClientPaymentCards(client2).Count);
            return  client1.PaymentMeans.Where(x => x is PaymentCards).Count()
                .CompareTo(client2.PaymentMeans.Where(x => x is PaymentCards).Count());
        }
    }
}
