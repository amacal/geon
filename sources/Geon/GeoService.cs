using System;
using System.Collections.Generic;
using System.Linq;

namespace Geon
{
    public class GeoService : Geo
    {
        private readonly GeoEntry[] entries;

        public GeoService(IEnumerable<GeoEntry> entries)
        {
            this.entries = entries.ToArray();
        }

        public GeoData Find(byte[] address)
        {
            return Find(ToNumber(address));
        }

        private GeoData Find(uint address)
        {
            GeoRangeComparer comparer = new GeoRangeComparer();
            GeoRange range = new GeoRange { From = address, To = address };

            int index = Array.BinarySearch(entries, range, comparer);
            if (index < 0) return GeoData.Nothing;

            return new GeoData
            {
                Code = entries[index].Code,
                Name = entries[index].Name
            };
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