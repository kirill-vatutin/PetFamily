namespace PetFamily.Domain.Models
{
    public class Address
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public int HouseNumber { get; set; } 

        public string? HouseLetter { get; set; }
     }
    };

