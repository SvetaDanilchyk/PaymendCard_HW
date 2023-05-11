namespace Card.PaymentMeans.PaymentCards;

internal class DebetCard : PaymentCards
{
    public float DepositPercent { get; set; }

    public DebetCard(string cardNumber, DateTime data, ushort cvvCard, float balance, float depositPercent) : base(cardNumber, data, cvvCard, balance)
    {
        DepositPercent = depositPercent;
    }
    public override bool Pay(float amount)
    {
        if (Balance > amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
    public override bool TopUp(float sum)
    {
        if (sum > 0)
        {
            Balance += sum;
            return true;
        }
        return false;
    }

    public override string ToString()
    {   
        return string.Format("DebetCard balanse: {0}  ", Balance);
    }

}
