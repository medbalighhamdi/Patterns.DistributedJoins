using DistributedJoins.Api.Dtos;
using DistributedJoins.Domain.Ports.Adapters.Interfaces;
using DistributedJoins.Domain.Ports.DistributedJoins.Product.Interfaces;
using DistributedJoins.Domain.Ports.Repositories.Interfaces;
using DistributedJoins.Infrastructure.Adapters;
using DistributedJoins.Infrastructure.DistributedJoins.JoinControllers.Product;
using DistributedJoins.Services;
using DistributedJoins.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


#region service registrations

var services = builder.Services;
RegisterRepositories(services);
RegisterAdapters(services);
RegisterDistributedJoins(services);
RegisterServices(services);

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/products", async (IProductService productService, CancellationToken cancellationToken) =>
{
    var applicationCards = await productService.GetCards(cancellationToken);
    return applicationCards.Select(applicationCard => new CardDto(applicationCard));
})
.WithName("GetDistributedProductData");

app.Run();

public static partial class Program
{

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, MockProductRepository>();
    }

    private static void RegisterAdapters(IServiceCollection services)
    {
        services.AddScoped<IUserAdapter, MockUserAdapter>();
        services.AddScoped<IRatingAdapter, MockRatingAdapter>();
    }

    private static void RegisterDistributedJoins(IServiceCollection services)
    {
        services.AddScoped<IProductUserJoiner, ProductUserJoiner>();
        services.AddScoped<IProductRatingJoiner, ProductRatingJoiner>();
        services.AddScoped<IProductJoinController, ProductJoinController>();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}
