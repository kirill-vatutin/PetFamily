using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Modules.Entities.Aggregates;
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
                nameBuilder.Property(fn => fn.Firstname)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("firstname");

                nameBuilder.Property(fn => fn.SecondName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("lastname");

                nameBuilder.Property(fn => fn.LastName)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("lastname");
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

                vb.OwnsMany(vs => vs.SocialNetworks, vsb =>
                {
                    vsb.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                    vsb.Property(r => r.Link)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

                });
            });



            builder.HasMany(v => v.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id");

        }
    }
}
