using Blocktrade.Json;
using Blocktrade.Security;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Blocktrade
{
    public partial class BlocktradeClient
    {

        private readonly string? _apiKey;

        public BlocktradeClient(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient(new BlocktradeHttpMessageHandler(apiKey, apiSecret), true)
            {
                BaseAddress = new Uri("https://trade.blocktrade.com/api/v1/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<User?> GetUserAsync()
        {
            _ensureApiKey();
            return await _httpClient.GetFromJsonAsync<User>("user", BlocktradeJsonSerializerOptions.Default);
        }

        public async Task<FeeType?> GetFeesAsync()
        {
            _ensureApiKey();
            return await _httpClient.GetFromJsonAsync<FeeType>("fees", BlocktradeJsonSerializerOptions.Default);
        }

        public async Task<UserOrders?> GetOrdersAsync(uint offset = OFFSET_DEFAULT, ushort limit = LIMIT_DEFAULT, IEnumerable<string>? statuses = null, IEnumerable<string>? types = null, IEnumerable<int>? tradingPairIds = null)
        {
            _ensureApiKey();
            _ensureOffsetAndLimit(offset, limit);
            return await _httpClient.GetFromJsonAsync<UserOrders>($"orders?offset={offset}&limit={limit}", BlocktradeJsonSerializerOptions.Default);
        }

        private void _ensureApiKey()
        {
            if (_apiKey == null)
            {
                throw new InvalidOperationException("Private API requires an API key that has not been specified. Please create a new instance of BlocktradeClient and supply an API key.");
            }
        }
    }
}
