﻿namespace PetFamily.Domain.Modules.Entities.Aggregates
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

        public static implicit operator Guid(VolunteerId id) => id.Value;

    }

}
