using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class Hashtag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_top_media_only")]
        public bool IsTopMediaOnly { get; set; }

        [JsonProperty("edge_hashtag_to_media")]
        public EdgeHashtagToMedia EdgeHashtagToMedia { get; set; }

        [JsonProperty("edge_hashtag_to_top_posts")]
        public EdgeHashtagToTopPosts EdgeHashtagToTopPosts { get; set; }
    }

    public class EdgeHashtagToMedia
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("edges")]
        public List<EdgeHashtagToMediaEdge> Edges { get; set; }
    }

    public class EdgeHashtagToMediaEdge
    {
        [JsonProperty("node")]
        public HashtagPhotoData Node { get; set; }
    }

    // Posts
    public class HashtagPhotoData
    {
        [JsonProperty("comments_disabled")]
        public bool? CommentsDisabled { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("edge_media_to_caption")]
        public CaptionEdge CaptionEdge { get; set; }

        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("edge_media_to_comment")]
        public StatsCount Comments { get; set; }

        [JsonProperty("taken_at_timestamp")]
        public long TakenAtTimestamp { get; set; }

        [JsonProperty("dimensions")]
        public MediaDimensions Dimensions { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("edge_liked_by")]
        public StatsCount Likes { get; set; }

        //[JsonProperty("owner")]
        //public Owner Owner { get; set; }

        [JsonProperty("thumbnail_src")]
        public string ThumbnailSrc { get; set; }

        //[JsonProperty("thumbnail_resources")]
        //public List<ThumbnailResource> ThumbnailResources { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("video_view_count")]
        public long VideoViewCount { get; set; }
    }

    // Caption
    public class CaptionEdge
    {
        [JsonProperty("edges")]
        public List<CaptionTextEdge> CaptionTextEdge { get; set; }
    }

    public class CaptionTextEdge
    {
        [JsonProperty("node")]
        public CaptionText CaptionText { get; set; }
    }

    public class CaptionText
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    // Top posts
    public class EdgeHashtagToTopPosts
    {
        [JsonProperty("edges")]
        public List<EdgeHashtagToMediaEdge> Edges { get; set; }
    }
}
