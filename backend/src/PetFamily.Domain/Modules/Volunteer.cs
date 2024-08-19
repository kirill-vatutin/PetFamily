using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models
{

    public class Volunteer : Shared.Entity<VolunteerId>
    {
        public FullName FullName { get; private set; } = null!;

        public string Description { get; private set; } = string.Empty;
        public int YearsExperience { get; private set; }


        public string PhoneNumber { get; private set; } = string.Empty;

        private List<Requisite> _requisites = [];

        public IReadOnlyList<Requisite> Requisites =>_requisites.AsReadOnly();  



        private List<Pet> _pets = [];

        public IReadOnlyList<Pet> Pets => _pets;


        private List<SocialNetwork> _socialNetworks = [];

        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks.AsReadOnly();

        public void AddRequisite(Requisite requisite)
        {
            _requisites.Add(requisite);
        }

        public void AddSocialNetwork(SocialNetwork socialNetwork)
        {
            _socialNetworks.Add(socialNetwork);
        }

        public void AddPet(Pet pet)
        {
            _pets.Add(pet);
        }

        public int PetsCountHelp() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.LookingForAhouse);

        public int PetsCountHouseSearch() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.LookingForAhouse);

        public int PetsCountHouseFound() => _pets.Count(p => p.HelpStatus == Enums.HelpStatus.FoundAHouse);


        //EF Core
        private Volunteer(VolunteerId id)
            : base(id)
        { }

        private Volunteer(VolunteerId id, FullName fullname, string description,
                          int yearsExperience, string phoneNumber)
            : base(id)
        {
            FullName = fullName;
            Description = description;
            YearsExperience = yearsExperience;
            PhoneNumber = phoneNumber;
        }

        public static Result<Volunteer> Create(VolunteerId id, FullName fullName,
                      string description, int yearsExperience, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName.Firstname))
            {
                return Result.Failure<Volunteer>("Firstname can not be empty");
            }

            if (string.IsNullOrWhiteSpace(fullName.LastName))
            {
                return Result.Failure<Volunteer>("Lastname can not be empty");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure<Volunteer>("Description can not be empty");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result.Failure<Volunteer>("Phone number can not be empty");
            }
            var volunteer = new Volunteer(id, fullName, description, yearsExperience, phoneNumber);
            return volunteer;
        }




    }

}
