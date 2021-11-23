using System.Linq;
using Xunit;

namespace Wardrobe.UnitTests
{
    public class WardrobeConfigurationShould
    {
        private readonly WardrobeConfiguration _sut;
        private readonly Wardrobe[] _wardrobes = { new Wardrobe(1), new Wardrobe(2), new Wardrobe(5) };

        public WardrobeConfigurationShould()
        {
            _sut = new WardrobeConfiguration(_wardrobes);
        }

        [Fact]
        public void ContainAddedWardrobes()
        {
            Assert.Equal(_wardrobes.Length, _sut.Wardrobes.Count());
            foreach (var wardrobe in _wardrobes)
            {
                Assert.Contains(wardrobe, _sut.Wardrobes);
            }
        }

        [Fact]
        public void CalculateCorrectOverallSize()
        {
            const int expectedSize = 8;

            var result = _sut.Size;

            Assert.Equal(expectedSize, result);
        }


        [Fact]
        public void ReturnEqualForEqualConfigurations()
        {
            var otherWardrobes = new [] { new Wardrobe(1), new Wardrobe(5), new Wardrobe(2) };
            var other = new WardrobeConfiguration(otherWardrobes);

            Assert.Equal(_sut, other);
        }

        [Fact]
        public void ReturnNotEqualForConfigurationsOfDifferentLength()
        {
            var other = new WardrobeConfiguration(_wardrobes);
            other.Add(new Wardrobe(12));

            Assert.NotEqual(_sut, other);
        }

        [Fact]
        public void ReturnNotEqualForDifferentConfigurations()
        {
            var other = new WardrobeConfiguration(new[] { new Wardrobe(1), new Wardrobe(2), new Wardrobe(3) });

            Assert.NotEqual(_sut, other);
        }

        [Fact]
        public void ReturnNotEqualForConfigurationsThatAreNull()
        {
            var nullWardrobe = (WardrobeConfiguration)null;
            Assert.NotEqual(_sut, nullWardrobe);
        }

        [Fact]
        public void ReturnWardrobesOrderedBySize()
        {
            var other = new WardrobeConfiguration(_wardrobes.Reverse());

            var result = other.Wardrobes.ToList();

            Assert.Equal(5, result[0].Size);
            Assert.Equal(2, result[1].Size);
            Assert.Equal(1, result[2].Size);
        }
    }
}