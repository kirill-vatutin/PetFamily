using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Modules.ValueObjects
{
    public record FullName
    {
        public string Firstname { get; init; } = string.Empty;
        public string SecondName { get; init; } = string.Empty;
        public string? LastName { get; init; } = string.Empty;

        private FullName(string firstname, string secondName, string? lastName=null)
        {
            Firstname = firstname;
            SecondName = secondName;
            LastName = lastName;
        }

        public static Result<FullName,Error> Create(string firstname, string secondName, string? lastName=null)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                return Errors.General.ValueIsInvalid("FirstName");
            }
            if (string.IsNullOrWhiteSpace(secondName))
            {
                return Errors.General.ValueIsInvalid("SecondName");
            }

            return new FullName(firstname, secondName, lastName);
        }
    }
}
