using BuberDinner.Application.Services.Authetication;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplicationServices()
        .AddInfrastructureServices(builder.Configuration);
        
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
