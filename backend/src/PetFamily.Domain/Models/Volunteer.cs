using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Models
{
    public class Volunteer:BaseEntity
    {
       
        public  string Firstname { get; private set; } =string.Empty;
        public string SecondName { get; private set;} =string.Empty;
        public string LastName { get;private set; } =string.Empty;
        public string Description { get; private set; } =string.Empty;
        public int YearsExperience { get; private set; }

        public int CountOfNeedHelp { get; private set; }
        public int CountOfLookingForAHouse { get; private set; }
        public int CountOfFoundAHouse { get; private set; }

        public string PhoneNumber { get; private set; } = string.Empty;

        public IReadOnlyList<SocialNetwork>



    }
}
