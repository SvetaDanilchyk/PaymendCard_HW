using Card.BankCore;
using Card.PaymentMeans;

namespace Card.Comparers;

internal class MaxAmountPayment : IComparer<BankClient>
{
    public float MaxAmount(BankClient client)
    {
        if (client == null)
        {
            throw new ArgumentNullException("client null");
        }

        float max = client.PaymentMeans.OfType<PaymentTool>().Select(x => x.Balance).Max();

        return max;
    }
    public int Compare(BankClient client1, BankClient client2)
    {
        if (client1 == null && client2 == null) return 0;
        if (client1 != null && client2 == null) return -1;
        if (client1 == null && client2 != null) return 1;

        return MaxAmount(client1).CompareTo(MaxAmount(client2));

    }

   
}
