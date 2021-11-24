using System;
using Xunit;

namespace Wardrobe.UnitTests
{
    public class WardrobeShould
    {
        [Fact]
        public void BeEqual()
        {
            Assert.Equal(new Wardrobe(42, 33), new Wardrobe(42, 33));
        }

        [Fact]
        public void NotBeEqual()
        {
            Assert.NotEqual(new Wardrobe(42, 33), new Wardrobe(42 + 1, 33));
            Assert.NotEqual(new Wardrobe(42, 33), new Wardrobe(42, 33 + 1));
            Assert.NotEqual(new Wardrobe(42, 33), new Wardrobe(42 + 1, 33 + 1));
        }

        [Fact]
        public void RaiseExceptionForValueZeroOrSmaller()
        {
            Assert.Throws<ArgumentException>(() => new Wardrobe(0, 1));
            Assert.Throws<ArgumentException>(() => new Wardrobe(-1, 1));

            Assert.Throws<ArgumentException>(() => new Wardrobe(1, 0));
            Assert.Throws<ArgumentException>(() => new Wardrobe(1, -1));
        }

        [Fact]
        public void DeconstructIntoValues()
        {
            const int cost = 34;
            const int size = 42;

            var sut = new Wardrobe(size, cost);

            var (resultSize, resultCost) = sut;

            Assert.Equal(size, resultSize);
            Assert.Equal(cost, resultCost);
        }

        [Fact]
        public void BeAbleToAddWardrobes()
        {
            const int someCost = 34;
            const int someSize = 42;
            var someWardrobe = new Wardrobe(someSize, someCost);

            const int otherCost = 100;
            const int otherSize = 1;
            var otherWardrobe = new Wardrobe(otherSize, otherCost);


            var result = someWardrobe + otherWardrobe;

            Assert.Equal(someSize + otherSize, result.Size);
            Assert.Equal(someCost + otherCost, result.Cost);
        }
    }
}