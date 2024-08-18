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

            builder.ComplexProperty(v => v.Fio, fioBuilder =>
            {
                fioBuilder.Property(f => f.Firstname)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                fioBuilder.Property(f => f.SecondName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                fioBuilder.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            });

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.Property(v => v.YearsExperience)
                .IsRequired();

            builder.Property(v => v.CountHelp)
                .IsRequired();

            builder.Property(v => v.CountHouseSearch)
                .IsRequired();

            builder.Property(v => v.CountHouseFound)
                .IsRequired();

            builder.Property(v => v.PhoneNumber)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .IsRequired();

            builder.ComplexProperty(v => v.Requisite, requisiteBuilder =>
            {
                requisiteBuilder.Property(rb => rb.Name)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .IsRequired();

                requisiteBuilder.Property(rb => rb.Description)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .IsRequired();
            }
            );

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
