using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using InstagramDownloaderV2.Classes.Validation;
using InstaSharper.Classes.Models;

namespace InstagramDownloaderV2.Classes.CSV
{
    class Csv : IDisposable
    {
        private readonly CsvWriter _csvWriter;
        private readonly TextWriter _textWriter;

        public Csv(string filePath, string delimiter)
        {
            _textWriter = new StreamWriter(filePath, true, Encoding.UTF8);

            _csvWriter = new CsvWriter(_textWriter, true);
            _csvWriter.Configuration.QuoteAllFields = true;
            _csvWriter.Context.LeaveOpen = true;
            _csvWriter.Context.SerializerConfiguration.Delimiter = delimiter;
            
        }

        public async Task WriteContent(InstaMedia media)
        {
            string fileName;
            var width = 0;
            var height = 0;
            var displayUrl = "";

            switch (media.MediaType)
            {
                case InstaMediaType.Image:
                    fileName = media.Pk + InputValidation.GetUriExtension(media.Images[0].URI);
                    width = media.Images[0].Width;
                    height = media.Images[0].Height;
                    displayUrl = media.Images[0].URI;
                    break;
                case InstaMediaType.Video:
                    fileName = media.Pk + InputValidation.GetUriExtension(media.Videos[0].Url);
                    width = media.Videos[0].Width;
                    height = media.Videos[0].Height;
                    displayUrl = media.Videos[0].Url;
                    break;
                case InstaMediaType.Carousel:
                    fileName = "Carousel";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var csvData = new CsvData
            {
                FileName = $"{fileName}",
                ShortCode = media.Code,
                DisplaySrc = displayUrl,
                MediaId = media.Pk,
                Dimensions = $"W: {width} H: {height}",
                Caption = media.Caption?.Text,
                Likes = media.LikesCount.ToString(),
                Comments = media.CommentsCount,
                IsVideo = media.HasAudio,
                VideoViews = media.ViewCount.ToString(),
                Date = media.TakenAt.ToLocalTime()
            };

            _csvWriter.WriteRecord(csvData);
            await _csvWriter.NextRecordAsync();
            
        }

        public async Task WriteContent(InstaCarouselItem media)
        {
            var fileName = "";
            var width = 0;
            var height = 0;
            var displayUrl = "";
            var isVideo = false;

            switch (media.MediaType)
            {
                case InstaMediaType.Image:
                    fileName = media.Pk + InputValidation.GetUriExtension(media.Images[0].URI);
                    width = media.Images[0].Width;
                    height = media.Images[0].Height;
                    displayUrl = media.Images[0].URI;
                    break;
                case InstaMediaType.Video:
                    fileName = media.Pk + InputValidation.GetUriExtension(media.Videos[0].Url);
                    width = media.Videos[0].Width;
                    height = media.Videos[0].Height;
                    displayUrl = media.Videos[0].Url;
                    isVideo = true;
                    break;
            }

            var csvData = new CsvData
            {
                FileName = $"{fileName}",
                ShortCode = "",
                DisplaySrc = displayUrl,
                MediaId = media.Pk,
                Dimensions = $"W: {width} H: {height}",
                Caption = "",
                Likes = "0",
                Comments = "0",
                IsVideo = isVideo,
                VideoViews = "0",
                Date = null
            };

            _csvWriter.WriteRecord(csvData);
            await _csvWriter.NextRecordAsync();
        }

        public async void WriteHeader()
        {
            _csvWriter.WriteHeader<CsvData>();
            await _csvWriter.NextRecordAsync();
        }

        public void Dispose()
        {
            _textWriter.Dispose();
            _csvWriter.Dispose();
        }
    }
}
