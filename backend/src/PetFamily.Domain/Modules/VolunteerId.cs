﻿namespace PetFamily.Domain.Models
{
    public record VolunteerId
    {
        public Guid Value { get; }

        private VolunteerId(Guid value)
        {
            Value = value;
        }

        public static VolunteerId NewVolonteerId() => new(Guid.NewGuid());

        public static VolunteerId Empty() => new(Guid.Empty);

        public static VolunteerId Create(Guid id) => new(id);
      
    }

}
