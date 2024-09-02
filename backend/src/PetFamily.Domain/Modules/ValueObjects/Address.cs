using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models
{
    public record Address
    {
        public string Country { get; } = string.Empty;
        public string City { get; } = string.Empty;
        public string Street { get; } = string.Empty;
        public int HouseNumber { get; }
        public string? HouseLetter { get; }

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

        public static Result<Address,Error> Create(string country,
                                             string city,
                                             string street,
                                             int houseNumber,
                                             string? houseLetter)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return Errors.General.ValueIsInvalid("Country");
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                return Errors.General.ValueIsInvalid("City");
            }
            if (string.IsNullOrWhiteSpace(street))
            {
                return Errors.General.ValueIsInvalid("Street");
            }

            var address = new Address(country, city, street, houseNumber, houseLetter);
            return address;
        }
    }
};

