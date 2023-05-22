using Card.PaymentMeans.PaymentCards;

namespace PaymentMeansTests.PaymentMeans.PaymentCards;

[TestClass]
public class CreditCardTests
{
    CreditCard creditCard = new ("308259", new(2025, 04, 30), 919, 2400, 1.3F, 3000);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCVVCardEequalToZeroForCreditCardNegative()
    {
        CreditCard creditCard = new("308259", new(2025, 04, 30), 0, 2400, 1.3F, 3000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCVVCardOverFourCharactersForCreditCardNegative()
    {
        CreditCard creditCard = new("308259", new(2025, 04, 30), 9109, 2400, 1.3F, 3000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCardNumberForCreditCardNegative()
    {
        CreditCard creditCard = new("308545259", new(2025, 04, 30), 919, 2400, 1.3F, 3000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckExpirityDateForCreditCardNegative()
    {
        CreditCard card = new("308259", new(2022, 04, 30), 919, 2400, 1.3F, 3000);
    }

    [TestMethod]
    public void CheckPaymentOperationForCreditCardPositive()
    {
        Assert.IsTrue(creditCard.Pay(1500));
    }

    [TestMethod]
    public void CheckPaymentOperationForCreditCardWithLimitPositive()
    {
        Assert.IsTrue(creditCard.Pay(5400));
    }

    [TestMethod]
    public void CheckPaymentOperationForCreditCardNegative()
    {
        Assert.IsFalse(creditCard.Pay(6000));
    }

    [TestMethod]
    public void CheckToUpOperationForCreditCardPositive()
    {
        Assert.IsTrue(creditCard.TopUp(1000));
    }

    [TestMethod]
    public void CheckToUpOperationForCreditCardNegative()
    {
        Assert.IsFalse(creditCard.TopUp(-1000));
    }

    [TestMethod]
    public void CreditCardToStringMethodFormatTestPositive()
    {
        string expectedResult = "Credit Card available funds : 2400 ";

        Assert.IsTrue(expectedResult == creditCard.ToString());
    }

}
