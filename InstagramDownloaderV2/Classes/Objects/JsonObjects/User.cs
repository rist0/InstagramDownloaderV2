using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class User
    {
        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("external_url")]
        public object ExternalUrl { get; set; }

        [JsonProperty("external_url_linkshimmed")]
        public object ExternalUrlLinkshimmed { get; set; }

        [JsonProperty("edge_followed_by")]
        public FollowCountsObject FollowedBy { get; set; }

        [JsonProperty("edge_follow")]
        public FollowCountsObject Follows { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("profile_pic_url_hd")]
        public string ProfilePicUrlHd { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("edge_owner_to_timeline_media")]
        public Media Media { get; set; }
    }

    public class FollowCountsObject
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
