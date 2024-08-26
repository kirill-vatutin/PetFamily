using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Shared;
using System.Reflection.Metadata;

namespace PetFamily.Infrastructure.Configuration
{
    internal class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("species");
            builder.HasKey(s =>s.Id);

            builder.Property(s => s.Id)
                .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value)
                );

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.HasMany(s => s.Breeds)
                 .WithOne()
                 .HasForeignKey("breed_id");
        }

      
    }
}
