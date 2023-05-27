using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PantryTracker.Services.PantryItems;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IPantryItemService, PantryItemService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
    });
    app.Run();
}