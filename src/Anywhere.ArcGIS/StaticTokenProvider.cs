using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anywhere.ArcGIS.Operation;

namespace Anywhere.ArcGIS
{
    public class StaticTokenProvider : ITokenProvider, IDisposable
    {
        public string RootUrl { get; set; }

        public ISerializer Serializer { get; set; }

        public ICryptoProvider CryptoProvider { get; set; }

        public string UserName { get; set; }

        private Token token { get; set; }

        public StaticTokenProvider(string rootURL, string token)
        {
            this.RootUrl = rootURL.AsRootUrl();
            CryptoProvider = CryptoProviderFactory.Get();
            UserName = "";
            Serializer = SerializerFactory.Get();
            this.token = new Token() { Value = token };
        }

        ~StaticTokenProvider()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.token = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<Token> CheckGenerateToken(CancellationToken ct)
        {
            return Task.Run(() => this.token);
        }
    }
}
