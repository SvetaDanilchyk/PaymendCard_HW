using HW_Cards;
using HW_Cards.BankCore;
using HW_Cards.PaymentCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Card.Comparers
{
    internal class NumberCardComparer : IComparer<BankClient>
    {
        //private List<PaymentCards> GetClientPaymentCards(BankClient? client)
        //{
            
        //    List<PaymentCards> clientPaymentCards = new List<PaymentCards>();
        //    foreach (IPayment i in client.PaymentMeans)
        //    {
        //        if (i is PaymentCards)
        //        {
        //            clientPaymentCards.Add((PaymentCards)i);
        //        }
        //    }

        //    return clientPaymentCards;
        //}
        public int Compare(BankClient? client1, BankClient? client2)
        {
            return Helper.GetClientPaymentCards(client1).Count.CompareTo(Helper.GetClientPaymentCards(client2).Count);
        }
    }
}
