﻿



using PetFamily.Application.Volunteers;
using PetFamily.Domain.Modules.Entities.Aggregates;

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

    }
}
