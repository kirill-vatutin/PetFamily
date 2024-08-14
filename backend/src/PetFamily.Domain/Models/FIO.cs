namespace PetFamily.Domain.Models
{
    public record FIO
    {
        public string Firstname { get;init; } = string.Empty;
        public string SecondName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
    }
}
