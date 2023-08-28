using System.Diagnostics.Tracing;
using System.Net.Http.Json;
using System.Text.Json;
using Blocktrade.Security;

namespace Blocktrade
{
    public partial class BlocktradeClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public BlocktradeClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://trade.blocktrade.com/api/v1/")
            };
        }

        public BlocktradeClient(string apiKey, string apiSecret)
        {
            _httpClient = new HttpClient(new BlocktradeHttpMessageHandler(apiKey, apiSecret), true)
            {
                BaseAddress = new Uri("https://trade.blocktrade.com/api/v1/")
            };
        }

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}