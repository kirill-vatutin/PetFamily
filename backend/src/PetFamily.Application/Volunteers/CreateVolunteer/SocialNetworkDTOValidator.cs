using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Modules.ValueObjects;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class SocialNetworkDTOValidator : AbstractValidator<SocialNetworkDTO>
    {
        public SocialNetworkDTOValidator()
        {
            RuleFor(s => new
            {
                s.Name,
                s.Link
            })
            .MustBeValueObject(s => Requisite.Create(s.Name, s.Link));

        }
    }

}
