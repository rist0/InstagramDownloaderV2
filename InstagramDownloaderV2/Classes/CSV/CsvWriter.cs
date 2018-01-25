using System.IO;

namespace InstagramDownloaderV2.Classes.CSV
{
    class CsvWriter
    {
        private readonly char _delimiter;

        public CsvWriter(char delimiter)
        {
            _delimiter = delimiter;
        }

        /// <summary>
        /// Write a new record.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="contents"></param>
        public void Write (string filePath, string[] contents)
        {
            File.AppendAllLines(filePath, contents);
        }

        /// <summary>
        /// Write the headers of the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public void WriteHeader(string filePath, bool overwrite = true)
        {
            if (overwrite && File.Exists(filePath)) File.Delete(filePath);

            string[] fileHeader =
            {
                "File name" + _delimiter +
                "Shortcode" + _delimiter +
                "Display URL" + _delimiter +
                "Media ID" + _delimiter +
                "Dimensions" + _delimiter +
                "Caption" + _delimiter +
                "Likes" + _delimiter +
                "Comments" + _delimiter +
                "Comments Disabled" + _delimiter +
                "Is Video" + _delimiter +
                "Video views" + _delimiter +
                "Upload date"
            };

            File.AppendAllLines(filePath, fileHeader);
        }
    }
}
