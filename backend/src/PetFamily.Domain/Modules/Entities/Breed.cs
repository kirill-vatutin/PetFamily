using CSharpFunctionalExtensions;
using PetFamily.Domain.Modules.ValueObjects;

namespace PetFamily.Domain.Modules.Entities
{
    public class Breed : Shared.Entity<BreedId>
    {
        private Breed(BreedId id) : base(id) { }

        private Breed(BreedId id, ShortString name) : base(id)
        {
            Name = name;
        }

        public ShortString Name { get; set; } = string.Empty;



        public static Result<Breed> Create(BreedId id, ShortString name)
        {
            return new Breed(id, name);
        }


    }
}
