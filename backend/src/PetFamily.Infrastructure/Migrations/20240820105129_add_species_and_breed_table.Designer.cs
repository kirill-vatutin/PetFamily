﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFamily.Infrastructure;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240820105129_add_species_and_breed_table")]
    partial class add_species_and_breed_table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFamily.Domain.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_day");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("HealthInfo")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("health_info");

                    b.Property<int>("Height")
                        .HasColumnType("integer")
                        .HasColumnName("height");

                    b.Property<string>("HelpStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("help_status");

                    b.Property<bool>("IsCastrated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_castrated");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("phone_number");

                    b.Property<int>("Weight")
                        .HasColumnType("integer")
                        .HasColumnName("weight");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "PetFamily.Domain.Models.Pet.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_country");

                            b1.Property<string>("HouseLetter")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_house_letter");

                            b1.Property<int>("HouseNumber")
                                .HasColumnType("integer")
                                .HasColumnName("address_house_number");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Classification", "PetFamily.Domain.Models.Pet.Classification#Classification", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("BreedId")
                                .HasColumnType("uuid")
                                .HasColumnName("classification_breed_id");

                            b1.Property<Guid>("SpeciesId")
                                .HasColumnType("uuid")
                                .HasColumnName("classification_species_id");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("phone_number");

                    b.Property<int>("YearsExperience")
                        .HasColumnType("integer")
                        .HasColumnName("years_experience");

                    b.ComplexProperty<Dictionary<string, object>>("FullName", "PetFamily.Domain.Models.Volunteer.FullName#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Firstname")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("full_name_firstname");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("full_name_last_name");

                            b1.Property<string>("SecondName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("full_name_second_name");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Modules.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("SpeciesId")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.Property<Guid?>("breed_id")
                        .HasColumnType("uuid")
                        .HasColumnName("breed_id");

                    b.HasKey("Id")
                        .HasName("pk_breeds");

                    b.HasIndex("SpeciesId")
                        .HasDatabaseName("ix_breeds_species_id");

                    b.HasIndex("breed_id")
                        .HasDatabaseName("ix_breeds_breed_id");

                    b.ToTable("breeds", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Modules.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Pet", b =>
                {
                    b.HasOne("PetFamily.Domain.Models.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("volunteer_id")
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");

                    b.OwnsOne("PetFamily.Domain.Modules.RequisiteList", "Requisites", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId")
                                .HasName("pk_pets");

                            b1.ToTable("pets");

                            b1.ToJson("requisites");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_pet_id");

                            b1.OwnsMany("PetFamily.Domain.Models.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("RequisiteListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(2000)
                                        .HasColumnType("character varying(2000)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("RequisiteListPetId", "Id");

                                    b2.ToTable("pets");

                                    b2.ToJson("requisites");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisiteListPetId")
                                        .HasConstraintName("fk_pets_pets_requisite_list_pet_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.OwnsOne("PetFamily.Domain.Modules.PetPhotoList", "PetPhotos", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.ToJson("pet_photos");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");

                            b1.OwnsMany("PetFamily.Domain.Models.PetPhoto", "PetPhotos", b2 =>
                                {
                                    b2.Property<Guid>("PetPhotoListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<bool>("IsMain")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("Path")
                                        .IsRequired()
                                        .HasMaxLength(2000)
                                        .HasColumnType("character varying(2000)");

                                    b2.HasKey("PetPhotoListPetId", "Id");

                                    b2.ToTable("pets");

                                    b2.ToJson("pet_photos");

                                    b2.WithOwner()
                                        .HasForeignKey("PetPhotoListPetId")
                                        .HasConstraintName("fk_pets_pets_pet_photo_list_pet_id");
                                });

                            b1.Navigation("PetPhotos");
                        });

                    b.Navigation("PetPhotos");

                    b.Navigation("Requisites");
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Volunteer", b =>
                {
                    b.OwnsOne("PetFamily.Domain.Modules.RequisiteList", "Requisites", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("requisites");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("PetFamily.Domain.Models.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("RequisiteListVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(2000)
                                        .HasColumnType("character varying(2000)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("RequisiteListVolunteerId", "Id");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("requisites");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisiteListVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_requisite_list_volunteer_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.OwnsOne("PetFamily.Domain.Modules.SocialNetworkList", "SocialNetworks", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("social_networks");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("PetFamily.Domain.Models.SocialNetwork", "SocialNetworks", b2 =>
                                {
                                    b2.Property<Guid>("SocialNetworkListVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Link")
                                        .IsRequired()
                                        .HasMaxLength(2000)
                                        .HasColumnType("character varying(2000)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("SocialNetworkListVolunteerId", "Id");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("social_networks");

                                    b2.WithOwner()
                                        .HasForeignKey("SocialNetworkListVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_social_network_list_volunteer_id");
                                });

                            b1.Navigation("SocialNetworks");
                        });

                    b.Navigation("Requisites");

                    b.Navigation("SocialNetworks");
                });

            modelBuilder.Entity("PetFamily.Domain.Modules.Breed", b =>
                {
                    b.HasOne("PetFamily.Domain.Modules.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_breeds_species_species_id");

                    b.HasOne("PetFamily.Domain.Modules.Species", null)
                        .WithMany("Breeds")
                        .HasForeignKey("breed_id")
                        .HasConstraintName("fk_breeds_species_breed_id");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PetFamily.Domain.Models.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetFamily.Domain.Modules.Species", b =>
                {
                    b.Navigation("Breeds");
                });
#pragma warning restore 612, 618
        }
    }
}
