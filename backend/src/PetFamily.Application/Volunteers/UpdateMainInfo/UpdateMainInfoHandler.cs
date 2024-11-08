using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Application.Volunteers;
using PetFamily.Application.Volunteers.UpdateMainInfo;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.API.Controllers;

public class UpdateMainInfoHandler
{
    private readonly IVolunteersRepository _repository;
    private readonly ILogger<UpdateMainInfoHandler> _logger;

    public UpdateMainInfoHandler(IVolunteersRepository repository,
                                  ILogger<UpdateMainInfoHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateMainInfoRequest request, CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _repository.GetById(request.VolunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
        {
            return volunteerResult.Error;
        }

        var fullName = FullName.Create(
            request.Dto.FullName.FirstName,
            request.Dto.FullName.SecondName,
            request.Dto.FullName.LastName
            ).Value;
        var description = LongString.Create(request.Dto.Description).Value;
        var yearsOfExperience = request.Dto.YearsOfExperience;
        var phoneNumber = PhoneNumber.Create(request.Dto.PhoneNumber).Value;

        volunteerResult.Value.UpdateMainInfo(fullName,description,yearsOfExperience,phoneNumber);

        var result = await _repository.SaveAsync(volunteerResult.Value, cancellationToken);

        _logger.LogInformation(@"Updated volunteer main info:" +
                                "{fullNameResult}" +
                                "{description}" +
                                "{yearsOfExperience}" +
                                "{phoneNumber}" +
                                "with Id:{volunteerId}",
                                fullName,
                                description,
                                yearsOfExperience,
                                phoneNumber,
                                volunteerResult.Value.Id.Value);

        return result;
    }
}