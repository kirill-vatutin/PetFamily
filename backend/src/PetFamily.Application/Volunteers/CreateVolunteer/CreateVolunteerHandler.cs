using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerHandler
    {
        private readonly IVolunteersRepository _repository;
        private readonly ILogger<CreateVolunteerHandler> _logger;

        public CreateVolunteerHandler(IVolunteersRepository repository,
                                      ILogger<CreateVolunteerHandler> logger)
        {
            _repository = repository;
            _logger= logger;
        }

        public async Task<Result<Guid, Error>> Handle(
            CreateVolunteerRequest request, CancellationToken cancellationToken = default)
        {

            var volunteerId = VolunteerId.NewVolonteerId();

            var existVolunteer = await _repository.GetById(volunteerId);

            if (existVolunteer.IsSuccess)
            {
                Errors.Volunteer.AlreadyExist();
            }

            var fullNameResult = FullName.Create(request.FullName.FirstName,
                                                request.FullName.SecondName,
                                                request.FullName.LastName);

            var descriptionResult = LongString.Create(request.Description);

            var phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);

            SocialNetworkList socialNetworksList = new(request.SocialNetworksDTO.Select(
                nw => SocialNetwork.Create(
                    nw.Name,
                    nw.Link)
                   .Value));

            RequisiteList requisitesList = new(request.RequisitesDTO.Select(
                r => Requisite.Create(r.Name,
                                    r.Description)
                                   .Value));


            var volunteer = new Volunteer(volunteerId,
                                                   fullNameResult.Value,
                                                   descriptionResult.Value,
                                                   request.YearsOfExperience,
                                                   phoneNumberResult.Value,
                                                   requisitesList,
                                                   socialNetworksList);

            await _repository.Add(volunteer);

            _logger.LogInformation("Created volunteer {fullNameResult} with Id:{volunteerId}", fullNameResult.Value, volunteerId.Value);

            return (Guid)volunteer.Id;
        }

    }
}
