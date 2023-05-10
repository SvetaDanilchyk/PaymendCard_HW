using Card.BankCore;

namespace Card.Comparers;

internal class ClientNameComparer : IComparer<BankClient>
{
    public int Compare(BankClient client1, BankClient client2)
    {
        if (client1 == null && client2 == null) return 0;
        if (client1 != null && client2 == null) return -1;
        if (client1 == null && client2 != null) return 1;

        return client1.Name.CompareTo(client2.Name);
    }
}
