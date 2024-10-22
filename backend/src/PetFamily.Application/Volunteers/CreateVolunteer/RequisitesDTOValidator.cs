using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Modules.ValueObjects;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class RequisitesDTOValidator : AbstractValidator<RequisiteDTO>
    {
        public RequisitesDTOValidator()
        {
            RuleFor(r => new
            {
                r.Name,
                r.Description
            })
            .MustBeValueObject(r => Requisite.Create(r.Name, r.Description));
        }
    }

}
