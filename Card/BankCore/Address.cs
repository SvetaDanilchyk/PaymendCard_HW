namespace Card.BankCore;

internal class Address 
{
    private string _houseNumber;
    private string _flatNumber;
    private int _index;
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber 
    {
        get 
        { 
            return _houseNumber;
        }
        set 
        {
            if (value != "")
            {
                _houseNumber = value;
            }
            else
            {
                throw new ArgumentException("Empty string entered");
            }
        } 
    }
    public string FlatNumber 
    {
        get
        {
            return _flatNumber;
        }
        set
        {
            if (value == "" || value.Length > 6)
            {
                throw new ArgumentOutOfRangeException("Empty string entered");
            }

            _flatNumber = value;
        }
    }
    public int Index
    {
        get
        {
            return _index;
        }
        set 
        {
            if (value == 0 || value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _index = value;
        }
    }

    public Address(string country, string city, string street,  string houseNumber, string flatNumber, int index)
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
