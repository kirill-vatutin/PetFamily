namespace PetFamily.Domain.Models
{
    public record Address
    {
        public string Country { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string Street { get; init; } = string.Empty;
        public int HouseNumber { get; init; }
        public string? HouseLetter { get; init; }

    }
};

