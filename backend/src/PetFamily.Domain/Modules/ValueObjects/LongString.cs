using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules.ValueObjects
{
    public record LongString
    {
        public const int MAX_LENGTH = 2000;

        public string Value { get; } = null!;

        private LongString(string value)
        {
            Value = value;
        }

        public static Result<LongString,string> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length> MAX_LENGTH)
            {
                return "Invalid value of description";
            }

            return new LongString(value);
        }

        public static implicit operator string(LongString longString) => longString.Value;

        public static implicit operator LongString(string s) => new LongString(s);
    }
}
