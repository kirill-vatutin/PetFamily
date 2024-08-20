using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Modules;
using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Infrastructure.Configuration
{
    internal class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("breeds");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            builder.HasOne(b => b.Species)
                   .WithMany();

        }
    }
}
