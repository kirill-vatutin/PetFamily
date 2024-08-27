using CSharpFunctionalExtensions;
using PetFamily.Domain.Modules.ValueObjects;

namespace PetFamily.Domain.Modules.Entities.Aggregates
{
    public class Species : Shared.Entity<SpeciesId>
    {

        public ShortString Name { get; private set; } = string.Empty;


        private List<Breed> _breeds = [];

        public IReadOnlyList<Breed> Breeds => _breeds.AsReadOnly();

        public void AddRequisite(Breed breed)
        {
            _breeds.Add(breed);
        }


        private Species(SpeciesId id) : base(id) { }

        private Species(SpeciesId id, ShortString name) : base(id)
        {
            Name = name;
        }

        public static Result<Species> Create(SpeciesId id, ShortString name)
        {
            return new Species(id, name);
        }
    }
}
