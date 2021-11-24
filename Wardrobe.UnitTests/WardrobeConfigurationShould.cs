using System.Linq;
using Xunit;

namespace Wardrobe.UnitTests
{
    public class WardrobeConfigurationShould
    {
        private readonly WardrobeConfiguration _sut;
        private readonly Wardrobe[] _wardrobes = { new Wardrobe(1, 2), new Wardrobe(2, 4), new Wardrobe(5, 10) };

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
        public void ReturnNewInstanceWhenAddingWardrobes()
        {
            var newWardrobe = new Wardrobe(11, 22);

            var result = _sut.WithAdditionalWardrobes(newWardrobe);

            Assert.NotSame(_sut, result);
            Assert.Equal(_sut.Wardrobes.Count() + 1, result.Wardrobes.Count());
            Assert.Contains(newWardrobe, result.Wardrobes);

            foreach (var wardrobe in _wardrobes)
            {
                Assert.Contains(wardrobe, result.Wardrobes);
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
        public void CalculateCorrectOverallCost()
        {
            const int expectedCost = 16;

            var result = _sut.Cost;

            Assert.Equal(expectedCost, result);
        }


        [Fact]
        public void ReturnEqualForEqualConfigurations()
        {
            var otherWardrobes = new [] { new Wardrobe(1, 2), new Wardrobe(5, 10), new Wardrobe(2, 4) };
            var other = new WardrobeConfiguration(otherWardrobes);

            Assert.Equal(_sut, other);
            Assert.True(_sut.Equals(other));
        }

        [Fact]
        public void ReturnNotEqualForConfigurationsOfDifferentLength()
        {
            var other = _sut.WithAdditionalWardrobes(new Wardrobe(12, 24));

            Assert.NotEqual(_sut, other);
            Assert.False(_sut.Equals(other));
        }

        [Fact]
        public void ReturnNotEqualForDifferentConfigurations()
        {
            var other = new WardrobeConfiguration(new[] { new Wardrobe(1, 2), new Wardrobe(2, 4), new Wardrobe(3, 6) });

            Assert.NotEqual(_sut, other);
            Assert.False(_sut.Equals(other));
        }

        [Fact]
        public void ReturnNotEqualForConfigurationsThatAreNull()
        {
            var other = (WardrobeConfiguration)null;
            Assert.NotEqual(_sut, other);
            Assert.False(_sut.Equals(other));
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

        [Fact]
        public void ReturnStringRepresentation()
        {
            var expectedString =
                "overall size: 8, " +
                "overall cost: 16, " +
                "wardrobes: " + string.Join(", ", _sut.Wardrobes.Select(w => w.Size));

            var result = _sut.ToString();

            Assert.Equal(expectedString, result);
        }
    }
}