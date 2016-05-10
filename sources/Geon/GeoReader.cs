using System.Collections.Generic;
using System.IO;

namespace Geon
{
    public interface GeoReader
    {
        IEnumerable<GeoEntry> GetEntries(Stream stream);
    }
}