using System.Diagnostics.Tracing;
using System.Net.Http.Json;

namespace Blocktrade
{
    public class BlocktradeClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public BlocktradeClient() 
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://trade.blocktrade.com/api/v1/")
            };
        }

        public async Task<TradingAsset[]?> GetTradingAssetsAsync() => await _httpClient.GetFromJsonAsync<TradingAsset[]>("trading_assets");

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}