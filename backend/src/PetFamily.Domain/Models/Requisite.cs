namespace PetFamily.Domain.Models
{
    public record Requisite
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
};

