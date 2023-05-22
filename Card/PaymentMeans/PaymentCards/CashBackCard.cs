namespace Card.PaymentMeans.PaymentCards;

public class CashBackCard : PaymentCards
{
    private float _balanceCasBack;
    public float CashBack { get; set; }
    public CashBackCard(string cardNumber, DateTime data, ushort cvvCard, float cashBack, float balance) : base(cardNumber, data, cvvCard, balance)
    {
        CashBack = cashBack;
        Balance = CashBack + Balance;
    }

    public override bool Pay(float amount)
    {
        if (Balance >= amount)
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
        return string.Format("Cash Back card available funds: {0} ", Balance);
    }



}
