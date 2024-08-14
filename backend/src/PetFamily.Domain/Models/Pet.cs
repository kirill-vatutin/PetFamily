using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;

namespace PetFamily.Domain.Models
{
    public class Pet : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Species { get; private set; } = string.Empty;
        // Стоит ли создавать enum под вид? Код упрощается, но это уже хардкодинг

        public string Breed { get; private set; } = string.Empty;

        public string Color { get; private set; } = string.Empty;

        public string HealthInfo { get; private set; } = string.Empty;

        public Address Address { get; private set; } = null!;

        public int Weight { get; private set; }

        public int Height { get; private set; }

        public string PhoneNumber { get; private set; } = string.Empty;

        public bool IsCastrated { get; private set; }

        public bool IsVaccinated { get; private set; }

        public DateTime BirthDay { get; private set; }

        public HelpStatus HelpStatus { get; private set; }

        public Requisite Requisite { get; private set; } = null!;

        public DateTime CreateTime { get; private set; }


        public Pet(string name, string description, string species, string breed,
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

        public Result<Pet?, string?> Create(string name, string description, string species, string breed,
                   string color, string healthInfo, Address address, int weight,
                   int height, string phoneNumber, bool isCastrated, bool isVaccinated,
                   DateTime birthDay, HelpStatus helpStatus, Requisite requisite)
        {
            return  Result<Pet>(new Pet( name,  description,  species,  breed,
                    color,  healthInfo,  address,  weight,
                    height,  phoneNumber,  isCastrated,  isVaccinated,
                    birthDay,  helpStatus,  requisite));
        }

    }
};

