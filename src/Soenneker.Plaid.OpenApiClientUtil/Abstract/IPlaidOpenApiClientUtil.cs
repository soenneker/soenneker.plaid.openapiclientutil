using Soenneker.Plaid.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Plaid.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IPlaidOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<PlaidOpenApiClient> Get(CancellationToken cancellationToken = default);
}
