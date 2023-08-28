using System.Diagnostics.Tracing;
using System.Net.Http.Json;
using System.Text.Json;

namespace Blocktrade
{
    public class BlocktradeClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = Chubrik.Json.JsonNamingPolicies.SnakeLowerCase,
        };

        public BlocktradeClient() 
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://trade.blocktrade.com/api/v1/")
            };
        }

        public async Task<TradingAsset[]?> GetTradingAssetsAsync() => await _httpClient.GetFromJsonAsync<TradingAsset[]>("trading_assets", _jsonSerializerOptions);

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}