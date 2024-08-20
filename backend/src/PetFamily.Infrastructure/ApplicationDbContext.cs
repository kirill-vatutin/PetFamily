using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Models;
using PetFamily.Domain.Modules;

namespace PetFamily.Infrastructure
{
    public class ApplicationDbContext(IConfiguration configuration):DbContext
    {
        private const string DATABASE = "Database";
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE));
        }

        private ILoggerFactory CreateLoggerFactory() =>
             LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
