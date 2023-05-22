using Card.BankCore;

namespace PaymentMeansTests.BankCore;

[TestClass]
public class AddressForBankClientTests
{
    Address address1 = new Address("BY", "Minsk", "Pobedy", "25", "25D", 600200);

    [TestMethod]
    [DataRow("", "Minsk", "Pobedy", "25", "15D", 600200)]
    [DataRow("By", "", "Pobedy", "25", "15D", 600200)]
    [DataRow("By", "Minsk", "", "25", "15D", 600200)]
    [DataRow("By", "Minsk", "Pobedy", "", "15D", 600200)]
    [DataRow("By", "Minsk", "Pobedy", "25", "", 600200)]
    [DataRow("By", "Minsk", "Pobedy", "25", "15D", 0)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AddressFieldIsEmptyNegative(string country, string city, string street, string houseNumber, string flatNumber, int index)
    {
        var address2 = new Address(country, city, street, houseNumber, flatNumber, index);
    }

    [TestMethod]
    public void AddressToStringMethodFormatTestPositive()
    {
        string expectedResult = "Country: BY, Сity: Minsk, Street: Pobedy, HouseNumber: 25, FlatNumber: 25D, Index: 600200";

        Assert.IsTrue(expectedResult == address1.ToString());
    }

    [TestMethod]
    public void AddressEqualsTestPositive()
    {
        var address2 = new Address("BY", "Minsk", "Pobedy", "25", "25D", 600200);

        Assert.AreEqual(address1, address2);
    }

    [TestMethod]
    [DataRow("By", "Minsk", "Pobedy", "25", "15D", 600200)]
    [DataRow("BY", "Minsk1", "Pobedy", "25", "15D", 600200)]
    [DataRow("BY", "Minsk", "Pobedy ", "25", "15D", 600200)]
    [DataRow("BY", "Minsk", "Pobedy", "5", "15D", 600200)]
    [DataRow("BY", "Minsk", "Pobedy", "25", "15", 600200)]
    [DataRow("BY", "Minsk", "Pobedy", "25", "15D", 600100)]
    public void AddressEqualsTestNegative(string country, string city, string street, string houseNumber, string flatNumber, int index)
    {
        var address2 = new Address(country, city, street, houseNumber, flatNumber, index);

        Assert.AreNotEqual(address1, address2);
    }
}