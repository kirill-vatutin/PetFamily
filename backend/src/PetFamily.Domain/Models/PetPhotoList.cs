namespace PetFamily.Domain.Models
{
    public record PetPhotoList
    {

        private List<PetPhoto> _petPhotos = [];
        public IReadOnlyList<PetPhoto> PetPhotos => _petPhotos;

        public void AddPhoto(PetPhoto photo)
        {
            _petPhotos.Add(photo);
        }

    }
}
