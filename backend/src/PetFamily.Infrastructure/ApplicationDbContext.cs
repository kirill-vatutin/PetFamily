using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Models;

namespace PetFamily.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}
