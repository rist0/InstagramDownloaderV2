using System;

namespace InstagramDownloaderV2.Classes.CSV
{
    class CsvData
    {
        public string FileName { get; set; }
        public string ShortCode { get; set; }
        public string DisplaySrc { get; set; }
        public string MediaId { get; set; }
        public string Dimensions { get; set; }
        public string Caption { get; set; }
        public long Likes { get; set; }
        public long Comments { get; set; }
        public bool? CommentsDisabled { get; set; }
        public bool IsVideo { get; set; }
        public long VideoViews { get; set; }
        public DateTime Date { get; set; }
    }
}
