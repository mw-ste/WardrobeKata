using System;
using Xunit;

namespace Wardrobe.UnitTests
{
    public class WardrobeShould
    {
        [Fact]
        public void BeEqual()
        {
            Assert.Equal(new Wardrobe(42), new Wardrobe(42));
        }

        [Fact]
        public void NotBeEqual()
        {
            Assert.NotEqual(new Wardrobe(42), new Wardrobe(42 + 1));
        }

        [Fact]
        public void RaiseExceptionForValueZeroOrSmaller()
        {
            Assert.Throws<ArgumentException>(() => new Wardrobe(0));
            Assert.Throws<ArgumentException>(() => new Wardrobe(-1));
        }
    }
}