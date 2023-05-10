using Card.BankCore;
using Card.PaymentMeans.PaymentCards;

namespace Card.Comparers;

internal class CountCardComparer : IComparer<BankClient>
{
    public int Compare(BankClient client1, BankClient client2)
    {
        if (client1 == null && client2 == null) return 0;
        if (client1 != null && client2 == null) return -1;
        if (client1 == null && client2 != null) return 1;

        return  client1.PaymentMeans.Where(x => x is PaymentCards).Count()
            .CompareTo(client2.PaymentMeans.Where(x => x is PaymentCards).Count());
    }
}
