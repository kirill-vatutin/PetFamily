using CSharpFunctionalExtensions;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers
{
    public interface IVolunteersRepository
    {
        Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
        Task<Guid> Delete(Volunteer value, CancellationToken cancellationToken);
        Task<Result<Volunteer,Error>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default);
        Task<Guid> SaveAsync(Volunteer value, CancellationToken cancellationToken = default);
    }
}