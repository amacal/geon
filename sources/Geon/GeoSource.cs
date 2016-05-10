using System.IO;

namespace Geon
{
    public interface GeoSource
    {
        Stream Open();
    }
}