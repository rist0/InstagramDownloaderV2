using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class MediaDimensions
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
