[![](https://img.shields.io/nuget/v/soenneker.plaid.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.plaid.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.plaid.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.plaid.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.plaid.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.plaid.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.plaid.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.plaid.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Plaid.OpenApiClientUtil

Provides a configured Plaid API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Plaid.OpenApiClientUtil
```

## Configuration

```json
{
  "Plaid": {
    "ClientId": "your-client-id",
    "Secret": "your-secret",
    "ClientBaseUrl": "https://sandbox.plaid.com"
  }
}
```

## Usage

```csharp
using Soenneker.Plaid.OpenApiClient.Models;
using Soenneker.Plaid.OpenApiClientUtil.Abstract;
using Soenneker.Plaid.OpenApiClientUtil.Registrars;

services.AddPlaidOpenApiClientUtilAsSingleton();

IPlaidOpenApiClientUtil plaid = serviceProvider
    .GetRequiredService<IPlaidOpenApiClientUtil>();

var client = await plaid.Get(cancellationToken);
var institutions = await client.Institutions.Get.PostAsync(
    new InstitutionsGetRequest
    {
        Count = 10,
        Offset = 0,
        CountryCodes = [CountryCode.US]
    },
    cancellationToken: cancellationToken);
```

Use `AddPlaidOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
