using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class MediaOwnerData
    {
        [JsonProperty("id")]
        public string UserId { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }
    }
}
