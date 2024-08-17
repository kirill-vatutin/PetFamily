﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.Property(p => p.Species)
               .IsRequired()
               .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(p => p.Breed)
              .IsRequired()
              .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(p => p.Color)
              .IsRequired()
              .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(p => p.HealthInfo)
              .IsRequired()
              .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

            builder.OwnsOne(p => p.Address, pb =>
            {
                pb.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                pb.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                pb.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                pb.Property(a => a.HouseNumber)
                .IsRequired();

                pb.Property(a => a.HouseLetter)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
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

            builder.OwnsOne(p => p.Requisite, requisiteBuilder =>
            {
                requisiteBuilder.Property(rb => rb.Name)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .IsRequired();

                requisiteBuilder.Property(rb => rb.Description)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .IsRequired();
            }
          );

            builder.Property(p => p.CreateTime)
                .IsRequired();

            builder.OwnsOne(p => p.PetPhotos, pb =>
            {
                pb.ToJson();

                pb.OwnsMany(pp => pp.PetPhotos, ppb =>
                {
                    ppb.Property(pp => pp.Path)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                    ppb.Property(pp => pp.IsMain)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                });

            });





        }
    }
}