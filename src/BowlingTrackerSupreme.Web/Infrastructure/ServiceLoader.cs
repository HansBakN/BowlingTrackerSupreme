using BowlingTrackerSupreme.Web.Services;

namespace BowlingTrackerSupreme.Web.Infrastructure
{
    public static class ServiceFactory
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPlayerService, PlayerService>();

            return services;
        }
    }
}
