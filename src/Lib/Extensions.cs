using Lib.Abstractions;
using Lib.Consumers;
using Lib.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Data.SqlTypes;

namespace Lib;

public static class Extensions
{
    public static IServiceCollection AddControllerConsumers(this IServiceCollection services, string? apiUrl)
    {
        if (apiUrl == null)
        {
            throw new ArgumentNullException(nameof(apiUrl), "URL string cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(apiUrl))
        {
            throw new ArgumentException("URL string cannot be empty or whitespace.", nameof(apiUrl));
        }

        services.AddRefitClient<IApiService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiUrl))
            .AddHttpMessageHandler(() => new BearerTokenHandler(GetToken));
        services.AddScoped<IBooksControllerConsumer, BooksControllerConsumer>();
        services.AddScoped<IOrdersControllerConsumer, OrdersControllerConsumer>();
        return services;
    }

    private static Task<string> GetToken()
    {
        return Task.FromResult("test_token");
    }
}
