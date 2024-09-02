using CSharpFunctionalExtensions;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Modules.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerHandler
    {
        private readonly IVolunteersRepository _repository;

        public CreateVolunteerHandler(IVolunteersRepository repository)
        {
            _repository = repository;
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

            if (fullNameResult.IsFailure) return fullNameResult.Error;

            var description = request.Description;
            var descriptionResult = LongString.Create(description);

            if (descriptionResult.IsFailure) return descriptionResult.Error;

            SocialNetworkList socialNetworksList = new(request.SocialNetworksDTO.Select(
                nw => SocialNetwork.Create(
                    nw.Name,
                    nw.Link)
                   .Value));

            RequisiteList requisitesList = new(request.RequisitesDTO.Select(
                r => Requisite.Create(r.Name,
                                    r.Description)
                                   .Value));


            var volunteerResult = Volunteer.Create(volunteerId,
                                                   fullNameResult.Value,
                                                   descriptionResult.Value,
                                                   request.YearsOfExperience,
                                                   request.PhoneNumber,
                                                   requisitesList,
                                                   socialNetworksList);

            if (volunteerResult.IsFailure) return volunteerResult.Error;
            var volunteer = volunteerResult.Value;
            await _repository.Add(volunteer);

            return (Guid)volunteer.Id;
        }

    }
}
