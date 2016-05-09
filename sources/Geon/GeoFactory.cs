using Geon.Readers;
using System;
using System.IO;
using System.Net;

namespace Geon
{
    public static class GeoFactory
    {
        public static Geo Csv(string filename)
        {
            return StreamToCsv(File.OpenRead(filename));
        }

        public static Geo Csv(Uri url)
        {
            using (WebClient client = new WebClient())
            {
                byte[] data = client.DownloadData(url);
                MemoryStream stream = new MemoryStream(data);

                return StreamToCsv(stream);
            }
        }

        public static Geo Csv(Stream stream)
        {
            return ReaderToCsv(new GeoCsvReader(stream));
        }

        private static Geo StreamToCsv(Stream stream)
        {
            using (Stream scope = stream)
            {
                return ReaderToCsv(new GeoCsvReader(scope));
            }
        }

        private static Geo ReaderToCsv(GeoReader reader)
        {
            return new GeoService(reader.GetEntries());
        }
    }
}