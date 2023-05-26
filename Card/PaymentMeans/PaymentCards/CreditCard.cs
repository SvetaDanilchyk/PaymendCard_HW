namespace Card.PaymentMeans.PaymentCards;

public class CreditCard : PaymentCards
{
    public float CreditPercent { get; set; }
    public float Limit { get; set; }

    public CreditCard(string cardNumber, DateTime data, ushort cvvCard, float balance, float creditPercent, float limit) : base(cardNumber, data, cvvCard, balance)
    {
        CreditPercent = creditPercent;
        Limit = limit;
    }

    public override bool Pay(float amount)
    {
        if (amount <=  Balance)
        {
            Balance -= amount;  
            return true;
        }

        if (amount <= Balance + Limit)
        {
            Balance = 0;
            Limit = Limit - (amount - Balance);
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
        return string.Format("Credit Card available funds : {0} ", Balance);
    }
}
