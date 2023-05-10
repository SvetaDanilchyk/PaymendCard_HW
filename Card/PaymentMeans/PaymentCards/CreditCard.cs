namespace Card.PaymentMeans.PaymentCards;

internal class CreditCard : PaymentCards
{
    private float BalanceLimit;
    public float CreditPercent { get; set; }
    public float Limit { get; set; }

    public CreditCard(string cardNumber, DateTime data, ushort cvvCard, float balance, float creditPercent, float limit) : base(cardNumber, data, cvvCard, balance)
    {
        CreditPercent = creditPercent;
        Limit = limit;
        BalanceLimit = Limit + _balance;
    }
    public override bool Pay(float amount)
    {
        BalanceLimit = Balance + Limit;

        if (BalanceLimit > amount)
        {
            BalanceLimit -= amount;
            return true;
        }
        return false;
    }

    public override bool TopUp(float sum)
    {
        if (sum > 0)
        {
            _balance += sum;
            return false;
        }
        return true;
    }
    public override string ToString()
    {
        return string.Format("Credit Card available funds : {0} ", BalanceLimit);
    }
}
