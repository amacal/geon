using System.IO;

namespace Geon
{
    public interface GeoFormat
    {
        Stream Convert(Stream source);
    }
}