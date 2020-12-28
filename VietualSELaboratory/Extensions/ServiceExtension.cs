using Domain.Services.Implementation;
using Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace VietualSELaboratory.ServiceExtension
{
    public static class ServiceExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IExerciseService, ExerciseService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(Domain.RDBMS.IRepository<>), typeof(Domain.RDBMS.Repository.BaseRepository<>));
        }
    }
}
