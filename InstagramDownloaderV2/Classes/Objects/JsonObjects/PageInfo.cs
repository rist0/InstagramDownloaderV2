using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class PageInfo
    {
        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("end_cursor")]
        public string EndCursor { get; set; }
    }
}
