namespace PetFamily.Domain.Models
{
    public record FullName
    {
        public string Firstname { get;init; } = string.Empty;
        public string SecondName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
    }
}
