namespace Geon
{
    public interface GeoConfigurator
    {
        void Source(GeoSource source);

        void Reader(GeoReader reader);

        void Format(GeoFormat format);
    }
}