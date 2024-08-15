namespace PetFamily.Domain.Models
{
    public class PetPhoto:BaseEntity
    {
        public string Path { get; private set; } = string.Empty;
        public bool IsMain { get; private set; }

        //EF Core
        private  PetPhoto()
        {

        }

        public PetPhoto(string path,bool isMain)
        {
            Path= path;
            IsMain = isMain;
        }

    }
}
