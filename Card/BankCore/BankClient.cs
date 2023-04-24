using HW_Cards.PaymentCards;
using HW_Cards.PaymentMeans;
namespace HW_Cards.BankCore
{
    internal class BankClient :  IComparable<BankClient>
    {
        public string Name { get; set; }
       
        public Adress Adress { get; set; }

        public List<IPayment> PaymentMeans { get; protected set; }
        public BankClient(string name, Adress adress)
        {
            Name = name;
            Adress = adress;
            PaymentMeans = new List<IPayment>();
        }
        private bool SpecialPay (List<IPayment> list,float amount)
        {
            foreach(IPayment item in list)
            {
                if(item.Pay(amount)==true)
                {
                    return true;
                }
            }
            return false;
        }
        public bool toUp(List<IPayment> list,float amount)
        {
            foreach (IPayment item in PaymentMeans)
            {
                if (item.TopUp(amount) == true)
                {
                    return true;
                }
            }
            return false;
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

        public bool MakePaymentBanlClient(float amount)
        {
            if (SpecialPay(PaymentMeans.Where(x => x is Cash).ToList(), amount))
            {
                Console.WriteLine("GoodCash");
            }
            else if(SpecialPay(PaymentMeans.Where(x => x is DebetCard).ToList(), amount))
            {
                Console.WriteLine("GoodDebet");
            }
            else if (SpecialPay(PaymentMeans.Where(x => x is CreditCard).ToList(), amount))
            {
                Console.WriteLine("GoodCreditCard");
            } 
            else if (SpecialPay(PaymentMeans.Where(x => x is CashBackCard).ToList(), amount))
            {
                Console.WriteLine("GoodCashBackCard");
            }

            return false;
        }
      
        public int CompareTo(BankClient? obj)
        {
            return Name.CompareTo(obj?.Name);
        }
        public override string ToString()
        {
            String paymentMeans = "\n";
            foreach (IPayment item in PaymentMeans)
            {

                if(item is CreditCard)
                {
                    paymentMeans += item as CreditCard;
                } else if (item is DebetCard)
                {
                    paymentMeans += item as DebetCard;
                } else if (item is Cash)
                {
                    paymentMeans += item as Cash;
                } else if (item is CashBackCard)
                {
                    paymentMeans += item as CashBackCard;
                }
                

               paymentMeans += "\n";
            }
            return " Names: " +  Name  +  "  " + paymentMeans;
        }


    } 
}


       
    
