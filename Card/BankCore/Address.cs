

namespace HW_Cards.BankCore
{
    internal class Address 
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }
        public int Index { get; set; }

        public Address(string country, string city, string street, int houseNumber, int flatNumber, int index)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
            Index = index;
        }

        public override string ToString()
        {
            return String.Format("country: {0}, city: {1},street: {2},HouseNumber: {3},flatNumber: {4},index: {5}", Country, City, Street, HouseNumber, FlatNumber, Index);
        }

    }
}
