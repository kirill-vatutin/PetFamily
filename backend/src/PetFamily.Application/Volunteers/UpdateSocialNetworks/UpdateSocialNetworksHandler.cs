using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Application.Volunteers.UpdateMainInfo;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.UpdateSocialNetworks;

public class UpdateSocialNetworksHandler
{
    private readonly IVolunteersRepository _repository;
    private readonly ILogger<UpdateSocialNetworksHandler> _logger;

    public UpdateSocialNetworksHandler(IVolunteersRepository repository,
                                 ILogger<UpdateSocialNetworksHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateSocialNetworksRequest request, CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _repository.GetById(request.VolunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        var socialNetworks = request.SocialNetworksDTO.Select(sn =>
            SocialNetwork.Create(sn.Name, sn.Link).Value
        );

        volunteerResult.Value.UpdateSocialNetworks(socialNetworks);
        var result = await _repository.SaveAsync(volunteerResult.Value, cancellationToken);

        _logger.LogInformation(
            "Updated volunteer social networks {socialNetworks} with Id:{volunteerId}",
            socialNetworks, volunteerResult.Value.Id);

        return result;
    }
}
