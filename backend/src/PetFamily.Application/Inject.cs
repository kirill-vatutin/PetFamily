using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.API.Controllers;
using PetFamily.Application.Test.AddFile;
using PetFamily.Application.Test.PresignedGetObject;
using PetFamily.Application.Test.RemoveFile;
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

            services.AddScoped<AddFileHandler>();
            services.AddScoped<RemoveFileHandler>();
            services.AddScoped<PresignedGetObjectHandler>();

            services.AddValidatorsFromAssembly(typeof(Inject).Assembly);
            return services;
        }
    }
}
