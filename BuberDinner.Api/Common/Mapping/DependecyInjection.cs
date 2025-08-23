using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping;
public static class DependecyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        config.Scan(typeof(DependecyInjection).Assembly);
        var mapper = new Mapper(config);
        services.AddSingleton(mapper);
        
        return services;
    }
}