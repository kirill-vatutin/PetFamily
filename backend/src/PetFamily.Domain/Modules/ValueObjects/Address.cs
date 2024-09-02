using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models
{
    public record Address
    {
        public string Country { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string Street { get; init; } = string.Empty;
        public int HouseNumber { get; init; }
        public string? HouseLetter { get; init; }

        private Address(string country,
                        string city,
                        string street,
                        int houseNumber,
                        string? houseLetter)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            HouseLetter = houseLetter;
        }

        public static Result<Address> Create(string country,
                                             string city,
                                             string street,
                                             int houseNumber,
                                             string? houseLetter)
        {
            if (string.IsNullOrEmpty(country))
            {
                return Result.Failure<Address>("Country can not be empty");
            }
            if (string.IsNullOrEmpty(city))
            {
                return Result.Failure<Address>("City can not be empty");
            }
            if (string.IsNullOrEmpty(street))
            {
                return Result.Failure<Address>("Street can not be empty");
            }

            var address = new Address(country, city, street, houseNumber, houseLetter);
            return address;
        }
    }
};

