using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                id => id.Value,
                value => PetId.Create(value)
                );

            builder.ComplexProperty(p => p.Name, pb =>
            {
                pb.Property(n => n.Value)
                  .IsRequired()
                  .HasMaxLength(ShortString.MAX_LENGTH)
                  .HasColumnName("name");
            });

            builder.ComplexProperty(p => p.Description, pb =>
            {
                pb.Property(d => d.Value)
                  .IsRequired()
                  .HasMaxLength(LongString.MAX_LENGTH)
                  .HasColumnName("description");
            });

            builder.ComplexProperty(p => p.Classification, pb =>
            {
                pb.Property(c => c.SpeciesId)
                   .IsRequired()
                   .HasConversion(
                   id => id.Value,
                   value => SpeciesId.Create(value)
                   )
                   .HasColumnName("species_id");
                pb.Property(c => c.BreedId)
                 .IsRequired()
                 .HasColumnName("breed_id");

            });

            builder.ComplexProperty(p => p.Color, pb =>
            {
                pb.Property(c => c.Value)
                  .IsRequired()
                  .HasMaxLength(ShortString.MAX_LENGTH)
                  .HasColumnName("color");
            });

            builder.ComplexProperty(p => p.HealthInfo, pb =>
            {
                pb.Property(hi => hi.Value)
                  .IsRequired()
                  .HasMaxLength(ShortString.MAX_LENGTH)
                  .HasColumnName("health_info");
            });

            builder.ComplexProperty(p => p.Address, pb =>
            {
                pb.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("country");

                pb.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("city");

                pb.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("street");

                pb.Property(a => a.HouseNumber)
                .IsRequired()
                .HasColumnName("house_number");

                pb.Property(a => a.HouseLetter)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("house_letter");
            }
             );

            builder.Property(p => p.Weight)
                .IsRequired();

            builder.Property(p => p.Height)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.Property(p => p.IsCastrated)
                .IsRequired();

            builder.Property(p => p.IsVaccinated)
                .IsRequired();

            builder.Property(p => p.BirthDay)
                .IsRequired();

            builder.Property(p => p.HelpStatus)
                .IsRequired()
                .HasConversion<string>();
            builder.OwnsOne(p => p.Requisites, pb =>
            {
                pb.ToJson();

                pb.OwnsMany(pr => pr.Requisites, prb =>
                {
                    prb.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                    prb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

                });
            });

            builder.Property(p => p.CreateTime)
                .IsRequired();

            builder.OwnsOne(p => p.PetPhotos, pb =>
            {
                pb.ToJson();

                pb.OwnsMany(pp => pp.PetPhotos, ppb =>
                {
                    ppb.Property(pp => pp.Path)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

                    ppb.Property(pp => pp.IsMain)
                    .IsRequired();
                });
            });

        }
    }
}
