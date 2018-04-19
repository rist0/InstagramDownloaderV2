using InstagramDownloaderV2.Classes.Downloader;
using System;
using System.IO;
using System.Windows.Forms;

namespace InstagramDownloaderV2.Classes.Validation
{
    class InputValidation
    {
        public static bool IsDouble(string input) => double.TryParse(input, out double result);
        public static bool IsInt(string input) => int.TryParse(input, out int result);

        public static string GetUriExtension(string uri)
        {
            var imageUri = new Uri(uri);

            var imagePath =
                $"{imageUri.Scheme}{Uri.SchemeDelimiter}{imageUri.Authority}{imageUri.AbsolutePath}";

            return Path.GetExtension(imagePath);
        }

        internal static bool IsCharEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        internal static bool IsCharDigit(char c) => c >= '0' && c <= '9';

        public static bool IsValidInstagramUsername(string input)
        {
            if (input.Length > 30) return false;

            foreach (char c in input)
            {
                if (c != '.' && c != '_' && !IsCharDigit(c) && !IsCharEnglishLetter(c)) return false;
            }

            return true;
        }

        public static bool ConfirmUserAction(object sender)
        {
            switch (sender)
            {
                case Button b:
                    switch (b.Name)
                    {
                        case "btnClearAllInput":
                            if (MessageBox.Show(@"Do you want to clear all input? This will remove the current input you are typing along with all previously added inputs.", @"Confirm your action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                return true;
                            }

                            break;
                        case "btnStopDownloading":
                            if (MessageBox.Show($@"Do you want to stop the download process? {Environment.NewLine} NOTE: You can't resume where you last stopped.", @"Confirm your action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                return true;
                            }

                            break;
                    }
                    break;
                case ToolStripMenuItem menuItem:
                    switch (menuItem.Name)
                    {
                        case "resetAllFilterToolStripMenuItem":
                            if (MessageBox.Show($@"Do you want to reset all filters? {Environment.NewLine} NOTE: You can't undo this action.", @"Confirm your action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                return true;
                            }

                            break;
                    }
                    break;
                default:
                    return false;
            }

            return false;
        }

        public static Tuple<bool, string> ValidExportFile()
        {
            using (SaveFileDialog sfd = new SaveFileDialog
                {
                    Title = @"Export file",
                    Filter = @"Text Files (.txt)|*.txt|Csv Files (.csv)|*.csv"
                })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    return new Tuple<bool, string>(true, sfd.FileName);
                }
            }

            return new Tuple<bool, string>(false, null);
        }

        public static bool ValidateWebSettings(string userAgent, string requestTimeout, string proxy, char proxyDelimiter, string threads)
        {
            if (String.IsNullOrEmpty(userAgent) || String.IsNullOrWhiteSpace(userAgent)) return false;

            if (String.IsNullOrEmpty(requestTimeout) || String.IsNullOrWhiteSpace(requestTimeout) || !IsDouble(requestTimeout)) return false;

            if (!String.IsNullOrEmpty(proxy) && !String.IsNullOrWhiteSpace(proxy))
                if (proxy.Split(proxyDelimiter).Length != 2 && proxy.Split(proxyDelimiter).Length != 4) return false;

            if (String.IsNullOrEmpty(threads) || String.IsNullOrWhiteSpace(threads) || !IsInt(threads)) return false;

            return true;
        }

        public static bool ValidateDownloadSettings(string downloadFolder, bool saveStats, string delimiter)
        {
            if (String.IsNullOrEmpty(downloadFolder) || string.IsNullOrWhiteSpace(downloadFolder)) return false;

            if (saveStats && (String.IsNullOrEmpty(delimiter) || String.IsNullOrWhiteSpace(delimiter))) return false;

            return true;
        }

        public static bool ValidateFilters(MediaFilter mediaFilter)
        {
            if (mediaFilter.SkipMediaIfDescriptionContans && !(mediaFilter.DescriptionStrings.Count > 0)) return false;

            if (mediaFilter.SkipMediaLikes && !(mediaFilter.SkipMediaLikesCount > 0)) return false;

            if (mediaFilter.SkipMediaComments && !(mediaFilter.SkipMediaCommentsCount > 0)) return false;

            if (mediaFilter.SkipMediaVideoViews && !(mediaFilter.SkipMediaVideoViewsCount > 0)) return false;

            return true;
        }
    }
}
