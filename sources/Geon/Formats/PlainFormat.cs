using System.IO;

namespace Geon.Formats
{
    public class PlainFormat : GeoFormat
    {
        public Stream Convert(Stream source)
        {
            return source;
        }
    }
}