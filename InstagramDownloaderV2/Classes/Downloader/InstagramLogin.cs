using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InstagramDownloaderV2.Classes.Objects.OtherObjects;

namespace InstagramDownloaderV2.Classes.Downloader
{
    class InstagramLogin
    {
        private readonly InstagramAccount _instagramAccount;
        private readonly string _userAgent;
        private readonly double _requestTimeout;

        public InstagramLogin(InstagramAccount instagramAccount, string userAgent, double requestTimeout)
        {
            _instagramAccount = instagramAccount;
            _userAgent = userAgent;
            _requestTimeout = requestTimeout;
        }

        public async Task<CookieContainer> Login()
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.Proxy = _instagramAccount.Proxy;
                using (HttpClient client = new HttpClient(handler))
                {
                    client.Timeout = TimeSpan.FromSeconds(_requestTimeout);
                    client.DefaultRequestHeaders.Add("User-Agent", _userAgent);

                    var response = await client.GetStringAsync("https://www.instagram.com/");
                    var csrfToken = Regex.Match(response, "csrf_token\": \"(.*?)\"").Groups[1].Value;
                    //Console.WriteLine(csrfToken);

                    client.DefaultRequestHeaders.Host = "www.instagram.com";
                    client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                    client.DefaultRequestHeaders.Add("Origin", "https://www.instagram.com");
                    client.DefaultRequestHeaders.Add("X-Instagram-AJAX", "1");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                    client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    client.DefaultRequestHeaders.Add("X-CSRFToken", csrfToken);
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                    client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.DefaultRequestHeaders.Referrer = new Uri("https://www.instagram.com/");

                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://www.instagram.com/accounts/login/ajax/")
                    //{
                    //    Content = new StringContent($"username={_instagramAccount.Username}&password={_instagramAccount.Password}", Encoding.UTF8, "application/x-www-form-urlencoded")
                    //};

                    //var result = await client.SendAsync(request);

                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", _instagramAccount.Username),
                        new KeyValuePair<string, string>("password", _instagramAccount.Password)
                    });

                    var postResponse = await client.PostAsync(new Uri("https://www.instagram.com/accounts/login/ajax/"), content);

                    //string res = await result.Content.ReadAsStringAsync();
                    string res = await postResponse.Content.ReadAsStringAsync();
                    if (!res.Contains("authenticated\": false")) return handler.CookieContainer;

                    //Console.WriteLine(res);
                }
            }

            return null;
        }
    }
}
