using System.Collections.Generic;

namespace InstagramDownloaderV2.Classes.Validation
{
    class MediaFilterValidation
    {
        /// <summary>
        /// Skip media based on likes
        /// </summary>
        /// <param name="more">If true, it will skip medias with likes greater than the filterCount</param>
        /// <param name="currentCount">The amount of likes the media has</param>
        /// <param name="filterCount">The amount of likes to use to filter</param>
        /// <returns>true, if it should be skipped</returns>
        /// <returns>false, if it should be downloaded</returns>
        public static bool SkipMediaLikes(bool more, long currentCount, int filterCount)
        {
            if (more)
            {
                if (currentCount > filterCount)
                {
                    return true;
                }
                return false;
            }

            if (currentCount < filterCount)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Skip media based on comments
        /// Returns true, if it should be skipped
        /// Returns false, if it should be downloaded
        /// </summary>
        /// <param name="more">If true, it will skip medias with comments greater than the filterCount</param>
        /// <param name="currentCount">The amount of comments the media has</param>
        /// <param name="filterCount">The amount of comments to use to filter</param>
        /// <returns>true, if it should be skipped</returns>
        /// <returns>false, if it should be downloaded</returns>
        public static bool SkipMediaComments(bool more, long currentCount, int filterCount)
        {
            if (more)
            {
                if (currentCount > filterCount)
                {
                    return true;
                }
                return false;
            }

            if (currentCount < filterCount)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Skip media if it's a video
        /// </summary>
        /// <param name="isVideo">Is media a video</param>
        /// <returns>True, if it should be skipped</returns>
        public static bool SkipMediaIfVideo(bool isVideo)
        {
            return isVideo;
        }

        /// <summary>
        /// Skip media if it's a photo
        /// </summary>
        /// <param name="isPhoto">Is media a photo</param>
        /// <returns>True, if it should be skipped</returns>
        public static bool SkipMediaIfPhoto(bool isPhoto)
        {
            return isPhoto;
        }

        /// <summary>
        /// Skip media if description contains a specific string
        /// </summary>
        /// <param name="description">Description of the media</param>
        /// <param name="strings">A list of strings to check</param>
        /// <returns>True, if it should be skipped</returns>
        public static bool SkipMediaIfDescriptionContains(string description, List<string> strings)
        {
            foreach (string s in strings)
            {
                if (description.Contains(s)) return true;
            }

            return false;
        }

        /// <summary>
        /// Skip media if older/newer than specific date
        /// </summary>
        /// <param name="uploadDate">the date the media was uploaded</param>
        /// <param name="filterDate">the date used to filter</param>
        /// <param name="newer">whether to filter newer or older medias</param>
        /// <returns>True, if it should be skipped</returns>
        public static bool SkipMediaUploadDate(long uploadDate, long filterDate, bool newer)
        {
            if (newer)
            {
                return uploadDate > filterDate;
            }

            return uploadDate < filterDate;
        }

        /// <summary>
        /// Skip media if it's a video and has more/less views
        /// </summary>
        /// <param name="videoViews"></param>
        /// <param name="filterVideoViews"></param>
        /// <param name="more"></param>
        /// <returns></returns>
        public static bool SkipMediaVideoViews(long videoViews, long filterVideoViews, bool more)
        {
            if (more)
            {
                return videoViews > filterVideoViews;
            }

            return videoViews < filterVideoViews;
        }

    }
}
