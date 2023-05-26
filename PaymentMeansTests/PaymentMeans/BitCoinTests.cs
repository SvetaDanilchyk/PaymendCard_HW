using Card.PaymentMeans;

namespace PaymentMeansTests.PaymentMeans;

[TestClass]
public class BitCoinTests
{
    BitCoin bitCoin = new BitCoin(800);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void BitCoinSumTestNegative()
    {
        _ = new BitCoin(-700);
    }

    [TestMethod]
    public void CheckTopUpForBitCoinPositive()
    {
        Assert.IsTrue(bitCoin.TopUp(1000));
    }

    [TestMethod]
    public void CheckTopUpForBitCoinNegative()
    {
        Assert.IsFalse(bitCoin.TopUp(-1000));
    }

    [TestMethod]
    public void BitCoinToStringMethodFormatTestPositive()
    {
        string expectedResult = "Bitcoin: 800 ";

        Assert.IsTrue(expectedResult == bitCoin.ToString());
    }

    [TestMethod]
    public void CheckPaymentOperationForBitCoinPositive()
    {
        Assert.IsTrue(bitCoin.Pay(200));
    }

    [TestMethod]
    public void CheckPaymentOperationForBitCoinNegative()
    {
        Assert.IsFalse(bitCoin.Pay(1500));
    }

    [TestMethod]
    public void BitCoinEqualsTestPositive()
    {
        var bitCoin1 = new BitCoin(800);

        Assert.AreEqual(bitCoin, bitCoin1);
    }

    [TestMethod]
    public void BitCoinEqualsTestNegative()
    {
        var bitCoin1 = new BitCoin(700);

        Assert.AreNotEqual(bitCoin, bitCoin1);
    }
}

