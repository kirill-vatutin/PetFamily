using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration
{
    internal class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("species");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value)
                );

            builder.ComplexProperty(s => s.Name, sb =>
            {
                sb.Property(n => n.Value)
                  .IsRequired()
                  .HasMaxLength(ShortString.MAX_LENGTH)
                  .HasColumnName("name");
            });

            builder.HasMany(s => s.Breeds)
                 .WithOne()
                 .HasForeignKey("breed_id");
        }


    }
}
