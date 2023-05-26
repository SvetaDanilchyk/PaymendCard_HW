using Card.PaymentMeans;

namespace PaymentMeansTests.PaymentMeans;

[TestClass]
public class CashTests
{
    Cash cash = new Cash(1000);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CashCoinSumTestNegative()
    {
        _ = new Cash(-400);
    }

    [TestMethod]
    public void CheckTopUpForCashPositive()
    {
        Assert.IsTrue(cash.TopUp(8000));
    }

    [TestMethod]
    public void CheckTopUpForCashNegative()
    {
        Assert.IsFalse(cash.TopUp(-100));
    }

    [TestMethod]
    public void CashToStringMethodFormatTestPositive()
    {
        string expectedResult = "Cash balance: 1000 ";

        Assert.IsTrue(expectedResult == cash.ToString());
    }

    [TestMethod]
    public void CheckPaymentOperationForCashPositive()
    {
        Assert.IsTrue(cash.Pay(100));
    }

    [TestMethod]
    public void CheckPaymentOperationForCashNegative()
    {
        Assert.IsFalse(cash.Pay(1100));
    }

    [TestMethod]
    public void CashEqualsTestPositive()
    {
        var cash1 = new BitCoin(1000);

        Assert.AreEqual(cash, cash1);
    }

    [TestMethod]
    public void CashEqualsTestNegative()
    {
        var cash1 = new BitCoin(700);

        Assert.AreNotEqual(cash, cash1);
    }
}
