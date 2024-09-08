﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Volunteers.CreateVolunteer;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
namespace PetFamily.Application
{
    public static class Inject
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateVolunteerHandler>();

            services.AddValidatorsFromAssembly(typeof(Inject).Assembly);
            return services;
        }
    }
}
