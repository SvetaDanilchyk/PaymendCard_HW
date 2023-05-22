using Card.Comparers;
using Card.BankCore;
using Card.PaymentMeans;
using Card.PaymentMeans.PaymentCards;

namespace Card;

internal class Program
{
    static void Main(string[] args)
    {
        var client1 = new BankClient("ZPetrov Igor", new("BY", "Minsk", "Pobedy", "25", "25D", 600200));
        var client2 = new BankClient("Ivanova Irina", new("BY", "AMinsk", "Pobedy", "17d", "2A", 600200));
        var client3 = new BankClient("ASidorow Andrej", new("LT", "Wilnus", "Rotwera", "3", "1", 402369));

        try 
        {
            client1.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1000, 2.0F));
            client1.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 1400, 1.3F, 3000));                                                    //ZPetrov
            client1.AddPaymentMean(new DebetCard("168954", new(2025, 02, 07), 369, 25000, 7.0F));
            client1.AddPaymentMean(new Cash(12500));

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        try 
        {
            client2.AddPaymentMean(new CreditCard("345521", new(2026, 01, 14), 394, 7000, 8.7F, 4000));                                                    //Ivanova
            client2.AddPaymentMean(new DebetCard("177746", new(2027, 05, 11), 361, 500500, 7.0F));
            client2.AddPaymentMean(new Cash(10));
            client2.AddPaymentMean(new BitCoin(1000));
        }
        catch(Exception ex) 
        { 
            Console.WriteLine(ex.Message); 
        }
       

        try
        {
            client3.AddPaymentMean(new CashBackCard("236500", new(2026, 02, 10), 218, 30000, 150));                                                     // ASidorow
            client3.AddPaymentMean(new Cash(10000));
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
        

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
        var sortAddress = listClients.Select(x => x.Address.City).OrderBy(x => x).ToList();

        listClients.Sort(new AllMeansComparer());
        Console.WriteLine(listClients[^1]);                     // richest client



        foreach (var client in listClients)                     // get debet cards clients and allMeans
        {
            var listDebetForDebetCards = client.GetDebetCardsClient();
            listDebetForDebetCards.Where(x => x is DebetCard).ToList().ForEach(x => Console.WriteLine("Name:  " + client.Name + " " + x));

            Console.WriteLine("Name:  " + client.Name + " All means: " + client.GetAllMeans() + "\n");
        }

        listClients.ForEach(client => client.GetClientBitCoinDescending().
                    ForEach(x => Console.WriteLine("Name client: " + client.Name + " " + x)));

    }

}