using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class Location
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("has_public_page")]
        public bool HasPublicPage { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("media")]
        public Media Media { get; set; }

        [JsonProperty("top_posts")]
        public Media TopPosts { get; set; }
    }
}
