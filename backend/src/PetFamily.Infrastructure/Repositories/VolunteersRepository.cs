



using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Modules.Entities.Aggregates;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Repositories
{
    public class VolunteersRepository : IVolunteersRepository
    {
        private readonly ApplicationDbContext _context;

        public VolunteersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(volunteer, cancellationToken);
            await _context.SaveChangesAsync();
            return volunteer.Id;
        }

        public async Task<Guid> SaveAsync(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            _context.Volunteers.Attach(volunteer);
            await _context.SaveChangesAsync();
            return volunteer.Id.Value;
        }

        public async Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId,CancellationToken cancellationToken = default)
        {
            var volunteer = await _context.Volunteers
                .FirstOrDefaultAsync(v=>v.Id ==volunteerId);

            if (volunteer is null)
            {
                return Errors.General.NotFound(volunteerId);
            }
            return volunteer;
                
        }
    }
}
