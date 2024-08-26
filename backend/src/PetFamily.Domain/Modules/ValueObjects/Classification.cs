using PetFamily.Domain.Modules.Entities.Aggregates;


namespace PetFamily.Domain.Modules.ValueObjects
{
    public record Classification
    {
        public SpeciesId SpeciesId { get; init; } = null!;
        public Guid BreedId { get; init; }

    }
};

