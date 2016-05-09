using FluentAssertions;
using NUnit.Framework;

namespace Geon.Tests.Integration
{
    [TestFixture]
    public class CsvFileTests
    {
        [Test]
        public void CanOpenExistingFile()
        {
            string filename = @"d:\Drive\Projects\GeoIPCountryWhois.csv";
            Geo geo = GeoFactory.Csv(filename);

            GeoData data = geo.Find("microsoft.com");

            data.Code.Should().Be("US");
        }
    }
}