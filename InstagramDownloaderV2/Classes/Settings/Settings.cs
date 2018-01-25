using System;

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
        public bool RemoveEmoji { get; set; }
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

        public Settings(string userAgent, string requestTimeout, string proxy, string threads, string downloadFolder, bool createNewFolder, bool removeEmoji, bool saveStats, string delimiter, bool skipDescription, bool skipPhotos, bool skipVideos, bool skipLikes, string skipLikesMoreLess, string skipLikesCount, bool skipComments, string skipCommentsMoreLess, string skipCommentsCount, bool skipUploadDate, bool totalDownloadsEnabled, string totalDownloads)
        {
            UserAgent = userAgent;
            RequestTimeout = requestTimeout;
            Proxy = proxy;
            Threads = threads;
            DownloadFolder = downloadFolder;
            CreateNewFolder = createNewFolder;
            RemoveEmoji = removeEmoji;
            SaveStats = saveStats;
            Delimiter = delimiter;
            SkipDescription = skipDescription;
            SkipPhotos = skipPhotos;
            SkipVideos = skipVideos;
            SkipLikes = skipLikes;
            SkipLikesMoreLess = skipLikesMoreLess;
            SkipLikesCount = skipLikesCount;
            SkipComments = skipComments;
            SkipCommentsMoreLess = skipCommentsMoreLess;
            SkipCommentsCount = skipCommentsCount;
            SkipUploadDate = skipUploadDate;
            TotalDownloadsEnabled = totalDownloadsEnabled;
            TotalDownloads = totalDownloads;
        }
    }
}