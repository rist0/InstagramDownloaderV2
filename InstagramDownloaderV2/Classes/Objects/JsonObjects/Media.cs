﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramDownloaderV2.Classes.Objects.JsonObjects
{
    public class Media
    {
        [JsonProperty("nodes")]
        public List<UserPhotoData> Nodes { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }

    public class UserPhotoData
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("comments_disabled")]
        public bool CommentsDisabled { get; set; }

        [JsonProperty("dimensions")]
        public MediaDimensions Dimensions { get; set; }

        [JsonProperty("owner")]
        public MediaOwnerData Owner { get; set; }

        [JsonProperty("thumbnail_src")]
        public string ThumbnailSrc { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("code")]
        public string ShortCode { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("display_src")]
        public string DisplaySrc { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("comments")]
        public FollowCountsObject Comments { get; set; }

        [JsonProperty("likes")]
        public FollowCountsObject Likes { get; set; }

        [JsonProperty("video_views")]
        public long VideoViews { get; set; }
    }
}