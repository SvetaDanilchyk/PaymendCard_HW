using Card.PaymentMeans.PaymentCards;

namespace PaymentMeansTests.PaymentMeans.PaymentCards;
[TestClass]
public class CashBackCardTest
{
    CashBackCard cashBackCard = new ("268128", new(2029, 06, 21), 895, 500, 5000);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCVVCardEequalToZeroForCashBackCardNegative()
    {
        CashBackCard cashBackCard = new("268128", new(2029, 06, 21), 0, 500, 5000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCVVCardOverFourCharactersForCashBackCardNegative()
    {
        CashBackCard cashBackCard = new("268128", new(2029, 06, 21), 8258, 500, 5000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckCardNumberForCashBackCardNegative()
    {
        CashBackCard cashBackCard = new("28", new(2029, 06, 21), 858, 500, 5000);
    }

    [TestMethod]
    public void CheckPaymentOperationForCashBackCardPositive()
    {
        Assert.IsTrue(cashBackCard.Pay(4000));
    }

    [TestMethod]
    public void CheckPaymentOperationForCashBackCardWithCashBackPositive()
    {
        Assert.IsTrue(cashBackCard.Pay(5500));
    }

    [TestMethod]
    public void CheckPaymentOperationForCashBackCardNegative()
    {
        Assert.IsFalse(cashBackCard.Pay(5600));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CheckExpirityDateForCreditCardNegative()
    {
        CashBackCard cashBackCard = new("268128", new(2022, 06, 21), 858, 5000, 2000);
    }

    [TestMethod]
    public void CheckToUpOperationForCreditCardPositive()
    {
        Assert.IsTrue(cashBackCard.TopUp(1000));
    }

    [TestMethod]
    public void CheckToUpOperationForCreditCardNegative()
    {
        Assert.IsFalse(cashBackCard.TopUp(-1000));
    }

    [TestMethod]
    public void CreditCardToStringMethodFormatTestPositive()
    {
        string expectedResult = "Cash Back card available funds: 5500 ";

        Assert.IsTrue(expectedResult == cashBackCard.ToString());
    }
}

