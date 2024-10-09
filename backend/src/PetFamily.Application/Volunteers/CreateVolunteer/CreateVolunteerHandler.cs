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

            return (Guid)volunteer.Id;
        }

    }
}
