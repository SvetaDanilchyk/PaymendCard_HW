namespace Card.PaymentMeans;

public abstract class PaymentTool : IPayment
{
    //protected float _balance;
    public float Balance; // public virtual float Balance;
    //{ 
    //    get => _balance;
    //    set
    //    {
    //        if (value < 0)
    //        {
    //            throw new ArgumentOutOfRangeException(nameof(value));
    //        }

    //        _balance = value;
    //    }
    //}
    public PaymentTool(float balance) 
    {
        if (balance < 0)
        {
            throw new ArgumentOutOfRangeException("Wrong balance");
        }

        Balance = balance;
    }
    public abstract bool Pay(float amount);
    public abstract bool TopUp(float sum);
}
