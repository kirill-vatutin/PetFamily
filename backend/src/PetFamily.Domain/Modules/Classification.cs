using PetFamily.Domain.Modules;


namespace PetFamily.Domain.Models
{
    public record Classification
    {
        public SpeciesId SpeciesId { get; init; } = null!;
        public BreedId BreedId { get; init; } = null!;
    }
};

