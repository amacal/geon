using System.IO;

namespace Geon
{
    public class GeoConfiguration : GeoConfigurator
    {
        private GeoFormat format;
        private GeoSource source;
        private GeoReader reader;

        public void Source(GeoSource source)
        {
            this.source = source;
        }

        public void Reader(GeoReader reader)
        {
            this.reader = reader;
        }

        public void Format(GeoFormat format)
        {
            this.format = format;
        }

        public Geo Instantiate()
        {
            using (Stream stream = format.Convert(source.Open()))
            {
                return new GeoService(reader.GetEntries(stream));
            }
        }
    }
}