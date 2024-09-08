using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Modules.ValueObjects;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
    {
        public CreateVolunteerRequestValidator()
        {
            RuleFor(v => new
            {
                v.FullName.FirstName,
                v.FullName.SecondName,
                v.FullName.LastName
            })
                .MustBeValueObject(v => FullName.Create(v.FirstName, v.SecondName, v.LastName));

            RuleFor(v => new
            {
                v.Description
            })
                .MustBeValueObject(v => LongString.Create(v.Description));

            RuleForEach(v => v.RequisitesDTO)
                .SetValidator(new RequisitesDTOValidator());

            RuleForEach(v => v.SocialNetworksDTO)
                .SetValidator(new SocialNetworkDTOValidator());

            RuleFor(v => new
            {
                v.PhoneNumber
            })
                .MustBeValueObject(v => PhoneNumber.Create(v.PhoneNumber));

            RuleFor(v => v.YearsOfExperience)
                .NotNull()
                .LessThan(40);
        }
    }

}
