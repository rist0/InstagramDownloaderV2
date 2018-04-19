using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramDownloaderV2.Classes.Requests
{
    class Request : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClientHandler _httpClientHandler;

        public Request(string userAgent, IWebProxy proxy, double requestTimeout)
        {
            _httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy
            };

            _httpClient = new HttpClient(_httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(requestTimeout)
            };

            _httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
        }

        public async Task<HttpResponseMessage> GetRequestResponseAsync(string url)
        {
            var message = await _httpClient.GetAsync(url);
            return message;
        }

        public async Task<string> GetRequestStringAsync(string url)
        {
            using (var message = await _httpClient.GetAsync(url))
            {
                return await message.Content.ReadAsStringAsync();
            }
        }

        public async Task<Stream> GetStreamAsync(string url)
        {
            using (var stream = await _httpClient.GetStreamAsync(url))
            {
                return stream;
            }
        }

        public async Task<byte[]> GetByteArrayAsync(string url)
        {
            var bytes = await _httpClient.GetByteArrayAsync(url);
            return bytes;
        }

        public async Task<bool> IsSuccessStatusCodeAsync(string url)
        {
            using (var message = await _httpClient.GetAsync(url))
            {
                return message.IsSuccessStatusCode;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _httpClient.Dispose();
                    _httpClientHandler.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Request() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
