using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System.Runtime.CompilerServices;

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

        public static Result<ShortString, Error> Create(
            string value,
            [CallerArgumentExpression(nameof(value))] string? variableName = null)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                return Errors.General.ValueIsInvalid(variableName);
            }

            return new ShortString(value);
        }

        public static implicit operator string(ShortString shortString) => shortString.Value;

        public static implicit operator ShortString(string s) => new(s);
    }
}
