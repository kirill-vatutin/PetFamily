using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules.ValueObjects
{
    public record SocialNetwork
    {
        public string Name { get; init; } = string.Empty;
        public string Link { get; init; } = string.Empty;

        private SocialNetwork(string name, string link)
        {
            Name = name;
            Link = link;
        }

        public static Result<SocialNetwork> Create(string name, string link)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<SocialNetwork>("Name can not be empty");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<SocialNetwork>("Name can not be empty");
            }

            return new SocialNetwork(name, link);
        }
    }
}
