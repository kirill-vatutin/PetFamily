using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Modules.Entities.Aggregates
{

    public class Volunteer : Entity<VolunteerId>, ISoftDeletable
    {
        private bool _isDeleted = false;
        public FullName FullName { get; private set; } = null!;

        public LongString Description { get; private set; } = string.Empty;
        public int YearsExperience { get; private set; }


        public PhoneNumber PhoneNumber { get; private set; }

        public RequisiteList? Requisites { get; private set; }
        public SocialNetworkList? SocialNetworks { get; private set; }

        private List<Pet> _pets = [];

        public IReadOnlyList<Pet> Pets => _pets;

        public int PetsCountHelp() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.LookingForAhouse);
        public int PetsCountHouseSearch() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.LookingForAhouse);
        public int PetsCountHouseFound() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.FoundAHouse);

        public void UpdateMainInfo(FullName fullName, LongString description, int yearsOfExperience, PhoneNumber phoneNumber)
        {
            FullName = fullName;
            Description = description;
            YearsExperience = yearsOfExperience;
            PhoneNumber = phoneNumber;
        }

        public void UpdateSocialNetworks(IEnumerable<SocialNetwork> socialNetworks)
        {
            SocialNetworks = new SocialNetworkList(socialNetworks);
        }

        //EF Core
        private Volunteer(VolunteerId id)
            : base(id)
        { }

        public Volunteer(VolunteerId id,
                          FullName fullName,
                          LongString description,
                          int yearsExperience,
                          PhoneNumber phoneNumber,
                          RequisiteList? requisitesList,
                          SocialNetworkList? socialNetworksList)
            : base(id)
        {
            FullName = fullName;
            Description = description;
            YearsExperience = yearsExperience;
            PhoneNumber = phoneNumber;
            Requisites = requisitesList;
            SocialNetworks = socialNetworksList;
        }

        public void Delete()
        {
            if (_isDeleted == false)
                _isDeleted = true;

            foreach (var pet in _pets)
            {
                pet.Delete();
            }
        }

        public void Restore()
        {
            if (_isDeleted == true)
                _isDeleted = false;

            foreach (var pet in _pets)
            {
                pet.Restore();
            }
        }
    }
}
