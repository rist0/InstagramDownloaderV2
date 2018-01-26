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
        private readonly string _delimiter;
        private readonly string _statsDirectory;
        private bool _headerIsWritten; // for single Url csv header

        // Properties
        public InputType InputType { get; set; }
        public bool IsTotalDownloadsEnabled { get; set; }
        public int TotalDownloads { get; set; }
        public bool CustomFolder { get; set; }
#endregion

#region Constructor
        public InstagramDownload(string userAgent, WebProxy proxy, double requestTimeout, string downloadFolder, CancellationToken cancellationToken, CookieContainer cookies, string csvFileDelimiter)
        {
            _downloadFolder = downloadFolder;
            _cancellationToken = cancellationToken;
            _totalCount = 0;

            _userAgent = userAgent;
            _proxy = proxy;
            _requestTimeout = requestTimeout;
            _cookies = cookies;

            _jsonParser = new JsonParser(userAgent, proxy, requestTimeout, cookies);

            _headerIsWritten = false;
            _delimiter = csvFileDelimiter;
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
                
                var rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Url);

                if (rootObject.MediaEntryData.MediaPostPage == null) return;

                var downloadLink = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.IsVideo ?
                    rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.VideoUrl :
                    rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.DisplayUrl;

                var mediaId = rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails.MediaId;

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
                    if (!IsTotalDownloadsEnabled)
                    {
                        await DownloadPhotoAsync(_downloadFolder, mediaId, extension, downloadLink);
                    }
                    else
                    {
                        if (_totalCount++ < TotalDownloads)
                        {
                            await DownloadPhotoAsync(_downloadFolder, mediaId, extension, downloadLink);
                        }
                    }
                }

                if (mediaFilter.SaveStatsInCsvFile)
                {
                    Console.WriteLine(!_headerIsWritten);
                    using (var csvWriter = new Csv(statsFile, _delimiter, !_headerIsWritten))
                    {
                        await csvWriter.WriteContent(rootObject.MediaEntryData.MediaPostPage[0].GraphMedia.MediaDetails);
                        _headerIsWritten = true;
                    }
                        
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
            var downloadCount = 0;

            var downloadFolder = mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            var statsFile = $@"{_statsDirectory}\{input}.csv";

            using(var csvWriter = new Csv(statsFile, _delimiter))
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

                        _cancellationToken.ThrowIfCancellationRequested();

                        if (mediaFilter.CheckAllUsernameFilters(node)) continue;
                        if (!CheckDownloads(downloadCount, downloadLimit)) return;

                        _totalCount++;
                        downloadCount++;

                        await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);

                        if (mediaFilter.SaveStatsInCsvFile)
                        {
                            await csvWriter.WriteContent(node);
                        }
                    }
                }
            }
        }

        private async Task<int> DownloadHashtagTopPhotosAsync(string input, List<EdgeHashtagToMediaEdge> edges, MediaFilter mediaFilter, int downloadLimit, string downloadFolder)
        {
            int downloadCount = 0;
            string statsFile = $@"{_statsDirectory}\{input}.csv";

            using (var csvWriter = new Csv(statsFile, _delimiter))
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

                _cancellationToken.ThrowIfCancellationRequested();

                if (!mediaFilter.CheckAllHashtagFilters(edge.Node))
                {
                    if (!CheckDownloads(downloadCount, downloadLimit)) return 0;

                    _totalCount++;
                    downloadCount++;

                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);
                    
                    if (mediaFilter.SaveStatsInCsvFile)
                    {
                        await csvWriter.WriteContent(edge);
                    }
                }
            }

            return downloadCount;
        }

        private async Task DownloadHashtagPhotosAsync(string input, MediaFilter mediaFilter, int downloadLimit)
        {
            var maxId = "";
            var downloadCount = 0;

            var downloadFolder = mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            var statsFile = $@"{_statsDirectory}\{input}.csv";

            var rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Hashtag, maxId);
            if (rootObject.MediaEntryData.HashtagPage == null) return;

            if (!mediaFilter.SkipTopPosts)
            {
                downloadCount = await DownloadHashtagTopPhotosAsync(input, rootObject.MediaEntryData.HashtagPage[0].GraphMedia.Hashtag.EdgeHashtagToTopPosts.Edges, mediaFilter, downloadLimit, downloadFolder);
            }

            using (var csvWriter = new Csv(statsFile, _delimiter, mediaFilter.SkipTopPosts))
            {
                bool hasNextPage;
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

                        _cancellationToken.ThrowIfCancellationRequested();

                        if (!mediaFilter.CheckAllHashtagFilters(edge.Node))
                        {
                            if (!CheckDownloads(downloadCount, downloadLimit)) return;

                            _totalCount++;
                            downloadCount++;

                            await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);

                            if (mediaFilter.SaveStatsInCsvFile)
                            {
                                await csvWriter.WriteContent(edge);
                            }
                        }
                    }

                    rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Hashtag, maxId);
                } while (hasNextPage);
            }
        }

        private async Task<int> DownloadLocationTopPhotosAsync(string input, List<UserPhotoData> edges, MediaFilter mediaFilter, int downloadLimit, string downloadFolder)
        {
            int downloadCount = 0;
            string statsFile = $@"{_statsDirectory}\{input}.csv";

            using (var csvWriter = new Csv(statsFile, _delimiter))
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

                _cancellationToken.ThrowIfCancellationRequested();

                if (!mediaFilter.CheckAllUsernameFilters(data))
                {
                    if (!CheckDownloads(downloadCount, downloadLimit)) return 0;

                    _totalCount++;
                    downloadCount++;

                    await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);

                    if (mediaFilter.SaveStatsInCsvFile)
                    {
                        await csvWriter.WriteContent(data);
                    }
                }
            }

            return downloadCount;
        }

        private async Task DownloadLocationPhotosAsync(string input, MediaFilter mediaFilter, int downloadLimit)
        {
            var maxId = "";
            int downloadCount = 0;

            string downloadFolder = mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            string statsFile = $@"{_statsDirectory}\{input}.csv";
            

            var rootObject = await _jsonParser.GetRootObjectAsync(input, InputType.Location, maxId);
            if (rootObject.MediaEntryData.LocationsPage == null) return;

            if (!mediaFilter.SkipTopPosts)
            {
                downloadCount = await DownloadLocationTopPhotosAsync(input, rootObject.MediaEntryData.LocationsPage[0].Location.TopPosts.Nodes, mediaFilter, downloadLimit, downloadFolder);
            }

            using (var csvWriter = new Csv(statsFile, _delimiter, mediaFilter.SkipTopPosts))
            {
                bool hasNextPage;
                do
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

                        _cancellationToken.ThrowIfCancellationRequested();

                        if (!mediaFilter.CheckAllUsernameFilters(data))
                        {
                            if (!CheckDownloads(downloadCount, downloadLimit)) return;

                            _totalCount++;
                            downloadCount++;

                            await DownloadPhotoAsync(downloadFolder, mediaId, extension, downloadLink);

                            if (mediaFilter.SaveStatsInCsvFile)
                            {
                                await csvWriter.WriteContent(data);
                            }
                        }
                    }
                } while (hasNextPage);
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
                            //await fs.WriteAsync(bytes, 0, bytes.Length);
                            await msg.Content.CopyToAsync(fs);
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
                Console.WriteLine(@"Method: {0}, Error: {1}", @"DownloadPhotoAsync", ex.Message);
            }
        }

        private bool CheckDownloads(int downloadCount, int downloadLimit)
        {
            if (IsTotalDownloadsEnabled)
            {
                if (_totalCount < TotalDownloads)
                {
                    if (downloadLimit != 0)
                    {
                        if (downloadCount < downloadLimit)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (downloadLimit != 0)
            {
                if (downloadCount < downloadLimit)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }
        #endregion

    }
}
