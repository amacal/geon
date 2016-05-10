using System.IO;
using System.Net;

namespace Geon.Sources
{
    public class OnlineSource : GeoSource
    {
        private readonly string uri;

        public OnlineSource(string uri)
        {
            this.uri = uri;
        }

        public Stream Open()
        {
            using (WebClient client = new WebClient())
            {
                byte[] data = client.DownloadData(uri);
                MemoryStream memory = new MemoryStream(data);

                return memory;
            }
        }
    }
}