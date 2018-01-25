using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class StatsCount
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
