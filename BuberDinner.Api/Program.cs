using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application.Services.Authetication;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplicationServices()
        .AddInfrastructureServices(builder.Configuration);

    // builder.Services.AddControllers(options =>
    // {
    //     options.Filters.Add<ErrorHandlingFilterAttribute>();
    // });
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");

    app.Map("/error", (HttpContext context) =>
    {
        Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Results.Problem();
    });

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
