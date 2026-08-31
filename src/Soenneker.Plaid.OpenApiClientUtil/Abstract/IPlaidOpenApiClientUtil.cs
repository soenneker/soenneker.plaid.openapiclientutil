using Soenneker.Plaid.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Plaid.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached, authenticated client for the Plaid API.
/// </summary>
public interface IPlaidOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the generated client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The cached Plaid client.</returns>
    ValueTask<PlaidOpenApiClient> Get(CancellationToken cancellationToken = default);
}
