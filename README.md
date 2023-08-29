# Blocktrade .NET Client
[![.NET](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/codeql-analysis.yml)

Development of this project has ceased as I kept getting unexplainable "Response status code does not indicate success: 400 (Bad Request)" errors when trying to use the private API.

<!--
You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.Blocktrade.Client --version *
-->

## Example

Below is an example listing all trading assets.

    using BlocktradeClient client = new();

    var tradingAssets = await client.GetTradingAssetsAsync();

    foreach (var tradingAsset in tradingAssets)
        Console.WriteLine($"Name: {{tradingAsset.FullName}}");