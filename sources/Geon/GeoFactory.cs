using Geon.Formats;
using Geon.Readers;
using Geon.Sources;
using System;

namespace Geon
{
    public static class GeoFactory
    {
        public static Geo Open()
        {
            return Open(with => { });
        }

        public static Geo Open(Action<GeoConfigurator> with)
        {
            GeoConfiguration configurator = new GeoConfiguration();

            configurator.Reader(new CsvReader());
            configurator.Format(new ZipFormat());
            configurator.Source(new MaxMindSource());

            with.Invoke(configurator);
            return configurator.Instantiate();
        }
    }
}