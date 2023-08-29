using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Blocktrade.Security
{
    internal class BlocktradeHttpMessageHandler : DelegatingHandler
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public BlocktradeHttpMessageHandler(string apiKey, string apiSecret) 
        {
            InnerHandler = new HttpClientHandler();
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string? content = null;
            if (request.Content != null) content = await request.Content.ReadAsStringAsync();            
            var nonce = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var signature = SignatureGenerator.GenerateSignature(_apiKey, _apiSecret, nonce, content);

            request.Headers.Add("X-Api-Key", _apiKey);
            request.Headers.Add("X-Nonce", nonce);
            request.Headers.Add("X-Signature", signature);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
