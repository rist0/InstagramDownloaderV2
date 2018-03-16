using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InstagramDownloaderV2.Classes.Objects.JsonObjects;
using InstagramDownloaderV2.Classes.Objects.OtherObjects;
using InstagramDownloaderV2.Classes.Requests;
using InstagramDownloaderV2.Enums;
using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Downloader
{
    internal class JsonParser
    {
        private readonly string _userAgent;
        private readonly WebProxy _proxy;
        private readonly double _requestTimeout;
        private readonly CookieContainer _cookies;

        public JsonParser(string userAgent, WebProxy proxy, double requestTimeout, CookieContainer cookies)
        {
            _userAgent = userAgent;
            _proxy = proxy;
            _requestTimeout = requestTimeout;
            _cookies = cookies;
        }

        public async Task<RootObject> GetRootObjectAsync(string input, InputType inputType, string maxId = "")
        {
            string response;

            switch (inputType)
            {
                case InputType.Url:
                    using (Request request = new Request(_userAgent, _proxy, _requestTimeout, _cookies))
                    {
                        response = await request.GetRequestStringAsync(input);
                    }
                    break;
                case InputType.Username:
                    using (Request request = new Request(_userAgent, _proxy, _requestTimeout, _cookies))
                    {
                        response = await request.GetRequestStringAsync($"{Globals.BASE_URL}/graphql/query/?query_id=17888483320059182&id={input}&first=12&after={maxId}");
                    }
                    break;
                case InputType.Hashtag:
                    using (Request request = new Request(_userAgent, _proxy, _requestTimeout, _cookies))
                    {
                        response = await request.GetRequestStringAsync($"{Globals.BASE_URL}/explore/tags/{input}/?max_id={maxId}");
                    }
                    break;
                case InputType.Location:
                    using (Request request = new Request(_userAgent, _proxy, _requestTimeout, _cookies))
                    {
                        response = await request.GetRequestStringAsync($"{Globals.BASE_URL}/explore/locations/{input}/?max_id={maxId}");
                    }
                    break;
                default:
                    throw new Exception("Failed to determine input type");
            }

            RootObject photoData = inputType != InputType.Username ? ParsePhotoData(response) : JsonConvert.DeserializeObject<RootObject>(response);

            return photoData;
        }

        public async Task<string> GetUserIdAsync(string input)
        {
            using (var request = new Request(_userAgent, _proxy, _requestTimeout, _cookies))
            {
                var response = await request.GetRequestStringAsync($"{Globals.BASE_URL}/{input}");

                return ParsePhotoData(response).MediaEntryData.ProfilePage?[0].Graphql.User.Id;
            }
        }

        private RootObject ParsePhotoData(string response)
        {
            string regex = "<script type=\"text/javascript\">window._sharedData = (.*?);</script>";
            string json = Regex.Match(response, regex).Groups[1].Value;

            var photoData = JsonConvert.DeserializeObject<RootObject>(json);

            return photoData;
        }
    }
}
