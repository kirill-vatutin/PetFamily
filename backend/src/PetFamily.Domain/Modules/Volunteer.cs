using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models
{

    public class Volunteer : Shared.Entity<VolunteerId>
    {
        public FIO Fio { get; private set; } = null!;

        public string Description { get; private set; } = string.Empty;
        public int YearsExperience { get; private set; }

        public int CountHelp { get; private set; }
        public int CountHouseSearch { get; private set; }
        public int CountHouseFound { get; private set; }

        public string PhoneNumber { get; private set; } = string.Empty;

        public Requisite Requisite { get; private set; } = null!;

        private List<Pet> _pets = new();

        public IReadOnlyList<Pet> Pets => _pets;

        public SocialNetworkList? SocialNetworks { get; private set; }

        public void AddPet(Pet pet)
        {
            _pets.Add(pet);
        }

        //EF Core
        private Volunteer(VolunteerId id)
            :base(id)
        {   }

        private Volunteer(VolunteerId id, FIO fio, string description, int yearsExperience, string phoneNumber, Requisite requisite)
            :base(id)
        {
            Fio = fio;
            Description = description;
            YearsExperience = yearsExperience;
            PhoneNumber = phoneNumber;
            Requisite = requisite;
            CountHelp = 0;
            CountHouseSearch = 0;
            CountHouseFound = 0;
        }

        public static Result<Volunteer> Create(VolunteerId id, FIO fio, string description, int yearsExperience, string phoneNumber, Requisite requisite)
        {
            if (string.IsNullOrWhiteSpace(fio.Firstname))
            {
                return Result.Failure<Volunteer>("Firstname can not be empty");
            }

            if (string.IsNullOrWhiteSpace(fio.LastName))
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
            var volunteer = new Volunteer(id,fio, description, yearsExperience, phoneNumber, requisite);
            return Result.Success(volunteer);
        }




    }

}
