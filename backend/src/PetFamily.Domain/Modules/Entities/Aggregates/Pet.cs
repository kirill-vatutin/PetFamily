using PetFamily.Domain.Enums;
using PetFamily.Domain.Models;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;


namespace PetFamily.Domain.Modules.Entities.Aggregates
{
    public class Pet : Entity<PetId>, ISoftDeletable
    {
        private bool _isDeleted = false;
        public ShortString Name { get; private set; } = string.Empty;
        public LongString Description { get; private set; } = string.Empty;

        public Classification Classification { get; private set; } = null!;

        public ShortString Color { get; private set; } = string.Empty;

        public LongString HealthInfo { get; private set; } = string.Empty;

        public Address Address { get; private set; } = null!;

        public int Weight { get; private set; }
        public int Height { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public bool IsCastrated { get; private set; } = false;
        public bool IsVaccinated { get; private set; } = false;

        public DateTime BirthDay { get; private set; }
        public HelpStatus HelpStatus { get; private set; }

        public RequisiteList? Requisites { get; private set; }
        public DateTime CreateTime { get; private set; }
        public PetPhotoList? PetPhotos { get; private set; }

        private Pet(PetId id) : base(id) { }

        public Pet(PetId id,
                    ShortString name,
                    LongString description,
                    Classification classification,
                    ShortString color,
                    LongString healthInfo,
                    Address address,
                    int weight,
                    int height,
                    PhoneNumber phoneNumber,
                    bool isCastrated,
                    bool isVaccinated,
                    DateTime birthDay,
                    HelpStatus helpStatus
            ) : base(id)
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

        public void Delete()
        {
            if (_isDeleted == false)
                _isDeleted = true;
        }

        public void Restore()
        {
            if (_isDeleted == true)
                _isDeleted = false;
        }
    }
};

