using Card.PaymentMeans;

namespace PaymentMeansTests.PaymentMeans;

[TestClass]
public class CashTests
{
    Cash cash = new Cash(1000);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void BitCoinSumTestNegative()
    {
        var cash = new Cash(-400);
    }

    [TestMethod]
    public void CheckTopUpForBitCoinPositive()
    {
        Assert.IsTrue(cash.TopUp(8000));
    }

    [TestMethod]
    public void CheckTopUpForBitCoinNegative()
    {
        Assert.IsFalse(cash.TopUp(-100));
    }

    [TestMethod]
    public void BitCoinToStringMethodFormatTestPositive()
    {
        string expectedResult = "Cash balance: 1000 ";

        Assert.IsTrue(expectedResult == cash.ToString());
    }

    [TestMethod]
    public void CheckPaymentOperationForBitCoinPositive()
    {
        Assert.IsTrue(cash.Pay(100));
    }

    [TestMethod]
    public void CheckPaymentOperationForBitCoinNegative()
    {
        Assert.IsFalse(cash.Pay(1100));
    }

    [TestMethod]
    public void BitCoinEqualsTestPositive()
    {
        var cash1 = new BitCoin(1000);

        Assert.AreEqual(cash, cash1);
    }

    [TestMethod]
    public void BitCoinEqualsTestNegative()
    {
        var cash1 = new BitCoin(700);

        Assert.AreNotEqual(cash, cash1);
    }
}
