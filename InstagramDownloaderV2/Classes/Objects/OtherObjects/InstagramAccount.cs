using System.Net;

namespace InstagramDownloaderV2.Classes.Objects.OtherObjects
{
    class InstagramAccount
    {
        private readonly string _username;
        private readonly string _password;
        private readonly WebProxy _proxy;

        public string Username => _username;
        public string Password => _password;
        public WebProxy Proxy => _proxy;

        public InstagramAccount(string username, string password, WebProxy proxy)
        {
            _username = username;
            _password = password;
            _proxy = proxy;
        }
    }
}
