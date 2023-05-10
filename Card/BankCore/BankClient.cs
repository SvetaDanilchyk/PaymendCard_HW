using Card.PaymentMeans;
using Card.PaymentMeans.PaymentCards;

namespace Card.BankCore;

internal class BankClient 
{
    private string _name;
    public Address Adress { get; set; }
    public List<IPayment> PaymentMeans { get;}
    public string Name 
    {
        get
        { 
            return _name;
        }
        set
        {
            if (value == "")
            {
                throw new ArgumentException("Empty string");
            }
            else if (value.Length > 50)
            {
                throw new ArgumentException("Input name is long");
            }
            _name = value;
        }
    }

    public BankClient(string name, Address adress)
    {
        Name = name;
        Adress = adress;
        PaymentMeans = new List<IPayment>();
    }

    public bool AddPaymentMean(IPayment mean)
    { 
        if (mean != null)
        {
            PaymentMeans.Add(mean);
            return true;
        }
        return false;
            
    }
    public bool MakePaymentBankClient(float amount)
    {
        if (SpecialPay(PaymentMeans.Where(x => x is Cash).ToList(), amount))
        {
            return true;
        }
        else if(SpecialPay(PaymentMeans.Where(x => x is DebetCard).ToList(), amount))
        {
            return true;
        }
        else if (SpecialPay(PaymentMeans.Where(x => x is CreditCard).ToList(), amount))
        {
            return true;
        } 
        else if (SpecialPay(PaymentMeans.Where(x => x is CashBackCard).ToList(), amount))
        {
            return true;
        }
        else if (SpecialPay(PaymentMeans.Where(x => x is BitCoin).ToList(), amount))
        {
            return true;
        }

        return false;
    }

    public IEnumerable<DebetCard> GetDebetCardsClient()
    {
        var listDebetCardsClient = PaymentMeans.OfType<DebetCard>().ToList();
        return listDebetCardsClient;
    }

    public double GetAllMeans()
    {
       return  PaymentMeans.OfType<PaymentTool>().Select(x => x.Balance).Sum();
    }
    public List<PaymentTool> GetClinetBitCoinDescending()
    {
        List<PaymentTool> sortListDescending = new();
        foreach (var card in PaymentMeans)
        {
            if (card is BitCoin)
            {
               sortListDescending = PaymentMeans.OfType<PaymentTool>().OrderByDescending(x => x.Balance).ToList();                
            }
        }

        return sortListDescending;
    }

    public override string ToString()
    {
        String paymentMeans = "\n";
        PaymentMeans.OfType<PaymentTool>().Select(x => (paymentMeans += x.ToString() + "\n")).ToList();

        return paymentMeans;
    }

    private bool SpecialPay(List<IPayment> list, float amount)
    {
        foreach (IPayment item in list)
        {
            if (item.Pay(amount) == true)
            {
                return true;
            }
        }
        return false;
    }
}




