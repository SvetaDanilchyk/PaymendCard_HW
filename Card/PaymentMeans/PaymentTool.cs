namespace Card.PaymentMeans;

internal abstract class PaymentTool : IPayment
{
    protected float _balance;
    public virtual float Balance { get => _balance; }
    public PaymentTool(float balance) 
    {
        if (balance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(balance));
        }
        _balance = balance;
    }
    public abstract bool Pay(float amount);
    public abstract bool TopUp(float sum);
}
