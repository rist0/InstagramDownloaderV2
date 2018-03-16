namespace InstagramDownloaderV2.Interfaces
{
    public interface ISerialize
    {
        void Save<T>(string filePath, T objectToWrite);
        T Load<T>(string filePath);
    }
}
