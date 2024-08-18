namespace PetFamily.Domain.Models
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }

        protected BaseEntity() { }

    }


}
