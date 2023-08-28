# Blocktrade .NET Client
[![.NET](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/blocktrade-dotnet-client/actions/workflows/codeql-analysis.yml)


You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.Blocktrade.Client --version *


## Example

Below is an example listing all trading assets.

    using BlocktradeClient client = new();

    var tradingAssets = await client.GetTradingAssetsAsync();

    foreach (var tradingAsset in tradingAssets)
        Console.WriteLine($"Name: {{tradingAsset.FullName}}");