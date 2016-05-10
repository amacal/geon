using Geon.Readers;

namespace Geon
{
    public static class GeoConfiguratorExtensions
    {
        public static void Csv(this GeoConfigurator configurator)
        {
            configurator.Reader(new CsvReader());
        }
    }
}