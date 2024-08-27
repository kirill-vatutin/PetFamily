using CSharpFunctionalExtensions;
using PetFamily.Domain.Modules.ValueObjects;

namespace PetFamily.Domain.Modules.Entities.Aggregates
{

    public class Volunteer : Shared.Entity<VolunteerId>
    {
        public FullName FullName { get; private set; } = null!;

        public LongString Description { get; private set; } = string.Empty;
        public int YearsExperience { get; private set; }


        public string PhoneNumber { get; private set; } = string.Empty;

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

        private Volunteer(VolunteerId id,
                          FullName fullName,
                          LongString description,
                          int yearsExperience,
                          string phoneNumber,
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

        public static Result<Volunteer> Create(VolunteerId id,
                                               FullName fullName,
                                               LongString description,
                                               int yearsExperience,
                                               string phoneNumber,
                                               RequisiteList? requisitesList = null,
                                               SocialNetworkList? socialNetworksList = null)
        {

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result.Failure<Volunteer>("Phone number can not be empty");
            }

            var volunteer = new Volunteer(
                id, fullName, description, yearsExperience, phoneNumber, requisitesList, socialNetworksList);

            return volunteer;
        }


    }
}
