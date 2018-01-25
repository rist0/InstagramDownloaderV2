using System;
using System.IO;
using System.Windows.Forms;
using InstagramDownloaderV2.Classes.Serialization;
using InstagramDownloaderV2.Interfaces;

namespace InstagramDownloaderV2.Classes.Settings
{
    class SettingsSerialization
    {
        private static readonly ISerialize Serializer = new BinarySerialization();

        public static void Save<T>(T settings)
        {
            string directoryPath = $@"{Application.StartupPath}\data";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = $@"{Application.StartupPath}\data\settings.bin";
            Serializer.Save(filePath, settings);
        }

        public static Settings Load()
        {
            string directoryPath = $@"{Application.StartupPath}\data";
            if (!Directory.Exists(directoryPath))
            {
                throw new Exception("Couldn't find any saved settings. Path doesn't exist.");
            }

            string filePath = $@"{Application.StartupPath}\data\settings.bin";

            return Serializer.Load<Settings>(filePath);
        }
    }
}
