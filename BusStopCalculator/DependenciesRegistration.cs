using BusStopCalculator.BLL.Mappers;
using BusStopCalculator.BLL.Services;
using BusStopCalculator.DAL.Repositories;

namespace BusStopCalculator;

// Common DependenciesRegistration for all layers, could be separated to reduce dependencies between layers
internal static class DependenciesRegistration
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        // PL dependencies

        // BLL dependencies
        services.AddSingleton<IBusStationMapper, BusStationMapper>();
        services.AddTransient<IBusStationService, BusStationService>();
        services.AddTransient<IBusStationCalculationService, BusStationCalculationService>();

        // DAL dependencies
        services.AddSingleton<IBusStationRepository, BusStationRepository>();
    }
}
