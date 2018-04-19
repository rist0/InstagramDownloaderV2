using System;
using System.IO;

namespace InstagramDownloaderV2.Classes.Settings
{
    [Serializable]
    class Settings
    {
        // Web settings
        public string UserAgent { get; set; }
        public string RequestTimeout { get; set; }
        public string Proxy { get; set; }
        public string Threads { get; set; }

        // Download settings
        public string DownloadFolder { get; set; }
        public bool CreateNewFolder { get; set; }
        public bool SaveStats { get; set; }
        public string Delimiter { get; set; }

        // Filters
        public bool SkipDescription { get; set; }
        public bool SkipPhotos { get; set; }
        public bool SkipVideos { get; set; }
        public bool SkipLikes { get; set; }
        public string SkipLikesMoreLess { get; set; }
        public string SkipLikesCount { get; set; }
        public bool SkipComments { get; set; }
        public string SkipCommentsMoreLess { get; set; }
        public string SkipCommentsCount { get; set; }
        public bool SkipUploadDate { get; set; }
        public bool TotalDownloadsEnabled { get; set; }
        public string TotalDownloads { get; set; }
        public bool SkipTopPosts { get; set; }

        // Instagram account
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public bool HidePassword { get; set; }

        // Instagram API
        public Stream StateData { get; set; }
    }
}