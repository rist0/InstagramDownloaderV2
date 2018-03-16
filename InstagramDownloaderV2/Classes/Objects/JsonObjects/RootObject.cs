using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class RootObject
    {
        [JsonProperty("entry_data")]
        public MediaEntryData MediaEntryData { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("user")]
        public UserMedia UserMedia { get; set; }
    }

    public class UserMedia
    {
        [JsonProperty("edge_owner_to_timeline_media")]
        public Media Media { get; set; }
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
        [JsonProperty("graphql")]
        public Graphql Graphql { get; set; }
    }

    public class Graphql
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
