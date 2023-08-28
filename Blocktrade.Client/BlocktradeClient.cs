using System.Diagnostics.Tracing;
using System.Net.Http.Json;
using System.Text.Json;

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

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}