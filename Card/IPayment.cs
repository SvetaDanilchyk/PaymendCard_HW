namespace Card;

public interface IPayment
{
    public bool Pay(float amount);

    public bool TopUp(float sum);
    
}
