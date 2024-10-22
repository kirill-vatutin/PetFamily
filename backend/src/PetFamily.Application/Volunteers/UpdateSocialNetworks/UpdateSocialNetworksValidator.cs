using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Application.Volunteers.Shared;
using PetFamily.Application.Volunteers.UpdateSocialNetworks;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public class UpdateSocialNetworksValidator : AbstractValidator<UpdateSocialNetworksRequest>
{
    public UpdateSocialNetworksValidator()
    {
        RuleFor(v => v.VolunteerId)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired());

        RuleForEach(v => v.SocialNetworksDTO)
                .SetValidator(new SocialNetworkDTOValidator());
    }
}
