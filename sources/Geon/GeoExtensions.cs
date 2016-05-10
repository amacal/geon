using System.Net;
using System.Net.Sockets;

namespace Geon
{
    public static class GeoExtensions
    {
        public static GeoData Find(this Geo target, IPAddress address)
        {
            return target.Find(address.GetAddressBytes());
        }

        public static GeoData Find(this Geo target, string hostOrAddress)
        {
            foreach (IPAddress address in Dns.GetHostAddresses(hostOrAddress))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return target.Find(address.GetAddressBytes());
                }
            }

            return null;
        }
    }
}