using System.Diagnostics.Tracing;
using System.Net.Http.Json;
using System.Text.Json;
using Blocktrade.Security;

namespace Blocktrade
{
    public partial class BlocktradeClient : IDisposable
    {
        private const uint OFFSET_DEFAULT = 0;
        private const uint OFFSET_MAXIMUM_EXCL_LIMIT = 100000;
        private const ushort LIMIT_DEFAULT = 10;
        private const ushort LIMIT_MAXIMUM = 1000;

        private readonly HttpClient _httpClient;

        public void Dispose() => ((IDisposable)_httpClient).Dispose();

        private void _ensureLimit(ushort limit)
        {
            if (limit > 1000)
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit must be 1,000 or less.");
        }

        private void _ensureOffsetAndLimit(uint offset, ushort limit)
        {
            _ensureLimit(limit);

            if (offset > OFFSET_MAXIMUM_EXCL_LIMIT - limit)
                throw new ArgumentOutOfRangeException(nameof(offset), "Offset must be less than 100,000 minus limit.");
        }
    }
}