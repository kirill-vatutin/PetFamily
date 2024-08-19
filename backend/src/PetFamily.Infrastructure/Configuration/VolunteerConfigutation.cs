using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration
{
    internal class VolunteerConfigutation : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value)
                );

            builder.ComplexProperty(v => v.FullName, nameBuilder =>
            {
                nameBuilder.Property(f => f.Firstname)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                nameBuilder.Property(f => f.SecondName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                nameBuilder.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            });

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.Property(v => v.YearsExperience)
                .IsRequired();

            builder.Property(v => v.PhoneNumber)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .IsRequired();

            builder.OwnsOne(v => v.Requisites, vb =>
            {
                vb.ToJson();

                vb.OwnsMany(vr => vr.Requisites, vrb =>
                {
                    vrb.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                    vrb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

                });
            });

            builder.OwnsOne(v => v.SocialNetworks, vb =>
            {
                vb.ToJson();

                vb.OwnsMany(sn => sn.SocialNetworks, snb =>
                {
                    snb.Property(sn => sn.Link)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                });

            });

            builder.HasMany(v => v.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id");

        }
    }
}
