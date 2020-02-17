using System;

using Xamarin.Forms;

namespace SalesApp
{
    public interface IDownloader
    {
        void DownloadFile(string url, string folder);
        void SaveFile(byte[] bytes, string folder);
        event EventHandler<DownloadEventArgs> OnFileDownloaded;
    }

    public class DownloadEventArgs : EventArgs
    {
        public bool FileSaved = false;
        public DownloadEventArgs(bool fileSaved)
        {
            FileSaved = fileSaved;
        }
    }
}

