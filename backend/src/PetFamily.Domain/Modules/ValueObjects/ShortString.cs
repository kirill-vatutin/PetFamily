using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules.ValueObjects
{
    public record ShortString
    {
        public const int MAX_LENGTH = 100;

        public string Value { get; } = null!;

        private ShortString(string value)
        {
            Value = value;
        }

        public static Result<ShortString, string> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                return "Invalid value of title";
            }

            return new ShortString(value);
        }

        public static implicit operator string(ShortString shortString) => shortString.Value;

        public static implicit operator ShortString(string s) => new ShortString(s);
    }
}
