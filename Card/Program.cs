using Card.Comparers;
using HW_Cards.BankCore;
using HW_Cards.PaymentCards;
using HW_Cards.PaymentMeans;

namespace HW_Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Address adress3 = new Address("BY", "Minsk", "Pobedy", 105, 36, 600200);
            Address adress2 = new Address("BY", "AMinsk", "Pobedy", 105, 36, 600200);
            Address adress1 = new Address("LT", "Wilnus", "Rotwera", 7, 14, 402369);

            BankClient client1 = new BankClient("ZPetrov Igor", adress1);
            BankClient client2 = new BankClient("Ivanova Irina", adress2);
            BankClient client3 = new BankClient("ASidorow Andrej", adress3);

            List<Address> AdressList = new List<Address> { adress1, adress2, adress3};

            DebetCard debetCard1 = new DebetCard("125698", new DateTime(2023, 05, 12), 120, 1000, 2.0F);
            DebetCard debetCard2 = new DebetCard("168954", new DateTime(2024, 02, 07), 369, 25000, 7.0F);
            DebetCard debetCard3 = new DebetCard("102146", new DateTime(2025, 07, 21), 111, 400, 3.0F);

            CashBackCard cashBackCard1 = new CashBackCard("265910", new DateTime(2027, 06, 11), 218, 1000, 200);
            CashBackCard cashBackCard2 = new CashBackCard("276400", new DateTime(2025, 08, 27), 218, 12500, 1000);
            CashBackCard cashBackCard3 = new CashBackCard("236500", new DateTime(2026, 02, 10), 218, 30000, 150);
            CashBackCard cashBackCard4 = new CashBackCard("236500", new DateTime(2026, 02, 10), 218, 500, 150);

            CreditCard creditCard1 = new CreditCard("302210", new DateTime(2024, 03, 11), 610, 1400, 1.3F, 3000);
            CreditCard creditCard2 = new CreditCard("345521", new DateTime(2026, 01, 14), 394, 7000, 8.7F, 4000);

            Cash cash1 = new Cash(12500);
            Cash cash2 = new Cash(10);
            Cash cash3 = new Cash(10000);


            client1.AddPaymentMean(debetCard1);         
            client1.AddPaymentMean(cashBackCard1);
            client1.AddPaymentMean(creditCard1);
            client1.AddPaymentMean(cash1);


            client2.AddPaymentMean(debetCard2);
            client2.AddPaymentMean(creditCard2);       
            client2.AddPaymentMean(cash2);

            client3.AddPaymentMean(debetCard3);         
            client3.AddPaymentMean(cashBackCard3);
            client3.AddPaymentMean(cash3);



            List<BankClient> listClients = new List<BankClient> { client1, client2, client3};
            float sum = 1000;

            for (int i = 0; i < 2; i++)
            {
                foreach (BankClient item in listClients)
                {
                    item.MakePaymentBanlClient(sum);
                    Console.WriteLine(item);
                }
                sum += 250;
            }

            debetCard1.TopUp(100);

            Console.WriteLine(debetCard1);

            listClients.Sort(new MaxAmounOnePaymend()); //

        }
    }
}