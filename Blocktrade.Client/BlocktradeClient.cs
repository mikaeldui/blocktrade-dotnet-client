using System.Diagnostics.Tracing;
using System.Net.Http.Json;
using System.Text.Json;
using Blocktrade.Security;

namespace Blocktrade
{
    public partial class BlocktradeClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}