using System.Collections.Generic;

namespace Geon
{
    public interface GeoReader
    {
        IEnumerable<GeoEntry> GetEntries();
    }
}