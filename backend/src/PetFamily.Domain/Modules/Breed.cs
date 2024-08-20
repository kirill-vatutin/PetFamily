using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules
{
    public class Breed : Shared.Entity<Guid>
    {
        private Breed(Guid id) : base(id) { }

        private Breed(Guid id, string name, Species species) : base(id)
        {
            Name = name;
            Species = species;
        }


        public string Name { get; set; } = string.Empty;

        public Species Species { get; private set; } = null!;

        public static Result<Breed> Create(Guid id, string name, Species species)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Breed>("Name can not be empty");
            }
            if (species is null)
            {
                return Result.Failure<Breed>("Species can not be empty");
            }
            var breed = new Breed(id, name, species);
            return breed;

        }


    }
}
