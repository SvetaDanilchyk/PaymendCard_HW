﻿using Card.BankCore;
using Card.PaymentMeans;

namespace Card.Comparers;

internal class AllMeansComparer : IComparer<BankClient>
{
    public int Compare(BankClient client1, BankClient client2)
    {
        if (client1 == null && client2 == null) return 0;
        if (client1 != null && client2 == null) return -1;
        if (client1 == null && client2 != null) return 1;

        return client1.AllMeans().CompareTo(client2.AllMeans());

    }
}
