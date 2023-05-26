using System.Runtime.Loader;

namespace Card.BankCore;

public class Address 
{
    private string _country;
    private string _city;
    private string _street;
    private string _houseNumber;
    private string _flatNumber;
    private int _index;

    public string Country
    {
        get
        {
            return _country;
        }
        set
        {
            if (value == "")
            {
                throw new ArgumentOutOfRangeException("Country field is empty");
            }
            _country = value;
        }
    }

    public string City 
    {
        get
        {
            return _city;
        }
        set
        {
            if (value == "")
            {
                throw new ArgumentOutOfRangeException("City field is empty");
            }
            _city = value;
        }
    }

    public string Street 
    {
        get
        {
            return _street;
        }
        set
        {
            if( value == "")
            {
                throw new ArgumentOutOfRangeException("Street field is empty");
            }
            _street = value;
        }
    }

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
                throw new ArgumentOutOfRangeException("Empty string entered");
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
                throw new ArgumentOutOfRangeException("Empty string entered");
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
        return String.Format("Country: {0}, Сity: {1}, Street: {2}, HouseNumber: {3}, FlatNumber: {4}, Index: {5}", Country, City, Street, HouseNumber, FlatNumber, Index);
    }

    public override bool Equals(object obj)
    {
        if (obj is Address address)
        {
            return Country == address.Country &&
                   City == address.City &&
                   Street == address.Street &&
                   HouseNumber == address.HouseNumber &&
                   FlatNumber == address.FlatNumber &&
                   Index == address.Index;
            
        }
        return false;
    }

}
