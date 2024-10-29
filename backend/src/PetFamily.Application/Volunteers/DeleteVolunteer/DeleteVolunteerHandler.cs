using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Shared;

namespace PetFamily.API.Controllers;

public class DeleteVolunteerHandler
{
    private readonly IVolunteersRepository _repository;
    private readonly ILogger<DeleteVolunteerHandler> _logger;

    public DeleteVolunteerHandler(IVolunteersRepository repository,
                                 ILogger<DeleteVolunteerHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        DeleteVolunteerRequest request, CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _repository.GetById(request.VolunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        volunteerResult.Value.Delete();

        //var result = await _repository.Delete(volunteerResult.Value, cancellationToken);

        var result = await _repository.SaveAsync(volunteerResult.Value, cancellationToken);

        _logger.LogInformation(
            "Deleted volunteer with Id:{volunteerId}",
            volunteerResult.Value.Id);

        return result;
    }
}