using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class RootObject
    {
        [JsonProperty("entry_data")]
        public MediaEntryData MediaEntryData { get; set; }
    }

    public class MediaEntryData
    {
        [JsonProperty("PostPage")]
        public List<PostPage> MediaPostPage { get; set; }

        [JsonProperty("ProfilePage")]
        public List<ProfilePage> ProfilePage { get; set; }

        [JsonProperty("TagPage")]
        public List<PostPage> HashtagPage { get; set; }

        [JsonProperty("LocationsPage")]
        public List<LocationsPage> LocationsPage { get; set; }
    }

    // For single photo page
    public class PostPage
    {
        [JsonProperty("graphql")]
        public GraphMedia GraphMedia { get; set; }
    }

    public class GraphMedia
    {
        // For single media
        [JsonProperty("shortcode_media")]
        public PhotoData MediaDetails { get; set; }

        // For hashtag page
        [JsonProperty("hashtag")]
        public Hashtag Hashtag { get; set; }
    }

    // For profile page
    public class ProfilePage
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }

    // For location page
    public class LocationsPage
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
