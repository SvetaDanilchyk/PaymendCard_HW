using Card.PaymentMeans.PaymentCards;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentMeansTests.PaymentMeans.PaymentCards
{
    [TestClass]
    public class PaymentCardsTests
    {
        DebetCard debetCard1 = new DebetCard("125698", new(2025, 05, 12), 100, 1000, 2.0F);

        [TestMethod]
        public void CheckMethodEqualsFroForPaymentCardsPositive()
        {
            DebetCard debetCard2 = new DebetCard("125698", new(2025, 05, 12), 100, 1000, 2.0F);

            Assert.AreEqual(debetCard1, debetCard2);
        }

        [TestMethod]
        public void CheckMethodEqualsByNumberCardFroForPaymentCardsNegative()
        {
            CreditCard debetCard2 = new CreditCard("125690", new(2025, 05, 12), 100, 1000, 2.0F, 1000);

            Assert.AreEqual(debetCard1, debetCard2);
        }



    }
}
