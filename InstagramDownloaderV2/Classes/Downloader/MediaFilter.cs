using System.Collections.Generic;
using InstagramDownloaderV2.Classes.Objects.JsonObjects;
using InstagramDownloaderV2.Classes.Validation;

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
        public long SkipMediaUploadDate { get; set; }

        public bool SkipTopPosts { get; set; }

        public bool CustomFolder { get; set; }

        public bool SaveStatsInCsvFile { get; set; }

        /// <summary>
        /// Applies media filters to single url data.
        /// </summary>
        /// <param name="photoData"></param>
        /// <returns>True, if it should be skipped.</returns>
        public bool CheckAllPhotoFilters(PhotoData photoData)
        {
            if (SkipMediaIfVideo)
            {
                if (MediaFilterValidation.SkipMediaIfVideo(photoData.IsVideo)) return true;
            }

            if (SkipMediaIfPhoto)
            {
                if (MediaFilterValidation.SkipMediaIfPhoto(!photoData.IsVideo)) return true;
            }

            if (SkipMediaIfDescriptionContans)
            {
                if(photoData.Caption.Edges.Count > 0)
                    if (MediaFilterValidation.SkipMediaIfDescriptionContains(photoData.Caption.Edges[0].Node.CaptionText, DescriptionStrings)) return true;
            }

            if (SkipMediaLikes)
            {
                if (MediaFilterValidation.SkipMediaLikes(SkipMediaLikesMore, photoData.Likes.Count, SkipMediaLikesCount)) return true;
            }

            if (SkipMediaComments)
            {
                if (MediaFilterValidation.SkipMediaComments(SkipMediaCommentsMore, photoData.Comments.Count, SkipMediaCommentsCount)) return true;
            }

            if (SkipMediaUploadDateEnabled)
            {
                if (MediaFilterValidation.SkipMediaUploadDate(photoData.UploadTimestamp, SkipMediaUploadDate, SkipMediaUploadDateNewer)) return true;
            }

            if (SkipMediaVideoViews)
            {
                if (!MediaFilterValidation.SkipMediaIfVideo(photoData.IsVideo)) return true;
                if (MediaFilterValidation.SkipMediaVideoViews(photoData.VideoViewCount, SkipMediaVideoViewsCount, SkipMediaVideoViewsMore)) return true;
            }

            return false;
        }

        /// <summary>
        /// Applies media filters to user+location type of data.
        /// </summary>
        /// <param name="photoData"></param>
        /// <returns>True, if it should be skipped.</returns>
        public bool CheckAllUsernameFilters(OwnerMediaEdge photoData)
        {
            if (SkipMediaIfVideo)
            {
                if (MediaFilterValidation.SkipMediaIfVideo(photoData.Node.IsVideo)) return true;
            }

            if (SkipMediaIfPhoto)
            {
                if (MediaFilterValidation.SkipMediaIfPhoto(!photoData.Node.IsVideo)) return true;
            }

            if (SkipMediaIfDescriptionContans)
            {
                if (MediaFilterValidation.SkipMediaIfDescriptionContains(photoData.Node.Caption, DescriptionStrings)) return true;
            }

            if (SkipMediaLikes)
            {
                if (MediaFilterValidation.SkipMediaLikes(SkipMediaLikesMore, photoData.Node.Likes.Count, SkipMediaLikesCount)) return true;
            }

            if (SkipMediaComments)
            {
                if (MediaFilterValidation.SkipMediaComments(SkipMediaCommentsMore, photoData.Node.Comments.Count, SkipMediaCommentsCount)) return true;
            }

            if (SkipMediaUploadDateEnabled)
            {
                if(MediaFilterValidation.SkipMediaUploadDate(photoData.Node.TakenAtTimestamp, SkipMediaUploadDate, SkipMediaUploadDateNewer)) return true;
            }

            if (SkipMediaVideoViews)
            {
                if (!MediaFilterValidation.SkipMediaIfVideo(photoData.Node.IsVideo)) return true;
                if (MediaFilterValidation.SkipMediaVideoViews(photoData.Node.VideoViews, SkipMediaVideoViewsCount, SkipMediaVideoViewsMore)) return true;
            }

            return false;
        }

        /// <summary>
        /// Applies media filters to user+location type of data.
        /// </summary>
        /// <param name="photoData"></param>
        /// <returns>True, if it should be skipped.</returns>
        public bool CheckAllUsernameFilters(UserPhotoData photoData)
        {
            if (SkipMediaIfVideo)
            {
                if (MediaFilterValidation.SkipMediaIfVideo(photoData.IsVideo)) return true;
            }

            if (SkipMediaIfPhoto)
            {
                if (MediaFilterValidation.SkipMediaIfPhoto(!photoData.IsVideo)) return true;
            }

            if (SkipMediaIfDescriptionContans)
            {
                if (MediaFilterValidation.SkipMediaIfDescriptionContains(photoData.Caption, DescriptionStrings)) return true;
            }

            if (SkipMediaLikes)
            {
                if (MediaFilterValidation.SkipMediaLikes(SkipMediaLikesMore, photoData.TotalLikes.Count, SkipMediaLikesCount)) return true;
            }

            if (SkipMediaComments)
            {
                if (MediaFilterValidation.SkipMediaComments(SkipMediaCommentsMore, photoData.TotalComments.Count, SkipMediaCommentsCount)) return true;
            }

            if (SkipMediaUploadDateEnabled)
            {
                if (MediaFilterValidation.SkipMediaUploadDate(photoData.TakenAtTimestamp, SkipMediaUploadDate, SkipMediaUploadDateNewer)) return true;
            }

            if (SkipMediaVideoViews)
            {
                if (!MediaFilterValidation.SkipMediaIfVideo(photoData.IsVideo)) return true;
                if (MediaFilterValidation.SkipMediaVideoViews(photoData.VideoViews, SkipMediaVideoViewsCount, SkipMediaVideoViewsMore)) return true;
            }

            return false;
        }

        /// <summary>
        /// Applies media filters to hashtag type of data.
        /// </summary>
        /// <param name="photoData"></param>
        /// <returns>True, if it should be skipped</returns>
        public bool CheckAllHashtagFilters(HashtagPhotoData photoData)
        {
            if (SkipMediaIfVideo)
            {
                if (MediaFilterValidation.SkipMediaIfVideo(photoData.IsVideo)) return true;
            }

            if (SkipMediaIfPhoto)
            {
                if (MediaFilterValidation.SkipMediaIfPhoto(!photoData.IsVideo)) return true;
            }

            if (SkipMediaIfDescriptionContans)
            {
                if (photoData.CaptionEdge.CaptionTextEdge.Count > 0)
                    if (MediaFilterValidation.SkipMediaIfDescriptionContains(photoData.CaptionEdge.CaptionTextEdge[0].CaptionText.Text, DescriptionStrings)) return true;
            }

            if (SkipMediaLikes)
            {
                if (MediaFilterValidation.SkipMediaLikes(SkipMediaLikesMore, photoData.Likes.Count, SkipMediaLikesCount)) return true;
            }

            if (SkipMediaComments)
            {
                if (MediaFilterValidation.SkipMediaComments(SkipMediaCommentsMore, photoData.Comments.Count, SkipMediaCommentsCount)) return true;
            }

            if (SkipMediaUploadDateEnabled)
            {
                if (MediaFilterValidation.SkipMediaUploadDate(photoData.TakenAtTimestamp, SkipMediaUploadDate, SkipMediaUploadDateNewer)) return true;
            }

            if (SkipMediaVideoViews)
            {
                if (!MediaFilterValidation.SkipMediaIfVideo(photoData.IsVideo)) return true;
                if (MediaFilterValidation.SkipMediaVideoViews(photoData.VideoViewCount, SkipMediaVideoViewsCount, SkipMediaVideoViewsMore)) return true;
            }

            return false;
        }

    }
}
