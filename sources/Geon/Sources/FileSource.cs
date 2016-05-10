using System.IO;

namespace Geon.Sources
{
    public class FileSource : GeoSource
    {
        private readonly string filename;

        public FileSource(string filename)
        {
            this.filename = filename;
        }

        public Stream Open()
        {
            return File.OpenRead(filename);
        }
    }
}