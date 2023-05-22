using Card.BankCore;
using Card.PaymentMeans.PaymentCards;

namespace PaymentMeansTests.PaymentMeans.PaymentCards;

[TestClass]
public class DebetCardTests
{
    DebetCard debetCard = new ("178346", new(2026, 09, 11), 181, 1000, 3.0F);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCVVCardEequalToZeroForDebetCardPositive()
    {
        DebetCard debetCard1 = new DebetCard("125698", new(2025, 05, 12), 0, 1000, 2.0F);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCVVCardOverFourCharactersForDebetCardNegative()
    {
        DebetCard debetCard1 = new DebetCard("125698", new(2025, 05, 12), 1250, 1000, 2.0F);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCardNumberForDebetCardNegative()
    {
        DebetCard debetCard1 = new DebetCard("1111", new(2025, 05, 12), 150, 1000, 2.0F);
    }

    [TestMethod]
    public void CheckPaymentOperationForDebitCardPositive()
    {
        Assert.IsTrue(debetCard.Pay(800));
    }

    [TestMethod]
    public void CheckPaymentOperationForDebitCardNegative()
    {
        Assert.IsFalse(debetCard.Pay(1500));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckExpirityDateForDebitCardNegative()
    {
        DebetCard card = new ("178346", new(2022, 09, 11), 181, 1000, 3.0F);
    }

    [TestMethod]
    public void CheckToUpOperationForDebetCardPositive()
    {
        Assert.IsTrue(debetCard.TopUp(500));
    }

    [TestMethod]
    public void CheckToUpOperationForDebetCardNegative()
    {
        Assert.IsFalse(debetCard.TopUp(-500));
    }

    [TestMethod]
    public void DebetCardsToStringMethodFormatTestPositive()
    {
        string expectedResult = "DebetCard balanse: 1000 ";

        Assert.IsTrue(expectedResult == debetCard.ToString());
    }
}
