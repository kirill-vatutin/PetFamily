using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Modules.ValueObjects
{
    public  record PhoneNumber
    {
        private const string pattern = @"^(\+7|8)[0-9]{10}$";
        public string Value { get; } = null!;

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static Result<PhoneNumber,Error> Create(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Errors.General.ValueIsRequired("Phone number");
            }

            if (!Regex.IsMatch(value, pattern))
            {
                return Errors.General.ValueIsInvalid("Phone number");
            }

            return new PhoneNumber(value);
        }

    }
}
