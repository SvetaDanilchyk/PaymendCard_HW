namespace Card.PaymentMeans;

internal class BitCoin : PaymentTool
{
    public BitCoin(float balance):base(balance) { }
    public override bool Pay(float amount)
    {
        if (_balance - amount > 0)
        {
            _balance -= amount;
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
        return string.Format("Bitcoin: {0} ", _balance);
    }
}
