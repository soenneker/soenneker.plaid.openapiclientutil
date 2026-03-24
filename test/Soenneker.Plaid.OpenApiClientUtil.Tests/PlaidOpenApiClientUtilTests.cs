using Soenneker.Plaid.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Plaid.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class PlaidOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IPlaidOpenApiClientUtil _openapiclientutil;

    public PlaidOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IPlaidOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
