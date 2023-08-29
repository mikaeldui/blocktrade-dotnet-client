using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Blocktrade.Security
{
    internal static class SignatureGenerator
    {
        [Pure]
        public static string GenerateSignature(string apiKey, string apiSecret, string nonce, string? requestBody)
        {
            var message = apiKey + "." + nonce;

            if (requestBody != null && !string.IsNullOrWhiteSpace(requestBody))
            {
                message += "." + requestBody;
            }

            using var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret));
            var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "").ToUpper();
        }
    }
}
