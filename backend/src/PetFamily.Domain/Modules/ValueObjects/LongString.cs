using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System.Runtime.CompilerServices;

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

        public static Result<LongString, Error> Create(
            string value,
            [CallerArgumentExpression(nameof(value))] string? variableName = null)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                return Errors.General.ValueIsInvalid(variableName);
            }

            return new LongString(value);
        }

        public static implicit operator string(LongString longString) => longString.Value;

        public static implicit operator LongString(string s) => new(s);
    }
}
