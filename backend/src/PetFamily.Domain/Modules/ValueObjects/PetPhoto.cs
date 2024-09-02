using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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

        public static Result<PetPhoto,Error> Create(string path, bool isMain=false)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return Errors.General.ValueIsInvalid("Path");
            }
            return new PetPhoto(path, isMain);  
        }


    }
}
