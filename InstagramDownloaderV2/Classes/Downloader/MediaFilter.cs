using System;
using System.Collections.Generic;
using InstagramDownloaderV2.Classes.Validation;
using InstaSharper.Classes.Models;

namespace InstagramDownloaderV2.Classes.Downloader
{
    public class MediaFilter
    {
        // Properties
        public bool SkipMediaIfDescriptionContans { get; set; }
        public List<string> DescriptionStrings { get; set; }

        public bool SkipMediaIfVideo { get; set; }

        public bool SkipMediaIfPhoto { get; set; }

        public bool SkipMediaLikes { get; set; }
        public bool SkipMediaLikesMore { get; set; }
        public int SkipMediaLikesCount { get; set; }

        public bool SkipMediaComments { get; set; }
        public bool SkipMediaCommentsMore { get; set; }
        public int SkipMediaCommentsCount { get; set; }

        public bool SkipMediaVideoViews { get; set; }
        public bool SkipMediaVideoViewsMore { get; set; }
        public long SkipMediaVideoViewsCount { get; set; }

        public bool SkipMediaUploadDateEnabled { get; set; }
        public bool SkipMediaUploadDateNewer { get; set; }
        public DateTime SkipMediaUploadDate { get; set; }

        public bool SkipTopPosts { get; set; }

        public bool CustomFolder { get; set; }

        public bool SaveStatsInCsvFile { get; set; }

        public bool CheckFilters(InstaMedia media)
        {
            if (SkipMediaIfVideo)
            {
                if (MediaFilterValidation.SkipMediaIfVideo(media.MediaType == InstaMediaType.Video)) return true;
            }

            if (SkipMediaIfPhoto)
            {
                if (MediaFilterValidation.SkipMediaIfPhoto(media.MediaType == InstaMediaType.Image)) return true;
            }

            if (SkipMediaIfDescriptionContans)
            {
                if (!string.IsNullOrEmpty(media.Caption.Text))
                    if (MediaFilterValidation.SkipMediaIfDescriptionContains(media.Caption.Text, DescriptionStrings)) return true;
            }

            if (SkipMediaLikes)
            {
                if (MediaFilterValidation.SkipMediaLikes(SkipMediaLikesMore, media.LikesCount, SkipMediaLikesCount)) return true;
            }

            if (SkipMediaComments)
            {
                if (MediaFilterValidation.SkipMediaComments(SkipMediaCommentsMore, int.Parse(media.CommentsCount), SkipMediaCommentsCount)) return true;
            }

            if (SkipMediaUploadDateEnabled)
            {
                if (MediaFilterValidation.SkipMediaUploadDate(media.TakenAt, SkipMediaUploadDate, SkipMediaUploadDateNewer)) return true;
            }

            if (SkipMediaVideoViews)
            {
                if (!MediaFilterValidation.SkipMediaIfVideo(media.MediaType == InstaMediaType.Video)) return true;
                if (MediaFilterValidation.SkipMediaVideoViews(media.ViewCount, SkipMediaVideoViewsCount, SkipMediaVideoViewsMore)) return true;
            }

            return false;
        }
        
    }
}
