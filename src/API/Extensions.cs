using API.Abstractions;
using API.Repositories;
using API.Services;
using Application.Services;
using Infrastructure.Repositories;

namespace API;

public static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IBookRepository, InMemeoryBookRepository>();
        services.AddScoped<IOrderRepository, InMemeoryOrderRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
}
