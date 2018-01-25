using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class LocationData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("has_public_page")]
        public bool HasPublicPage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
