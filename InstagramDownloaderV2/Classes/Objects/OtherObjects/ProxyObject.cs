using System;
using System.Net;

namespace InstagramDownloaderV2.Classes.Objects.OtherObjects
{
    class ProxyObject
    {
        private readonly string _ipAddress;
        private readonly string _port;
        private readonly string _authUsername;
        private readonly string _authPassword;

        public ProxyObject(string proxy, char delimiter)
        {
            if (proxy.Split(delimiter).Length >= 2)
            {
                _ipAddress = proxy.Split(delimiter)[0];
                _port = proxy.Split(delimiter)[1];
                if (proxy.Split(delimiter).Length == 4)
                {
                    _authUsername = proxy.Split(delimiter)[2];
                    _authPassword = proxy.Split(delimiter)[3];
                }
            }
        }
        
        public ProxyObject(string ipAddress, string port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public ProxyObject(string ipAddress, string port, string authUsername, string authPassword)
        {
            _ipAddress = ipAddress;
            _port = port;
            _authUsername = authUsername;
            _authPassword = authPassword;
        }

        public WebProxy GetWebProxy()
        {
            if (Uri.IsWellFormedUriString($"http://{_ipAddress}:{_port}", UriKind.Absolute))
            {
                return new WebProxy($"{_ipAddress}:{_port}")
                {
                    Credentials = new NetworkCredential(_authUsername, _authPassword)
                };
            }

            return null;
        }
    }
}
