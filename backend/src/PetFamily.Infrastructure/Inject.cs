using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using PetFamily.Application.FileProviders;
using PetFamily.Application.Volunteers;
using PetFamily.Infrastructure.Options;
using PetFamily.Infrastructure.Providers;
using PetFamily.Infrastructure.Repositories;

namespace PetFamily.Infrastructure
{
    public static class Inject
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ApplicationDbContext>();
            //services.AddSingleton<SoftDeleteInterceptor>();

            services.AddScoped<IVolunteersRepository, VolunteersRepository>();
            services.AddScoped<IFileProvider, MinioProviders>();

            services.AddMinio(options =>
            {
                var minioOptions = configuration.GetSection(MinioOptions.MINIO).Get<MinioOptions>()
                    ?? throw new ApplicationException("Missing minio configuration");

                options.WithEndpoint(minioOptions.Endpoint)
                       .WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey)
                       .WithSSL(false);
            });

            return services;
        }
    }
}
