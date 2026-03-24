using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Plaid.HttpClients.Registrars;
using Soenneker.Plaid.OpenApiClientUtil.Abstract;

namespace Soenneker.Plaid.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class PlaidOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="PlaidOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPlaidOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddPlaidOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IPlaidOpenApiClientUtil, PlaidOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PlaidOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPlaidOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddPlaidOpenApiHttpClientAsSingleton()
                .TryAddScoped<IPlaidOpenApiClientUtil, PlaidOpenApiClientUtil>();

        return services;
    }
}
