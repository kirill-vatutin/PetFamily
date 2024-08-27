using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Modules.Entities;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;


namespace PetFamily.Infrastructure.Configuration
{
    internal class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("breeds");

            builder.HasKey(b => b.Id);

            builder.Property(p => p.Id)
            .HasConversion(
            id => id.Value,
            value => BreedId.Create(value));

            builder.ComplexProperty(b => b.Name, bb =>
            {
                bb.Property(n => n.Value)
                  .IsRequired()
                  .HasMaxLength(ShortString.MAX_LENGTH)
                  .HasColumnName("name");
            });
                


        }
    }
}
