using FluentAssertions;
using NUnit.Framework;

namespace Geon.Tests
{
    [TestFixture]
    public class GeoServiceTests
    {
        [Test]
        public void LookingForExistingEntryShouldProvideResult()
        {
            GeoEntry[] entries = new GeoEntry[]
            {
                new GeoEntry { From = 1, To = 255, Code = "XX", Name = "Far away" }
            };

            GeoService service = new GeoService(entries);
            GeoData data = service.Find(new byte[] { 0, 0, 0, 13 });

            data.Code.Should().Be("XX");
            data.Name.Should().Be("Far away");
        }

        [Test]
        public void LookingForNotExistingEntryShouldProvideNoData()
        {
            GeoEntry[] entries = new GeoEntry[0];
            GeoService service = new GeoService(entries);

            GeoData data = service.Find(new byte[] { 0, 0, 0, 13 });

            data.Should().BeSameAs(GeoData.Nothing);
        }
    }
}