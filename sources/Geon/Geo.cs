using System.Net;

namespace Geon
{
    public interface Geo
    {
        GeoData Find(byte[] address);

        GeoData Find(IPAddress address);

        GeoData Find(string hostOrAddress);
    }
}