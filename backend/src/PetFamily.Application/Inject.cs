using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.API.Controllers;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Application.Volunteers.UpdateSocialNetworks;
namespace PetFamily.Application
{
    public static class Inject
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateVolunteerHandler>();

            services.AddScoped<UpdateMainInfoHandler>();
            services.AddScoped<UpdateSocialNetworksHandler>();

            services.AddScoped<DeleteVolunteerHandler>();

            services.AddValidatorsFromAssembly(typeof(Inject).Assembly);
            return services;
        }
    }
}
