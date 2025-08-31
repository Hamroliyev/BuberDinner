using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application.Services.Authetication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        
        return services;
    } 
}