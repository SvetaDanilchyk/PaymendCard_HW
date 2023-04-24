

namespace HW_Cards
{
    internal interface IPayment
    {
        public bool Pay(float amount);
        public bool TopUp(float sum);
        
    }
}
