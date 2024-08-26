using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules.Entities
{
    public class Breed : Shared.Entity<BreedId>
    {
        private Breed(BreedId id) : base(id) { }

        private Breed(BreedId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;



        public static Result<Breed> Create(BreedId id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Breed>("Name can not be empty");
            }

            var breed = new Breed(id, name);
            return breed;

        }


    }
}
