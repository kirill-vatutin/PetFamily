using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;
using System.Text.Json;

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
                .HasColumnName("first_name");

                nameBuilder.Property(fn => fn.SecondName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("second_name");

                nameBuilder.Property(fn => fn.LastName)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("last_name");
            });

            builder.ComplexProperty(v => v.Description, vb =>
            {
                vb.Property(d => d.Value)
                  .IsRequired()
                  .HasMaxLength(LongString.MAX_LENGTH)
                  .HasColumnName("description");
            });

            builder.Property(v => v.YearsExperience)
                .IsRequired();


            builder.ComplexProperty(v => v.PhoneNumber, vb =>
            {
                vb.Property(p => p.Value)
                  .IsRequired()
                  .HasMaxLength(ShortString.MAX_LENGTH)
                  .HasColumnName("phone_number");
            });

            builder.OwnsOne(v => v.Requisites, vb =>
            {
                //vb.WithOwner().HasForeignKey("VolunteerId");
                //vb.Property<int>("Id").ValueGeneratedOnAdd();
                //vb.HasKey("VolunteerId", "Id");

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

            //builder.Property(v => v.SocialNetworks)
            //    .HasConversion(
            //    list => JsonSerializer.Serialize(list,JsonSerializerOptions.Default),
            //    value => JsonSerializer.Deserialize<SocialNetworkList>(value, JsonSerializerOptions.Default)!
            //    );

            //builder.Property(v => v.Requisites)
            //    .HasConversion(
            //    list => JsonSerializer.Serialize(list, JsonSerializerOptions.Default),
            //    value => JsonSerializer.Deserialize<RequisiteList>(value, JsonSerializerOptions.Default)!
            //    );

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
                .HasForeignKey("volunteer_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property<bool>("_isDeleted")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasColumnName("is_deleted");
        }
    }
}
