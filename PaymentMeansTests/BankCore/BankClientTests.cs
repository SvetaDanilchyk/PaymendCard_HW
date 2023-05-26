using Card.BankCore;
using Card.PaymentMeans;
using Card.PaymentMeans.PaymentCards;

namespace PaymentMeansTests.BankCore
{
    [TestClass]
    public class BankClientTests
    {
        
        BankClient client1 = new BankClient("Petrov Igor", new("BY", "Minsk", "Pobedy", "25", "25D", 600200));
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NameIsEmptyForBankClientNegative()
        {
            var client = new BankClient("", new("BY", "Minsk", "Pobedy", "25", "25D", 600200));

            Assert.IsTrue(client.Name == "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NameOverFiftyCharactersForBankClientNegative()
        {
            var client = new BankClient("Petrov Igor Petrov IgorPetrov IgorPetrov IgorPetrov Igor", new("BY", "Minsk", "Pobedy", "25", "25D", 600200));

            Assert.IsTrue(client.Name.Length > 50);
        }

        [TestMethod]
        public void AddDebetCardForBankClientPositive()
        {
            Assert.IsTrue(client1.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1100, 2.0F)));
        }

        [TestMethod]
        public void AddCreditCardForBankClientPositive()
        {
            Assert.IsTrue(client1.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 3200, 1.3F, 100)));
        }

        [TestMethod]
        public void AddBitCoinForBankClientPositive()
        {
            Assert.IsTrue( client1.AddPaymentMean(new BitCoin(7000)));
        }
        [TestMethod]
        public void AddCashForBankClientPositive()
        {
            Assert.IsTrue(client1.AddPaymentMean(new Cash(200)));
        }
        [TestMethod]
        public void AddCashBackCardForBankClientPositive()
        {
            Assert.IsTrue(client1.AddPaymentMean(new CashBackCard("232761", new(2025, 04, 21), 782, 100, 5000)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddEmptyCardForBankClientNegative()
        {
            client1.AddPaymentMean(null);
        }

        [TestMethod]
        public void BankClientToStringMethodFormatTestPositive()
        {
            client1.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1000, 2.0F));
            client1.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 1400, 1.3F, 3000));
            client1.AddPaymentMean(new CashBackCard("232761", new(2025, 04, 21), 782, 100, 5000));
            client1.AddPaymentMean(new BitCoin(200));
            client1.AddPaymentMean(new Cash(12500));

            string expectedResult = "\nDebetCard balanse: 1000 \n" +
                                    "Credit Card available funds : 1400 \n" +
                                    "Cash Back card available funds: 5100 \n" + 
                                    "Bitcoin: 200 \n" +
                                    "Cash balance: 12500 \n";

            Assert.AreEqual(expectedResult, client1.ToString());
        }

        [TestMethod]
        public void BankClientEqualsTestPositive()
        {
            BankClient client2 = new BankClient("Petrov Igor", new("BY", "Minsk", "Pobedy", "25", "25D", 600200));

            client1.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1000, 2.0F));
            client1.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 1400, 1.3F, 3000));
            client1.AddPaymentMean(new CashBackCard("232761", new(2025, 04, 21), 782, 100, 5000)); 
            client1.AddPaymentMean(new BitCoin(200));
            client1.AddPaymentMean(new Cash(12500));

            client2.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1000, 2.0F));
            client2.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 1400, 1.3F, 3000));
            client2.AddPaymentMean(new CashBackCard("232761", new(2025, 04, 21), 782, 100, 5000));
            client2.AddPaymentMean(new BitCoin(200));
            client2.AddPaymentMean(new Cash(12500));

            Assert.AreEqual(client1, client2);
        }
        
        [TestMethod]
        public void BankClientByNameForEqualsTestNegative()
        {
            BankClient client2 = new BankClient("PetrovIgor", new("BY", "Minsk", "Pobedy", "25", "25D", 600200));

            Assert.AreNotEqual(client1, client2);
        }


        [TestMethod]
        [DataRow(100)]
        [DataRow(1100)]
        [DataRow(3250)]
        [DataRow(5050)]
        [DataRow(7000)]
        public void BankClientForSpecialPayPositive(float sum)
        {
            client1.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1100, 2.0F));
            client1.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 3200, 1.3F, 100));
            client1.AddPaymentMean(new CashBackCard("232761", new(2025, 04, 21), 782, 100, 5000)); 
            client1.AddPaymentMean(new BitCoin(7000));
            client1.AddPaymentMean(new Cash(200));

            Assert.IsTrue(client1.MakePaymentBankClient(sum));

        }

        [TestMethod]
        public void BankClientForSpecialPayNegative()
        {
            client1.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1100, 2.0F));
            client1.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 3200, 1.3F, 100));
            client1.AddPaymentMean(new CashBackCard("232761", new(2025, 04, 21), 782, 100, 5000));
            client1.AddPaymentMean(new BitCoin(7000));
            client1.AddPaymentMean(new Cash(200));

            Assert.IsFalse(client1.MakePaymentBankClient(8000));

        }

        [TestMethod]
        public void BankClientForGetAllMeansTestPositive()
        {
            client1.AddPaymentMean(new DebetCard("125698", new(2025, 05, 12), 110, 1000, 2.0F));
            client1.AddPaymentMean(new CreditCard("302210", new(2024, 03, 11), 610, 1400, 1.3F, 3000));
            client1.AddPaymentMean(new CashBackCard("232761", new(2025, 04, 21), 782, 100, 5000));
            client1.AddPaymentMean(new BitCoin(200));
            client1.AddPaymentMean(new Cash(12500));

            Assert.AreEqual(20200, client1.AllMeans());
        }

    }

}
