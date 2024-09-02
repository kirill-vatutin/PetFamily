using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules.ValueObjects
{
    public record Requisite
    {
        public string Name { get; }
        public string Description { get; } 

        private Requisite(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Result<Requisite> Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Requisite>("Name can not be empty");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure<Requisite>("Description can not be empty");
            }

            return new Requisite(name, description);
        }
    }
};

