using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Plaid.HttpClients.Abstract;
using Soenneker.Plaid.OpenApiClientUtil.Abstract;
using Soenneker.Plaid.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Plaid.OpenApiClientUtil;

public sealed class PlaidOpenApiClientUtil : IPlaidOpenApiClientUtil
{
    private readonly AsyncSingleton<PlaidOpenApiClient> _client;

    public PlaidOpenApiClientUtil(IPlaidOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<PlaidOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

            return new PlaidOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<PlaidOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
