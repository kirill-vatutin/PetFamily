namespace PetFamily.Domain.Models
{
    public record SocialNetwork
    {
        public string Name { get; init;} = string.Empty;
        public string Link { get; init; } = string.Empty;

    }
}
