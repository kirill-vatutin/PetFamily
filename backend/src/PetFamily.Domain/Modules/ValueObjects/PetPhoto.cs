using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Modules.ValueObjects
{
    public record PetPhoto
    {
        public string Path { get; init; } = string.Empty;
        public bool IsMain { get; init; } = false;

        private PetPhoto(string path, bool isMain)
        {
            Path = path;
            IsMain = isMain;
        }

        public static Result<PetPhoto> Create(string path, bool isMain=false)
        {
            return new PetPhoto(path, isMain);  
        }


    }
}
