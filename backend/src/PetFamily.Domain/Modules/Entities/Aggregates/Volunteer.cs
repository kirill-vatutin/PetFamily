using PetFamily.Domain.Modules.ValueObjects;

namespace PetFamily.Domain.Modules.Entities.Aggregates
{

    public class Volunteer : Shared.Entity<VolunteerId>
    {
        public FullName FullName { get; private set; } = null!;

        public LongString Description { get; private set; } = string.Empty;
        public int YearsExperience { get; private set; }


        public PhoneNumber PhoneNumber { get; private set; }

        public RequisiteList? Requisites { get; private set; }


        private List<Pet> _pets = [];

        public IReadOnlyList<Pet> Pets => _pets;


        public SocialNetworkList? SocialNetworks { get; private set; }


        public int PetsCountHelp() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.LookingForAhouse);

        public int PetsCountHouseSearch() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.LookingForAhouse);

        public int PetsCountHouseFound() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.FoundAHouse);


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




    }
}
