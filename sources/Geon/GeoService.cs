using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Geon
{
    public class GeoService : Geo
    {
        private readonly GeoEntry[] entries;

        public GeoService(IEnumerable<GeoEntry> entries)
        {
            this.entries = entries.ToArray();
        }

        public GeoData Find(string hostOrAddress)
        {
            foreach (IPAddress address in Dns.GetHostAddresses(hostOrAddress))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return Find(address);
                }
            }

            return null;
        }

        public GeoData Find(IPAddress address)
        {
            return Find(ToNumber(address));
        }

        public GeoData Find(byte[] address)
        {
            return Find(ToNumber(address));
        }

        private GeoData Find(uint address)
        {
            GeoRangeComparer comparer = new GeoRangeComparer();
            GeoRange range = new GeoRange
            {
                From = address,
                To = address
            };

            int index = Array.BinarySearch(entries, range, comparer);
            GeoEntry entry = entries[index];

            return new GeoData
            {
                Code = entry.Code,
                Name = entry.Name
            };
        }

        private static uint ToNumber(IPAddress address)
        {
            return ToNumber(address.GetAddressBytes());
        }

        private static uint ToNumber(byte[] data)
        {
            uint result = 0;

            foreach (byte value in data)
            {
                result = result * 256 + value;
            }

            return result;
        }
    }
}