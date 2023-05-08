using Card.Comparers;
using HW_Cards.PaymentCards;
using HW_Cards.PaymentMeans;
using System.Linq;
using HW_Cards;
using Card.BankCore;
using System.Transactions;

namespace Card.BankCore
{
    internal class BankClient 
    {
        public string Name { get; set; }
       
        public Address Adress { get; set; }

        public List<IPayment> PaymentMeans { get;  set; }
        public BankClient(string name, Address adress)
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
        { /// 
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
            else if (SpecialPay(PaymentMeans.Where(x => x is BitCoin).ToList(), amount))
            {
                Console.WriteLine("GoodBitcoin");
            }

            return false;
        }

        public void GetDebetCardsClient()
        {
                PaymentMeans.Where(x => x is DebetCard).Select(x => x as DebetCard).ToList().ForEach(x => Console.WriteLine(Name + " " + x));
        }

        public void GetAllMeans()
        {
           double sumAll =  PaymentMeans.Where(x => x is PaymentCards).Select(x => x as PaymentCards).Select(x => x.Balance).Sum() + 
                            PaymentMeans.Where(x => x is Cash).Select(x => x as Cash).Select(x => x.Balance).Sum() +
                            PaymentMeans.Where(x => x is BitCoin).Select(x => x as BitCoin).Select(x => x.Balance).Sum();
            Console.WriteLine(Name + " Means = " + sumAll + "\n");
        }

        public void GetClinetBitCoinDescending()
        {
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
                } else if (item is BitCoin)
                {
                    paymentMeans += item as BitCoin;
                }


                paymentMeans += "\n";
            }
            return " Names: " +  Name  +  "  " + paymentMeans;
        }

    } 
}


       
    
