using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramDownloaderV2.Interfaces
{
    public interface ISerialize
    {
        void Save<T>(string filePath, T objectToWrite);
        T Load<T>(string filePath);
    }
}
