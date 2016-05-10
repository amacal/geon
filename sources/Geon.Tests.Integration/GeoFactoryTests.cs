using FluentAssertions;
using NUnit.Framework;

namespace Geon.Tests.Integration
{
    [TestFixture]
    public class GeoFactoryTests
    {
        [Test]
        public void CanOpenDefault()
        {
            Geo geo = GeoFactory.Open();

            GeoData data = geo.Find("microsoft.com");

            data.Code.Should().Be("US");
        }
    }
}