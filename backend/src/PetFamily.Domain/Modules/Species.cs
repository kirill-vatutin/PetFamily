using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules
{
    public class Species : Shared.Entity<SpeciesId>
    {

        public string Name { get; private set; }


        private List<Breed> _breeds = [];

        public IReadOnlyList<Breed> Breeds => _breeds.AsReadOnly();

        public void AddRequisite(Breed breed)
        {
            _breeds.Add(breed);
        }


        private Species(SpeciesId id) : base(id) { }

        private Species(SpeciesId id, string name) : base(id)
        {
            Name = name;
        }

        public static Result<Species> Create(SpeciesId id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Species>("Name can not be empty");
            }
            var species = new Species(id, name);
            return species;
        }
    }
}
