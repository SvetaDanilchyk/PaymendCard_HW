namespace Card.PaymentMeans.PaymentCards;

internal class CashBackCard : PaymentCards
{
    private float _balanceCasBack;
    public float CashBack { get; set; }
    public CashBackCard(string cardNumber, DateTime data, ushort cvvCard, float cashBack, float balance) : base(cardNumber, data, cvvCard, balance)
    {
        CashBack = cashBack;
        _balanceCasBack = _balance + CashBack;
    }

    public override bool Pay(float amount)
    {
        if (_balanceCasBack > amount)
        {
            _balanceCasBack -= amount;
            return true;
        }
        return false;
    }
    public override bool TopUp(float sum)
    {
        if (sum > 0)
        {
            _balance += sum;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return string.Format("Cash Back card available funds: {0} ", _balanceCasBack);
    }



}
