using CSharpFunctionalExtensions;

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

        public static Result<FullName> Create(string firstname, string secondName, string? lastName=null)
        {
            if (string.IsNullOrEmpty(firstname))
            {
                return Result.Failure<FullName>("Firstname can not be empty");
            }
            if (string.IsNullOrEmpty(secondName))
            {
                return Result.Failure<FullName>("SecondName can not be empty");
            }
            
            return new FullName(firstname, secondName, lastName);
        }
    }
}
