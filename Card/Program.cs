using Card.Comparers;
using Card.BankCore;
using Card.PaymentMeans;
using Card.PaymentMeans.PaymentCards;

namespace Card;

internal class Program
{
    static void Main(string[] args)
    {
        var client1 = new BankClient("ZPetrov Igor", new ("BY", "Minsk", "Pobedy", "25", "25D", 600200));
        var client2 = new BankClient("Ivanova Irina", new ("BY", "AMinsk", "Pobedy", "17d", "2A", 600200));
        var client3 = new BankClient("ASidorow Andrej", new ("LT", "Wilnus", "Rotwera", "3", "1", 402369));

        var debetCard1 = new DebetCard("125698", new (2023, 05, 12), 110, 1000, 2.0F);
        var debetCard2 = new DebetCard("168954", new (2024, 02, 07), 369, 25000, 7.0F);
        var debetCard3 = new DebetCard("102146", new (2025, 07, 21), 111, 400, 3.0F);
        var debetCard4 = new DebetCard("177746", new (2027, 05, 11), 361, 500500, 7.0F);

        var cashBackCard1 = new CashBackCard("265910", new (2027, 06, 11), 218, 1000, 200);
        var cashBackCard2 = new CashBackCard("276400", new (2025, 08, 27), 218, 12500, 1000);
        var cashBackCard3 = new CashBackCard("236500", new (2026, 02, 10), 218, 30000, 150);
        var cashBackCard4 = new CashBackCard("236500", new (2026, 02, 10), 218, 500, 150);

        var creditCard1 = new CreditCard("302210", new (2024, 03, 11), 610, 1400, 1.3F, 3000);
        var creditCard2 = new CreditCard("345521", new (2026, 01, 14), 394, 7000, 8.7F, 4000);

        var cash1 = new Cash(12500);
        var cash2 = new Cash(10);
        var cash3 = new Cash(10000);

        var bitCoin1 = new BitCoin(2500);
        var bitCoin2 = new BitCoin(1000);
        var bitCoin3 = new BitCoin(70231);
        
        client1.AddPaymentMean(cashBackCard1);
        client1.AddPaymentMean(creditCard1);                     //ZPetrov
        client1.AddPaymentMean(debetCard1);
        client1.AddPaymentMean(debetCard4);
        client1.AddPaymentMean(cash1);

        client2.AddPaymentMean(creditCard2);
        client2.AddPaymentMean(debetCard2);
        client2.AddPaymentMean(cash2);
       // client2.AddPaymentMean(bitCoin2);        

        client3.AddPaymentMean(debetCard3);                      // ASidorow
        client3.AddPaymentMean(cashBackCard3);
        client3.AddPaymentMean(cash3);
        client3.AddPaymentMean(bitCoin3);

        List<BankClient> listClients = new List<BankClient> { client1, client2, client3};

        float sum = 1000;
        for (int i = 0; i < 2; i++)
        {
            foreach (BankClient item in listClients)
            {
                item.MakePaymentBankClient(sum);
                Console.WriteLine(item);
            }
            sum += 250;
         }

        var sortListCliets = listClients.Select(x => x.Name).OrderBy(x => x).ToList();
        var sortAddress = listClients.Select(x => x.Adress.City).OrderBy(x => x).ToList();

        listClients.Sort(new AllMeansComparer());
        Console.WriteLine(listClients[^1]);                     // richest client

        foreach (var client in listClients)                     // get debet cards clients and allMeans
        {
            var listDebetForDebetCards = client.GetDebetCardsClient();
            listDebetForDebetCards.Where(x => x is DebetCard).ToList().ForEach(x => Console.WriteLine("Name:  " + client.Name +" "+ x));

            Console.WriteLine("Name:  " + client.Name + " All means: " + client.GetAllMeans() + "\n");
        }

        listClients.ForEach(client => client.GetClinetBitCoinDescending().
                    ForEach(x => Console.WriteLine("Name client: " + client.Name + " " + x)));
    }

}