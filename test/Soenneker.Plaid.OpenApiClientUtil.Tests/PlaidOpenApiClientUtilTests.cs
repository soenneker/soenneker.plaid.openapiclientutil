using Soenneker.Plaid.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Plaid.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PlaidOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IPlaidOpenApiClientUtil _openapiclientutil;

    public PlaidOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IPlaidOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
