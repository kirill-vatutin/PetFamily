using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;

namespace PetFamily.Domain.Models
{
    public class Pet : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Species { get; private set; } = string.Empty;
       
        public string Breed { get; private set; } = string.Empty;

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

        public Requisite Requisite { get; private set; } = null!;

        public DateTime CreateTime { get; private set; }

        public PetPhotoList? PetPhotos { get; private set; }

        private Pet() { }

        private Pet(string name, string description, string species, string breed,
                   string color, string healthInfo, Address address, int weight,
                   int height, string phoneNumber, bool isCastrated, bool isVaccinated,
                   DateTime birthDay, HelpStatus helpStatus, Requisite requisite)
        {
            Name = name;
            Description = description;
            Species = species;
            Breed = breed;
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
            Requisite = requisite;
            CreateTime = DateTime.UtcNow;
        }



        public static Result<Pet> Create(string name, string description, string species, string breed,
                   string color, string healthInfo, Address address, int weight,
                   int height, string phoneNumber, bool isCastrated, bool isVaccinated,
                   DateTime birthDay, HelpStatus helpStatus, Requisite requisite)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Pet>("Name can not be empty");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure<Pet>("Description can not be empty");
            }
            if (string.IsNullOrWhiteSpace(breed))
            {
                return Result.Failure<Pet>("Breed can not be empty");
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

            var pet = new Pet(name, description, species, breed,
                    color, healthInfo, address, weight,
                    height, phoneNumber, isCastrated, isVaccinated,
                    birthDay, helpStatus, requisite);
            return  Result.Success(pet);
        }

    }
};

