namespace Geon.Sources
{
    public class MaxMindSource : OnlineSource
    {
        public const string GeoLiteUri = "http://geolite.maxmind.com/download/geoip/database/GeoIPCountryCSV.zip";

        public MaxMindSource()
            : base(GeoLiteUri)
        {
        }
    }
}