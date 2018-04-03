using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using InstagramDownloaderV2.Classes.Objects.JsonObjects;

namespace InstagramDownloaderV2.Classes.CSV
{
    class Csv : IDisposable
    {
        private readonly CsvWriter _csvWriter;
        private readonly TextWriter _textWriter;
        private bool _isHeaderWritten;

        public Csv(string filePath, string delimiter, bool writeHeader = true)
        {
            _textWriter = new StreamWriter(filePath, true, Encoding.UTF8);

            _csvWriter = new CsvWriter(_textWriter, true);
            _csvWriter.Configuration.QuoteAllFields = true;
            _csvWriter.Context.LeaveOpen = true;
            _csvWriter.Context.SerializerConfiguration.Delimiter = delimiter;

            _isHeaderWritten = false;

            if (writeHeader && !_isHeaderWritten)
                WriteHeader();
        }

        public async Task WriteContent(PhotoData data)
        {
            var extension = data.IsVideo ? "mp4" : "jpg";

            var csvData = new CsvData
            {
                FileName = $"{data.MediaId}.{extension}",
                ShortCode = data.MediaShortCode,
                DisplaySrc = data.DisplayUrl,
                MediaId = data.MediaId,
                Dimensions = $"W: {data.MediaDimensions.Width} H: {data.MediaDimensions.Height}",
                Caption = data.Caption.Edges.Count > 0 ? data.Caption.Edges[0].Node.CaptionText : string.Empty,
                Likes = data.Likes.Count,
                Comments = data.Comments.Count,
                CommentsDisabled = data.CommentsDisabled,
                IsVideo = data.IsVideo,
                VideoViews = data.VideoViewCount,
                Date = DateTimeOffset.FromUnixTimeSeconds(data.UploadTimestamp).LocalDateTime
            };

            _csvWriter.WriteRecord(csvData);
            await _csvWriter.NextRecordAsync();
        }

        public async Task WriteContent(UserPhotoData data)
        {
            var extension = data.IsVideo ? "mp4" : "jpg";

            var csvData = new CsvData
            {
                FileName = $"{data.Id}.{extension}",
                ShortCode = data.ShortCode,
                DisplaySrc = data.DisplaySrc,
                MediaId = data.Id,
                Dimensions = $"W: {data.Dimensions.Width} H: {data.Dimensions.Height}",
                Caption = data.Caption.Length > 0 ? data.Caption : string.Empty,
                Likes = data.Likes.Count,
                Comments = data.Comments.Count,
                CommentsDisabled = data.CommentsDisabled,
                IsVideo = data.IsVideo,
                VideoViews = data.VideoViews,
                Date = DateTimeOffset.FromUnixTimeSeconds(data.TakenAtTimestamp).LocalDateTime
            };

            _csvWriter.WriteRecord(csvData);
            await _csvWriter.NextRecordAsync();
        }

        public async Task WriteContent(EdgeHashtagToMediaEdge data)
        {
            var extension = data.Node.IsVideo ? "mp4" : "jpg";

            var csvData = new CsvData
            {
                FileName = $"{data.Node.Id}.{extension}",
                ShortCode = data.Node.Shortcode,
                DisplaySrc = data.Node.DisplayUrl,
                MediaId = data.Node.Id,
                Dimensions = $"W: {data.Node.Dimensions.Width} H: {data.Node.Dimensions.Height}",
                Caption = data.Node.CaptionEdge.CaptionTextEdge.Count > 0 ?
                    data.Node.CaptionEdge.CaptionTextEdge[0].CaptionText.Text : string.Empty,
                Likes = data.Node.Likes.Count,
                Comments = data.Node.Comments.Count,
                CommentsDisabled = data.Node.CommentsDisabled,
                IsVideo = data.Node.IsVideo,
                VideoViews = data.Node.VideoViewCount,
                Date = DateTimeOffset.FromUnixTimeSeconds(data.Node.TakenAtTimestamp).LocalDateTime
            };

            _csvWriter.WriteRecord(csvData);
            await _csvWriter.NextRecordAsync();
        }

        public async Task WriteContent(OwnerMediaEdge data)
        {
            var extension = data.Node.IsVideo ? "mp4" : "jpg";

            var csvData = new CsvData
            {
                FileName = $"{data.Node.Id}.{extension}",
                ShortCode = data.Node.ShortCode,
                DisplaySrc = data.Node.DisplayUrl,
                MediaId = data.Node.Id,
                Dimensions = $"W: {data.Node.Dimensions.Width} H: {data.Node.Dimensions.Height}",
                Caption = data.Node.EdgeMediaToCaption.Edges.Any() ? data.Node.EdgeMediaToCaption.Edges[0].Node.Text : "",
                Likes = data.Node.Likes.Count,
                Comments = data.Node.Comments.Count,
                CommentsDisabled = data.Node.CommentsDisabled,
                IsVideo = data.Node.IsVideo,
                VideoViews = data.Node.VideoViews,
                Date = DateTimeOffset.FromUnixTimeSeconds(data.Node.TakenAtTimestamp).LocalDateTime
            };

            _csvWriter.WriteRecord(csvData);
            await _csvWriter.NextRecordAsync();
        }

        public async void WriteHeader()
        {
            _csvWriter.WriteHeader<CsvData>();
            await _csvWriter.NextRecordAsync();
            _isHeaderWritten = true;
        }

        public void Dispose()
        {
            _textWriter.Dispose();
            _csvWriter.Dispose();
        }
    }
}
