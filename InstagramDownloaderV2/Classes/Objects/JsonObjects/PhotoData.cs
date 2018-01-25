using System.Collections.Generic;
using InstagramDownloaderV2.Enums;
using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class PhotoData
    {
        [JsonProperty("__typename")]
        public string TypeName { get; set; }

        [JsonProperty("id")]
        public string MediaId { get; set; }

        [JsonProperty("shortcode")]
        public string MediaShortCode { get; set; }

        [JsonProperty("dimensions")]
        public MediaDimensions MediaDimensions { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty("video_view_count")]
        public long VideoViewCount { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("edge_media_to_caption")]
        public MediaCaption Caption { get; set; }

        [JsonProperty("caption_is_edited")]
        public bool CaptionIsEdited { get; set; }

        [JsonProperty("edge_media_to_comment")]
        public StatsCount Comments { get; set; }

        [JsonProperty("comments_disabled")]
        public bool CommentsDisabled { get; set; }

        [JsonProperty("taken_at_timestamp")]
        public int UploadTimestamp { get; set; }

        [JsonProperty("edge_media_preview_like")]
        public StatsCount Likes { get; set; }

        [JsonProperty("location")]
        public LocationData Location { get; set; }

        [JsonProperty("owner")]
        public MediaOwnerData Owner { get; set; }

        [JsonProperty("is_ad")]
        public bool IsAd { get; set; }

        public MediaType MediaType
        {
            get
            {
                if (TypeName.Contains("Image"))
                    return MediaType.Image;
                if (TypeName.Contains("Video"))
                    return MediaType.Video;
                if (TypeName.Contains("Sidecar"))
                    return MediaType.Story;
                return MediaType.Unknown;
            }
        }
        
        public class MediaCaption
        {
            [JsonProperty("edges")]
            public List<Edge> Edges { get; set; }
        }

        public class Edge
        {
            [JsonProperty("node")]
            public Node Node { get; set; }
        }

        public class Node
        {
            [JsonProperty("text")]
            public string CaptionText { get; set; }
        }
    }
}
