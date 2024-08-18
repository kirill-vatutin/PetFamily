namespace PetFamily.Domain.Models
{
    public record PetPhoto
    {
        public string Path { get; init; } = string.Empty;
        public bool IsMain { get; init; } = false;

    }
}
