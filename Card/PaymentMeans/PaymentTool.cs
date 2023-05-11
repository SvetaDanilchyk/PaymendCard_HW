namespace Card.PaymentMeans;

internal abstract class PaymentTool : IPayment
{
    protected float _balance;
    public virtual float Balance
    { 
        get => _balance;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _balance = value;
        }
    }
    public PaymentTool(float balance) 
    {

        Balance = balance;
    }
    public abstract bool Pay(float amount);
    public abstract bool TopUp(float sum);
}
