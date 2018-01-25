using System.IO;
using InstagramDownloaderV2.Interfaces;

namespace InstagramDownloaderV2.Classes.Serialization
{
    class BinarySerialization : ISerialize
    {
        public void Save<T>(string filePath, T objectToWrite)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(fs, objectToWrite);
            }
        }

        public T Load<T>(string filePath)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(fs);
            }
        }
    }
}
