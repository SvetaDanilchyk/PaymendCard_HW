namespace Card.PaymentMeans.PaymentCards;

public abstract class PaymentCards : PaymentTool
{
    private DateTime _date;
    private ushort _cvv;
    private string _cardNumber;

    public string CardNumber 
    {
        get
        {
            return _cardNumber;
        }
        private set
        {
            if (value.Length > 6 || value.Length <= 5)
            {
                throw new ArgumentOutOfRangeException("Wrong number length!");
            }

            _cardNumber = value;
        }
    }

    public ushort CVV 
    {
        get 
        {
            return _cvv;
        }
        private set
        {
            if (value > 1000)
            {
                throw new ArgumentOutOfRangeException("CVV must be no more than three characters ");
            }
            else if (value == 0)
            {
                throw new ArgumentOutOfRangeException("CVV not entered");
            }        
               _cvv = value;
            
        }
    }

    public DateTime ExpirityData
    {
        get
        {
            return _date;
        }
        private set
        {
            if (value > DateTime.Now)
            {
                _date = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
    }

    public PaymentCards(string cardNumber, DateTime data, ushort cvv, float balance):base( balance)
    {
        CardNumber = cardNumber;
        ExpirityData = data;
        CVV = cvv;
    }

    public override bool Equals(object obj)
    {
        if (obj is PaymentCards other) 
        {
            CardNumber.Equals(other.CardNumber); 
            
            return true;

        }

        return false;
    }
    public override abstract bool Pay(float amount);

    public override abstract bool TopUp(float sum);

}
