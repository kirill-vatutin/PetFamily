using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;
using PetFamily.Domain.Models;
using PetFamily.Domain.Modules.ValueObjects;


namespace PetFamily.Domain.Modules.Entities.Aggregates
{
    public class Pet : Shared.Entity<PetId>
    {
        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;


        public Classification Classification { get; private set; } = null!;


        public string Color { get; private set; } = string.Empty;


        public string HealthInfo { get; private set; } = string.Empty;


        public Address Address { get; private set; } = null!;


        public int Weight { get; private set; }

        public int Height { get; private set; }


        public string PhoneNumber { get; private set; } = string.Empty;


        public bool IsCastrated { get; private set; } = false;

        public bool IsVaccinated { get; private set; } = false;


        public DateTime BirthDay { get; private set; }

        public HelpStatus HelpStatus { get; private set; }


        public RequisiteList? Requisites { get; private set; }

        public DateTime CreateTime { get; private set; }

        public PetPhotoList? PetPhotos { get; private set; }


        private Pet(PetId id) : base(id) { }

        private Pet(PetId id,
                    string name,
                    string description,
                    Classification classification,
                    string color,
                    string healthInfo,
                    Address address,
                    int weight,
                    int height,
                    string phoneNumber,
                    bool isCastrated,
                    bool isVaccinated,
                    DateTime birthDay,
                    HelpStatus helpStatus
            ): base(id)
        {
            Name = name;
            Description = description;
            Classification = classification;
            Color = color;
            HealthInfo = healthInfo;
            Address = address;
            Weight = weight;
            Height = height;
            PhoneNumber = phoneNumber;
            IsCastrated = isCastrated;
            IsVaccinated = isVaccinated;
            BirthDay = birthDay;
            HelpStatus = helpStatus;
            CreateTime = DateTime.UtcNow;
        }



        public static Result<Pet> Create(PetId id,
                                         string name,
                                         string description,
                                         Classification classification,
                                         string color,
                                         string healthInfo,
                                         Address address,
                                         int weight,
                                         int height,
                                         string phoneNumber,
                                         bool isCastrated,
                                         bool isVaccinated,
                                         DateTime birthDay,
                                         HelpStatus helpStatus)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Pet>("Name can not be empty");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure<Pet>("Description can not be empty");
            }
            if (string.IsNullOrWhiteSpace(color))
            {
                return Result.Failure<Pet>("Color can not be empty");
            }
            if (string.IsNullOrWhiteSpace(healthInfo))
            {
                return Result.Failure<Pet>("HealthInfo can not be empty");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result.Failure<Pet>("PhoneNumber can not be empty");
            }

            var pet = new Pet(id, name, description, classification,
                    color, healthInfo, address, weight,
                    height, phoneNumber, isCastrated, isVaccinated,
                    birthDay, helpStatus);
            return pet;
        }

    }
};

