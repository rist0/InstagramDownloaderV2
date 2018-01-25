using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using InstagramDownloaderV2.Classes.CSV;
using InstagramDownloaderV2.Classes.Objects.JsonObjects;
using InstagramDownloaderV2.Classes.Objects.OtherObjects;
using InstagramDownloaderV2.Classes.Requests;
using InstagramDownloaderV2.Classes.Validation;
using InstagramDownloaderV2.Enums;

namespace InstagramDownloaderV2.Classes.Downloader
{
    class InstagramDownload
    {
#region Variables and properties
        // Download settings
        private readonly string _downloadFolder;
        private CancellationToken _cancellationToken;
        private int _totalCount;

        // Request params
        private readonly string _userAgent;
        private readonly WebProxy _proxy;
        private readonly double _requestTimeout;
        private readonly CookieContainer _cookies;

        // Json Parser
        private readonly JsonParser _jsonParser;

        // Csv Writer
        private readonly CsvWriter _csvWriter;
        private readonly string _statsDirectory;
        private readonly char _delimiter;

        // Properties
        public InputType InputType { get; set; }
        public bool IsTotalDownloadsEnabled { get; set; }
        public int TotalDownloads { get; set; }
        public bool CustomFolder { get; set; }
#endregion

#region Constructor
        public InstagramDownload(string userAgent, WebProxy proxy, double requestTimeout, string downloadFolder, CancellationToken cancellationToken, CookieContainer cookies, char csvFileDelimiter)
        {
            _downloadFolder = downloadFolder;
            _cancellationToken = cancellationToken;
            _totalCount = 0;

            _userAgent = userAgent;
            _proxy = proxy;
            _requestTimeout = requestTimeout;
            _cookies = cookies;

            _jsonParser = new JsonParser(userAgent, proxy, requestTimeout, cookies);

            _delimiter = csvFileDelimiter;
            _csvWriter = new CsvWriter(_delimiter);
            _statsDirectory = downloadFolder + @"\stats";
            if (!Directory.Exists(_statsDirectory)) Directory.CreateDirectory(_statsDirectory);
        }
#endregion

#region Methods
        public async Task Download(string input, InputType inputType, MediaFilter mediaFilter, string downloadLimit = "0")
        {
            if (!InputValidation.IsInt(downloadLimit)) return;

            switch (inputType)
            {
                case InputType.Url:
                    await DownloadUrlPhotoAsync(input, mediaFilter);
                    break;
                case InputType.Username:
                    await DownloadUserPhotosAsync(input, mediaFilter, int.Parse(downloadLimit));
                    break;
                case InputType.Hashtag:
                    await DownloadHashtagPhotosAsync(input, mediaFilter, int.Parse(downloadLimit));
                    break;
                case InputType.Location:
                    await DownloadLocationPhotosAsync(input, mediaFilter, int.Parse(downloadLimit));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }

        private async Task DownloadUrlPhotoAsync(string input, MediaFilter mediaFilter)
        {
            try
            {
                string statsFile = $@"{_statsDirectory}\urls.csv";

                if(!File.Exists(statsFile)) _csvWriter.WriteHeader(statsFile, false);

                var rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Url);

                if (rootObject.MediaEntryData.MediaPostPage == null) return;

                var downloadLink = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.IsVideo ?
                    rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoUrl :
                    rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.DisplayUrl;

                var mediaId = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.MediaId;

                var shortCode = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.MediaShortCode;
                var displayUrl = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.DisplayUrl;
                var captionText = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.Caption.Edges[0].Node.CaptionText.Replace('\n', ' ');
                var likes = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.Likes.Count;
                var comments = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.Comments.Count;
                var isVideo = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.IsVideo;
                var videoViews = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoViewCount;
                var commentsDisabled = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.CommentsDisabled;
                var uploadDate = DateTimeOffset.FromUnixTimeSeconds(rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.UploadTimestamp).ToLocalTime();
                var dimensions =
                    $"W:{rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.MediaDimensions.Width} " +
                    $"H:{rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.MediaDimensions.Height}";

                string extension;
                switch (rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.MediaType)
                {
                    case MediaType.Image:
                        extension = "jpg";
                        break;
                    case MediaType.Video:
                        extension = "mp4";
                        break;
                    case MediaType.Story:
                        extension = "jpg";
                        break;
                    default:
                        throw new Exception("Couldn't initialize extension type");
                }

                _cancellationToken.ThrowIfCancellationRequested();

                if (!mediaFilter.CheckAllPhotoFilters(rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails))
                {
                    if (IsTotalDownloadsEnabled)
                    {
                        if (_totalCount++ < TotalDownloads)
                        {
                            await DownloadPhotoAsync(_downloadFolder, mediaId, extension, downloadLink);
                        }
                    }
                    else
                    {
                        await DownloadPhotoAsync(_downloadFolder, mediaId, extension, downloadLink);
                    }
                }

                if (mediaFilter.SaveStatsInCsvFile)
                {
                    string[] fileContent =
                    {
                        "\"" + $"{mediaId}.{extension}" + "\"" + _delimiter +
                        "\"" + shortCode + "\"" + _delimiter +
                        "\"" + displayUrl + "\"" + _delimiter +
                        "\"" + mediaId + "\"" + _delimiter +
                        "\"" + dimensions + "\"" + _delimiter +
                        "\"" + captionText + "\"" + _delimiter +
                        "\"" + likes + "\"" + _delimiter +
                        "\"" + comments + "\"" + _delimiter +
                        "\"" + commentsDisabled + "\"" + _delimiter +
                        "\"" + isVideo + "\"" + _delimiter +
                        "\"" + videoViews + "\"" + _delimiter +
                        "\"" + uploadDate +"\""
                    };
                    _csvWriter.Write(statsFile, fileContent);
                }
            }
            catch (Exception)
            {
                // something probably went wrong
            }
            
        }
        
        private async Task DownloadUserPhotosAsync(string input, MediaFilter mediaFilter, int downloadLimit)
        {
            var maxId = "";
            var hasNextPage = true;
            int downloadCount = 0;

            string downloadFolder = mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            string statsFile = $@"{_statsDirectory}\{input}.csv";

            if(mediaFilter.SaveStatsInCsvFile)
                if (!File.Exists(statsFile)) _csvWriter.WriteHeader(statsFile, false);

            while (hasNextPage)
            {
                var rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Username, maxId);

                if (rootObject.MediaEntryData.ProfilePage == null) return;

                foreach (ProfilePage profilePage in rootObject.MediaEntryData.ProfilePage)
                {
                    maxId = profilePage.User.Media.PageInfo.EndCursor;
                    hasNextPage = profilePage.User.Media.PageInfo.HasNextPage;

                    foreach (UserPhotoData node in profilePage.User.Media.Nodes)
                    {
                        var mediaId = node.Id;

                        string extension;
                        string downloadLink;
                        if (!node.IsVideo)
                        {
                            downloadLink = node.DisplaySrc;
                            extension = "jpg";
                        }
                        else
                        {
                            RootObject videoDetails = await _jsonParser.GetRootObjectAsync($@"{Globals.BASE_URL}/p/{node.ShortCode}/", InputType.Url);
                            downloadLink = videoDetails.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoUrl;
                            extension = "mp4";
                        }

                        var shortCode = node.ShortCode;
                        var displayUrl = node.DisplaySrc;
                        var captionText = node.Caption?.Replace('\n', ' ') ?? string.Empty;
                        var likes = node.Likes.Count;
                        var comments = node.Comments.Count;
                        var isVideo = node.IsVideo;
                        var videoViews = node.VideoViews;
                        var commentsDisabled = node.CommentsDisabled;
                        var uploadDate = DateTimeOffset.FromUnixTimeSeconds(node.Date).ToLocalTime();
                        var dimensions =
                            $"W:{node.Dimensions.Width} " +
                            $"H:{node.Dimensions.Height}";

                        _cancellationToken.ThrowIfCancellationRequested();

                        if (!mediaFilter.CheckAllUsernameFilters(node))
                        {
                            if (IsTotalDownloadsEnabled)
                            {
                                if (_totalCount++ < TotalDownloads)
                                {
                                    if (downloadLimit != 0)
                                    {
                                        if (downloadCount < downloadLimit)
                                        {
                                            downloadCount++;
                                            await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (downloadLimit != 0)
                                {
                                    if (downloadCount < downloadLimit)
                                    {
                                        downloadCount++;
                                        await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                }
                            }
                        }

                        if (mediaFilter.SaveStatsInCsvFile)
                        {
                            string[] fileContent =
                            {
                                "\"" + $"{mediaId}.{extension}" + "\"" + _delimiter +
                                "\"" + shortCode + "\"" + _delimiter +
                                "\"" + displayUrl + "\"" + _delimiter +
                                "\"" + mediaId + "\"" + _delimiter +
                                "\"" + dimensions + "\"" + _delimiter +
                                "\"" + captionText + "\"" + _delimiter +
                                "\"" + likes + "\"" + _delimiter +
                                "\"" + comments + "\"" + _delimiter +
                                "\"" + commentsDisabled + "\"" + _delimiter +
                                "\"" + isVideo + "\"" + _delimiter +
                                "\"" + videoViews + "\"" + _delimiter +
                                "\"" + uploadDate +"\""
                            };
                            _csvWriter.Write(statsFile, fileContent);
                        }
                    }
                }
            }
        }

        private async Task<int> DownloadHashtagTopPhotosAsync(string input, List<EdgeHashtagToMediaEdge> edges, MediaFilter mediaFilter, int downloadLimit, string downloadFolder)
        {
            int downloadCount = 0;
            string statsFile = $@"{_statsDirectory}\{input}.csv";

            foreach (EdgeHashtagToMediaEdge edge in edges)
            {
                string mediaId = edge.Node.Id;

                string extension;
                string downloadLink;
                if (!edge.Node.IsVideo)
                {
                    downloadLink = edge.Node.DisplayUrl;
                    extension = "jpg";
                }
                else
                {
                    RootObject videoDetails = await _jsonParser.GetRootObjectAsync($@"{Globals.BASE_URL}/p/{edge.Node.Shortcode}/", InputType.Url);

                    if (videoDetails.MediaEntryData.MediaPostPage == null) return 0;

                    downloadLink = videoDetails.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoUrl;
                    extension = "mp4";
                }

                var shortCode = edge.Node.Shortcode;
                var displayUrl = edge.Node.DisplayUrl;
                var captionText = edge.Node.CaptionEdge.CaptionTextEdge.Count > 0 ? 
                    edge.Node.CaptionEdge.CaptionTextEdge[0].CaptionText.Text.Replace('\n', ' ') : string.Empty;
                var likes = edge.Node.Likes.Count;
                var comments = edge.Node.Comments.Count;
                var isVideo = edge.Node.IsVideo;
                var videoViews = edge.Node.VideoViewCount;
                var commentsDisabled = edge.Node.CommentsDisabled;
                var uploadDate = DateTimeOffset.FromUnixTimeSeconds(edge.Node.TakenAtTimestamp).ToLocalTime();
                var dimensions =
                    $"W:{edge.Node.Dimensions.Width} " +
                    $"H:{edge.Node.Dimensions.Height}";

                _cancellationToken.ThrowIfCancellationRequested();

                if (!mediaFilter.CheckAllHashtagFilters(edge.Node))
                {
                    if (IsTotalDownloadsEnabled)
                    {
                        if (_totalCount++ < TotalDownloads)
                        {
                            if (downloadLimit != 0)
                            {
                                if (downloadCount < downloadLimit)
                                {
                                    downloadCount++;
                                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                }
                                else
                                {
                                    return downloadCount;
                                }
                            }
                            else
                            {
                                await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                            }
                        }
                        else
                        {
                            return downloadCount;
                        }
                    }
                    else
                    {
                        if (downloadLimit != 0)
                        {
                            if (downloadCount < downloadLimit)
                            {
                                downloadCount++;
                                await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                            }
                            else
                            {
                                return downloadCount;
                            }
                        }
                        else
                        {
                            await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                        }
                    }

                    if (mediaFilter.SaveStatsInCsvFile)
                    {
                        string[] fileContent =
                        {
                            "\"" + $"{mediaId}.{extension}" + "\"" + _delimiter +
                            "\"" + shortCode + "\"" + _delimiter +
                            "\"" + displayUrl + "\"" + _delimiter +
                            "\"" + mediaId + "\"" + _delimiter +
                            "\"" + dimensions + "\"" + _delimiter +
                            "\"" + captionText + "\"" + _delimiter +
                            "\"" + likes + "\"" + _delimiter +
                            "\"" + comments + "\"" + _delimiter +
                            "\"" + commentsDisabled + "\"" + _delimiter +
                            "\"" + isVideo + "\"" + _delimiter +
                            "\"" + videoViews + "\"" + _delimiter +
                            "\"" + uploadDate +"\""
                        };
                        _csvWriter.Write(statsFile, fileContent);
                    }
                }
            }

            return downloadCount;
        }

        private async Task DownloadHashtagPhotosAsync(string input, MediaFilter mediaFilter, int downloadLimit)
        {
            string maxId = "";
            bool hasNextPage;
            int downloadCount = 0;

            string downloadFolder = mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            string statsFile = $@"{_statsDirectory}\{input}.csv";

            if (mediaFilter.SaveStatsInCsvFile)
                if (!File.Exists(statsFile)) _csvWriter.WriteHeader(statsFile, false);

            var rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Hashtag, maxId);
            if (rootObject.MediaEntryData.HashtagPage == null) return;

            if (!mediaFilter.SkipTopPosts)
            {
                downloadCount = await DownloadHashtagTopPhotosAsync(input, rootObject.MediaEntryData.HashtagPage[0].GraphMedia.Hashtag.EdgeHashtagToTopPosts.Edges, mediaFilter, downloadLimit, downloadFolder);
            }

            do
            {
                maxId = rootObject.MediaEntryData.HashtagPage[0].GraphMedia.Hashtag.EdgeHashtagToMedia.PageInfo.EndCursor;
                hasNextPage = rootObject.MediaEntryData.HashtagPage[0].GraphMedia.Hashtag.EdgeHashtagToMedia.PageInfo.HasNextPage;

                foreach (EdgeHashtagToMediaEdge edge in rootObject.MediaEntryData.HashtagPage[0].GraphMedia.Hashtag.EdgeHashtagToMedia.Edges)
                {
                    string mediaId = edge.Node.Id;

                    string extension;
                    string downloadLink;
                    if (!edge.Node.IsVideo)
                    {
                        downloadLink = edge.Node.DisplayUrl;
                        extension = "jpg";
                    }
                    else
                    {
                        RootObject videoDetails = await _jsonParser.GetRootObjectAsync($@"{Globals.BASE_URL}/p/{edge.Node.Shortcode}/", InputType.Url);
                        if (videoDetails.MediaEntryData.MediaPostPage == null) return;

                        downloadLink = videoDetails.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoUrl;
                        extension = "mp4";
                    }

                    var shortCode = edge.Node.Shortcode;
                    var displayUrl = edge.Node.DisplayUrl;
                    var captionText = edge.Node.CaptionEdge.CaptionTextEdge.Count > 0 ? 
                        edge.Node.CaptionEdge.CaptionTextEdge[0].CaptionText.Text.Replace('\n', ' ') : string.Empty;
                    var likes = edge.Node.Likes.Count;
                    var comments = edge.Node.Comments.Count;
                    var isVideo = edge.Node.IsVideo;
                    var videoViews = edge.Node.VideoViewCount;
                    var commentsDisabled = edge.Node.CommentsDisabled;
                    var uploadDate = DateTimeOffset.FromUnixTimeSeconds(edge.Node.TakenAtTimestamp).ToLocalTime();
                    var dimensions =
                        $"W:{edge.Node.Dimensions.Width} " +
                        $"H:{edge.Node.Dimensions.Height}";

                    _cancellationToken.ThrowIfCancellationRequested();

                    if (!mediaFilter.CheckAllHashtagFilters(edge.Node))
                    {
                        if (IsTotalDownloadsEnabled)
                        {
                            if (_totalCount++ < TotalDownloads)
                            {
                                if (downloadLimit != 0)
                                {
                                    if (downloadCount < downloadLimit)
                                    {
                                        downloadCount++;
                                        await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (downloadLimit != 0)
                            {
                                if (downloadCount < downloadLimit)
                                {
                                    downloadCount++;
                                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                            }
                        }

                        if (mediaFilter.SaveStatsInCsvFile)
                        {
                            string[] fileContent =
                            {
                                "\"" + $"{mediaId}.{extension}" + "\"" + _delimiter +
                                "\"" + shortCode + "\"" + _delimiter +
                                "\"" + displayUrl + "\"" + _delimiter +
                                "\"" + mediaId + "\"" + _delimiter +
                                "\"" + dimensions + "\"" + _delimiter +
                                "\"" + captionText + "\"" + _delimiter +
                                "\"" + likes + "\"" + _delimiter +
                                "\"" + comments + "\"" + _delimiter +
                                "\"" + commentsDisabled + "\"" + _delimiter +
                                "\"" + isVideo + "\"" + _delimiter +
                                "\"" + videoViews + "\"" + _delimiter +
                                "\"" + uploadDate +"\""
                            };
                            _csvWriter.Write(statsFile, fileContent);
                        }
                    }
                }

                rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Hashtag, maxId);
            } while (hasNextPage);
        }

        private async Task<int> DownloadLocationTopPhotosAsync(string input, List<UserPhotoData> edges, MediaFilter mediaFilter, int downloadLimit, string downloadFolder)
        {
            int downloadCount = 0;
            string statsFile = $@"{_statsDirectory}\{input}.csv";

            foreach (UserPhotoData data in edges)
            {
                string mediaId = data.Id;

                string extension;
                string downloadLink;
                if (!data.IsVideo)
                {
                    downloadLink = data.DisplaySrc;
                    extension = "jpg";
                }
                else
                {
                    RootObject videoDetails = await _jsonParser.GetRootObjectAsync($@"{Globals.BASE_URL}/p/{data.ShortCode}/", InputType.Url);

                    if (videoDetails.MediaEntryData.MediaPostPage == null) return 0;

                    downloadLink = videoDetails.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoUrl;
                    extension = "mp4";
                }

                var shortCode = data.ShortCode;
                var displayUrl = data.DisplaySrc;
                var captionText = data.Caption?.Replace('\n', ' ') ?? string.Empty;
                var likes = data.Likes.Count;
                var comments = data.Comments.Count;
                var isVideo = data.IsVideo;
                var videoViews = data.VideoViews;
                var commentsDisabled = data.CommentsDisabled;
                var uploadDate = DateTimeOffset.FromUnixTimeSeconds(data.Date).ToLocalTime();
                var dimensions =
                    $"W:{data.Dimensions.Width} " +
                    $"H:{data.Dimensions.Height}";

                _cancellationToken.ThrowIfCancellationRequested();

                if (!mediaFilter.CheckAllUsernameFilters(data))
                {
                    if (IsTotalDownloadsEnabled)
                    {
                        if (_totalCount++ < TotalDownloads)
                        {
                            if (downloadLimit != 0)
                            {
                                if (downloadCount < downloadLimit)
                                {
                                    downloadCount++;
                                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                }
                                else
                                {
                                    return downloadCount;
                                }
                            }
                            else
                            {
                                await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                            }
                        }
                        else
                        {
                            return downloadCount;
                        }
                    }
                    else
                    {
                        if (downloadLimit != 0)
                        {
                            if (downloadCount < downloadLimit)
                            {
                                downloadCount++;
                                await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                            }
                            else
                            {
                                return downloadCount;
                            }
                        }
                        else
                        {
                            await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                        }
                    }
                    if (mediaFilter.SaveStatsInCsvFile)
                    {
                        string[] fileContent =
                        {
                            "\"" + $"{mediaId}.{extension}" + "\"" + _delimiter +
                            "\"" + shortCode + "\"" + _delimiter +
                            "\"" + displayUrl + "\"" + _delimiter +
                            "\"" + mediaId + "\"" + _delimiter +
                            "\"" + dimensions + "\"" + _delimiter +
                            "\"" + captionText + "\"" + _delimiter +
                            "\"" + likes + "\"" + _delimiter +
                            "\"" + comments + "\"" + _delimiter +
                            "\"" + commentsDisabled + "\"" + _delimiter +
                            "\"" + isVideo + "\"" + _delimiter +
                            "\"" + videoViews + "\"" + _delimiter +
                            "\"" + uploadDate +"\""
                        };
                        _csvWriter.Write(statsFile, fileContent);
                    }
                }
            }

            return downloadCount;
        }

        private async Task DownloadLocationPhotosAsync(string input, MediaFilter mediaFilter, int downloadLimit)
        {
            var maxId = "";
            var hasNextPage = true;
            int downloadCount = 0;

            string downloadFolder = mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            string statsFile = $@"{_statsDirectory}\{input}.csv";

            if (mediaFilter.SaveStatsInCsvFile)
                if (!File.Exists(statsFile)) _csvWriter.WriteHeader(statsFile, false);

            var rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Location, maxId);
            if (rootObject.MediaEntryData.LocationsPage == null) return;

            if (!mediaFilter.SkipTopPosts)
            {
                downloadCount = await DownloadLocationTopPhotosAsync(input, rootObject.MediaEntryData.LocationsPage[0].Location.TopPosts.Nodes, mediaFilter, downloadLimit, downloadFolder);
            }

            while (hasNextPage)
            {
                rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Location, maxId);

                maxId = rootObject.MediaEntryData.LocationsPage[0].Location.Media.PageInfo.EndCursor;
                hasNextPage = rootObject.MediaEntryData.LocationsPage[0].Location.Media.PageInfo.HasNextPage;

                foreach (UserPhotoData data in rootObject.MediaEntryData.LocationsPage[0].Location.Media.Nodes)
                {
                    string mediaId = data.Id;

                    string extension;
                    string downloadLink;
                    if (!data.IsVideo)
                    {
                        downloadLink = data.DisplaySrc;
                        extension = "jpg";
                    }
                    else
                    {
                        RootObject videoDetails = await _jsonParser.GetRootObjectAsync($@"{Globals.BASE_URL}/p/{data.ShortCode}/", InputType.Url);
                        downloadLink = videoDetails.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoUrl;
                        extension = "mp4";
                    }

                    var shortCode = data.ShortCode;
                    var displayUrl = data.DisplaySrc;
                    var captionText = data.Caption?.Replace('\n', ' ') ?? string.Empty;
                    var likes = data.Likes.Count;
                    var comments = data.Comments.Count;
                    var isVideo = data.IsVideo;
                    var videoViews = data.VideoViews;
                    var commentsDisabled = data.CommentsDisabled;
                    var uploadDate = DateTimeOffset.FromUnixTimeSeconds(data.Date).ToLocalTime();
                    var dimensions =
                        $"W:{data.Dimensions.Width} " +
                        $"H:{data.Dimensions.Height}";

                    _cancellationToken.ThrowIfCancellationRequested();

                    if (!mediaFilter.CheckAllUsernameFilters(data))
                    {
                        if (IsTotalDownloadsEnabled)
                        {
                            if (_totalCount++ < TotalDownloads)
                            {
                                if (downloadLimit != 0)
                                {
                                    if (downloadCount < downloadLimit)
                                    {
                                        downloadCount++;
                                        await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (downloadLimit != 0)
                            {
                                if (downloadCount < downloadLimit)
                                {
                                    downloadCount++;
                                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                            }
                        }

                        if (mediaFilter.SaveStatsInCsvFile)
                        {
                            string[] fileContent =
                            {
                                "\"" + $"{mediaId}.{extension}" + "\"" + _delimiter +
                                "\"" + shortCode + "\"" + _delimiter +
                                "\"" + displayUrl + "\"" + _delimiter +
                                "\"" + mediaId + "\"" + _delimiter +
                                "\"" + dimensions + "\"" + _delimiter +
                                "\"" + captionText + "\"" + _delimiter +
                                "\"" + likes + "\"" + _delimiter +
                                "\"" + comments + "\"" + _delimiter +
                                "\"" + commentsDisabled + "\"" + _delimiter +
                                "\"" + isVideo + "\"" + _delimiter +
                                "\"" + videoViews + "\"" + _delimiter +
                                "\"" + uploadDate +"\""
                            };
                            _csvWriter.Write(statsFile, fileContent);
                        }
                    }
                }
            }
        }
        
        public async Task DownloadPhotoAsync(string directoryPath, string fileName, string extension, string url)
        {
            try
            {
                if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

                using (Request request = new Request(_userAgent, _proxy, _requestTimeout, _cookies))
                {
                    HttpResponseMessage msg = await request.GetRequestResponseAsync(url);
                    if (msg.IsSuccessStatusCode)
                    {
                        using (FileStream fs = File.Open($@"{directoryPath}\{fileName}.{extension}", FileMode.Create))
                        {
                            byte[] bytes = await msg.Content.ReadAsByteArrayAsync();
                            await fs.WriteAsync(bytes, 0, bytes.Length);
                            //await msg.Content.CopyToAsync(fs);
                        }
                    }
                    else
                    {
                        Console.WriteLine(@"Bad response");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
#endregion

    }
}
