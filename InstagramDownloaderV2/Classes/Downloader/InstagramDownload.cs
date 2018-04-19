using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using InstagramDownloaderV2.Classes.CSV;
using InstagramDownloaderV2.Classes.Requests;
using InstagramDownloaderV2.Classes.Validation;
using InstagramDownloaderV2.Enums;
using InstaSharper.API;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;

namespace InstagramDownloaderV2.Classes.Downloader
{
    class InstagramDownload
    {
#region Variables and properties
        // Download settings
        private readonly string _downloadFolder;
        private readonly CancellationToken _cancellationToken;
        private int _totalCount;

        // Request params
        private readonly string _userAgent;
        private readonly WebProxy _proxy;
        private readonly double _requestTimeout;

        // Csv Writer
        private readonly string _delimiter;
        private readonly string _statsDirectory;

        // Properties
        public bool IsTotalDownloadsEnabled { get; set; }
        public int TotalDownloads { get; set; }
        public bool CustomFolder { get; set; }

        // Media filter
        private readonly MediaFilter _mediaFilter;

        // Insta api
        private readonly IInstaApi _instaApi;
#endregion

#region Constructor
        public InstagramDownload(IInstaApi instaApi, MediaFilter mediaFilter, string userAgent, WebProxy proxy, double requestTimeout, string downloadFolder, CancellationToken cancellationToken, string csvFileDelimiter)
        {
            _instaApi = instaApi;
            _mediaFilter = mediaFilter;

            _downloadFolder = downloadFolder;
            _cancellationToken = cancellationToken;
            _totalCount = 0;

            _userAgent = userAgent;
            _proxy = proxy;
            _requestTimeout = requestTimeout;

            _delimiter = !string.IsNullOrEmpty(csvFileDelimiter) ? csvFileDelimiter : ",";
            _statsDirectory = downloadFolder + @"\stats";
            if (!Directory.Exists(_statsDirectory)) Directory.CreateDirectory(_statsDirectory);
        }
#endregion

#region Methods
        public async Task Download(string input, InputType inputType, string downloadLimit = "0")
        {
            if (!InputValidation.IsInt(downloadLimit)) return;

            switch (inputType)
            {
                case InputType.Url:
                    await DownloadUrlPhotoAsync(input, InputMediaType.Url);
                    break;
                case InputType.MediaId:
                    await DownloadUrlPhotoAsync(input, InputMediaType.Id);
                    break;
                case InputType.Username:
                    await DownloadUserMediaAsync(input, InputUserType.Username, int.Parse(downloadLimit));
                    break;
                case InputType.UserId:
                    await DownloadUserMediaAsync(input, InputUserType.Id, int.Parse(downloadLimit));
                    break;
                case InputType.Hashtag:
                    await DownloadTagMediaAsync(input, int.Parse(downloadLimit));
                    break;
                case InputType.Location:
                    await DownloadLocationMediaAsync(input, int.Parse(downloadLimit));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }

        private async Task DownloadInstaMediaAsync(InstaMedia media, string statsFile, string downloadFolder = "")
        {
            var mediaType = media.MediaType;
            if (downloadFolder == "") downloadFolder = _downloadFolder;

            switch (mediaType)
            {
                case InstaMediaType.Image:
                    // Get download url
                    var imgUrl = media.Images[0].URI;

                    // Get uri extension
                    var imgExtension = InputValidation.GetUriExtension(imgUrl);

                    // Download
                    await DownloadMediaAsync(downloadFolder, media.Pk + imgExtension, imgUrl);

                    // Write csv
                    if (_mediaFilter.SaveStatsInCsvFile)
                        using (var csvWriter = new Csv(statsFile, _delimiter))
                        {
                            await csvWriter.WriteContent(media);
                        }

                    break;
                case InstaMediaType.Video:
                    // Get download url
                    var vidUrl = media.Videos[0].Url;

                    // Get uri extension
                    var vidExtension = InputValidation.GetUriExtension(vidUrl);

                    // Download
                    await DownloadMediaAsync(downloadFolder, media.Pk + vidExtension, vidUrl);

                    // Write csv
                    if (_mediaFilter.SaveStatsInCsvFile)
                        using (var csvWriter = new Csv(statsFile, _delimiter))
                        {
                            await csvWriter.WriteContent(media);
                        }

                    break;
                case InstaMediaType.Carousel:
                    // Write csv [for main post]
                    if (_mediaFilter.SaveStatsInCsvFile)
                        using (var csvWriter = new Csv(statsFile, _delimiter))
                        {
                            await csvWriter.WriteContent(media);
                        }

                    foreach (var c in media.Carousel)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();

                        switch (c.MediaType)
                        {
                            case InstaMediaType.Image:
                                // Get download url
                                var imageUrl = c.Images[0].URI;

                                // Get Uri extension
                                var imageExtension = InputValidation.GetUriExtension(imageUrl);

                                // Download
                                await DownloadMediaAsync(downloadFolder, c.Pk + imageExtension, imageUrl);

                                // Write csv
                                if (_mediaFilter.SaveStatsInCsvFile)
                                    using (var csvWriter = new Csv(statsFile, _delimiter))
                                    {
                                        await csvWriter.WriteContent(c);
                                    }

                                break;
                            case InstaMediaType.Video:
                                // Get download url
                                var videoUrl = c.Videos[0].Url;

                                // Get Uri extension
                                var videoExtension = InputValidation.GetUriExtension(videoUrl);

                                // Download
                                await DownloadMediaAsync(downloadFolder, c.Pk + videoExtension, videoUrl);

                                // Write csv
                                if (_mediaFilter.SaveStatsInCsvFile)
                                    using (var csvWriter = new Csv(statsFile, _delimiter))
                                    {
                                        await csvWriter.WriteContent(c);
                                    }

                                break;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private async Task DownloadUrlPhotoAsync(string input, InputMediaType inputType)
        {
            try
            {
                var statsFile = $@"{_statsDirectory}\urls.csv";
                IResult<string> mediaIdFromUrl = null;

                if (!File.Exists(statsFile))
                {
                    using (var csv = new Csv(statsFile, _delimiter))
                    {
                        csv.WriteHeader();
                    }
                }

                if (inputType == InputMediaType.Url)
                {
                    mediaIdFromUrl = await _instaApi.GetMediaIdFromUrlAsync(new Uri(input));

                    if (!mediaIdFromUrl.Succeeded)
                    {
                        return;
                    }
                }

                var mediaId = mediaIdFromUrl == null ? input : mediaIdFromUrl.Value;

                var mediaInformation = await _instaApi.GetMediaByIdAsync(mediaId);

                if (!mediaInformation.Succeeded)
                {
                    return;
                }

                _cancellationToken.ThrowIfCancellationRequested();

                if (_mediaFilter.CheckFilters(mediaInformation.Value)) return;
                if (CheckTotalDownloads()) await DownloadInstaMediaAsync(mediaInformation.Value, statsFile);
            }
            catch (Exception)
            {
                // something probably went wrong
            }
        }

        private async Task DownloadUserMediaAsync(string input, InputUserType userType, int downloadLimit)
        {
            var downloadCount = 0;
            var downloadFolder = _mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            var statsFile = $@"{_statsDirectory}\{input}.csv";

            if (!File.Exists(statsFile))
            {
                using (var csv = new Csv(statsFile, _delimiter))
                {
                    csv.WriteHeader();
                }
            }

            IResult<InstaUserInfo> userNameFromId = null;

            if (userType == InputUserType.Id)
            {
                userNameFromId = await _instaApi.GetUserInfoByIdAsync(long.Parse(input));

                if (!userNameFromId.Succeeded) return;
            }

            var username = userNameFromId == null ? input : userNameFromId.Value.Username;
            var maxId = "";

            do
            {
                var userInformation = await _instaApi.GetUserMediaAsync(username, PaginationParameters.MaxPagesToLoad(1).StartFromId(maxId));
                maxId = userInformation.Value.NextId;

                if (!userInformation.Succeeded) return;

                foreach (var m in userInformation.Value)
                {
                    _cancellationToken.ThrowIfCancellationRequested();

                    if (_mediaFilter.CheckFilters(m)) continue;

                    if (CheckTotalDownloads() && CheckDownloadLimit(downloadCount++, downloadLimit)) await DownloadInstaMediaAsync(m, statsFile, downloadFolder);
                    else return;
                }

            } while (true);
        }

        private async Task DownloadTagMediaAsync(string input, int downloadLimit)
        {
            var downloadCount = 0;
            var downloadFolder = _mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            var statsFile = $@"{_statsDirectory}\{input}.csv";

            if (!File.Exists(statsFile))
            {
                using (var csv = new Csv(statsFile, _delimiter))
                {
                    csv.WriteHeader();
                }
            }

            var maxId = "";
            do
            {
                var tagMedia = await _instaApi.GetTagFeedAsync(input, PaginationParameters.MaxPagesToLoad(1).StartFromId(maxId));

                maxId = tagMedia.Value.NextId;

                if (!_mediaFilter.SkipTopPosts)
                {
                    foreach (var rankedMedia in tagMedia.Value.RankedMedias)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();

                        if (_mediaFilter.CheckFilters(rankedMedia)) continue;

                        if (CheckTotalDownloads() && CheckDownloadLimit(downloadCount++, downloadLimit)) await DownloadInstaMediaAsync(rankedMedia, statsFile, downloadFolder);
                        else return;
                    }
                }
                
                foreach (var media in tagMedia.Value.Medias)
                {
                    _cancellationToken.ThrowIfCancellationRequested();

                    if (_mediaFilter.CheckFilters(media)) continue;

                    if (CheckTotalDownloads() && CheckDownloadLimit(downloadCount++, downloadLimit)) await DownloadInstaMediaAsync(media, statsFile, downloadFolder);
                    else return;
                }

            } while (true);
        }

        private async Task DownloadLocationMediaAsync(string input, int downloadLimit)
        {
            var downloadCount = 0;
            var downloadFolder = _mediaFilter.CustomFolder ? $@"{_downloadFolder}\{input}" : _downloadFolder;
            var statsFile = $@"{_statsDirectory}\{input}.csv";

            if (!File.Exists(statsFile))
            {
                using (var csv = new Csv(statsFile, _delimiter))
                {
                    csv.WriteHeader();
                }
            }

            var maxId = "";
            do
            {
                var locationMedia = await _instaApi.GetLocationFeed(long.Parse(input), PaginationParameters.MaxPagesToLoad(1).StartFromId(maxId));

                maxId = locationMedia.Value.NextId;

                if (!_mediaFilter.SkipTopPosts)
                {
                    foreach (var rankedMedia in locationMedia.Value.RankedMedias)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();

                        if (_mediaFilter.CheckFilters(rankedMedia)) continue;

                        if (CheckTotalDownloads() && CheckDownloadLimit(downloadCount++, downloadLimit)) await DownloadInstaMediaAsync(rankedMedia, statsFile, downloadFolder);
                        else return;
                    }
                }

                foreach (var media in locationMedia.Value.Medias)
                {
                    _cancellationToken.ThrowIfCancellationRequested();

                    if (_mediaFilter.CheckFilters(media)) continue;

                    if (CheckTotalDownloads() && CheckDownloadLimit(downloadCount++, downloadLimit)) await DownloadInstaMediaAsync(media, statsFile, downloadFolder);
                    else return;
                }

            } while (true);
        }

        private async Task DownloadMediaAsync(string savePath, string fileName, string downloadUrl)
        {
            try
            {
                if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

                using (var request = new Request(_userAgent, _proxy, _requestTimeout))
                {
                    var msg = await request.GetRequestResponseAsync(downloadUrl);
                    if (msg.IsSuccessStatusCode)
                    {
                        using (var fs = File.Open($@"{savePath}\{fileName}", FileMode.Create))
                        {
                            //byte[] bytes = await msg.Content.ReadAsByteArrayAsync();
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

        #region ValidateDownloads
        private bool CheckTotalDownloads()
        {
            if (!IsTotalDownloadsEnabled)
            {
                return true;
            }

            return _totalCount++ < TotalDownloads;
        }

        private bool CheckDownloadLimit(int downloadCount, int downloadLimit)
        {
            if (downloadLimit == 0)
            {
                return true;
            }

            return downloadCount < downloadLimit;
        }
        #endregion

        #endregion

    }
}
