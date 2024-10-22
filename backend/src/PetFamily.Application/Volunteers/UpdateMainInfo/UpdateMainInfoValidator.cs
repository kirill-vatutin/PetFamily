using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public class UpdateMainInfoValidator:AbstractValidator<UpdateMainInfoRequest>
{
    public UpdateMainInfoValidator()
    {
        RuleFor(v => v.VolunteerId).NotEmpty().WithError(Errors.General.ValueIsRequired());

        RuleFor(v => new
        {
            v.Dto.FullName.FirstName,
            v.Dto.FullName.SecondName,
            v.Dto.FullName.LastName
        })
            .MustBeValueObject(v => FullName.Create(v.FirstName, v.SecondName, v.LastName));

        RuleFor(v => new
        {
            v.Dto.Description
        })
            .MustBeValueObject(v => LongString.Create(v.Description));

        RuleFor(v => new
        {
            v.Dto.PhoneNumber
        })
            .MustBeValueObject(v => PhoneNumber.Create(v.PhoneNumber));

        RuleFor(v => v.Dto.YearsOfExperience)
            .NotNull()
            .LessThan(40);
    }
}
