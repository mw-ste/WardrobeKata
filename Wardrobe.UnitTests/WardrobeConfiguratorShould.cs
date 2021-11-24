using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Wardrobe.UnitTests
{
    public class WardrobeConfiguratorShould
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly WardrobeConfigurator _sut;

        public WardrobeConfiguratorShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _sut = new WardrobeConfigurator(250);
        }

        [Fact]
        public void ReturnEmptyListOfConfigurationsForImpossibleCombinations()
        {
            Assert.Empty(_sut.GetPossibleConfigurations(new[] { new Wardrobe(300, 600) }));
            Assert.Empty(_sut.GetPossibleConfigurations(new[] { new Wardrobe(33, 66) }));
        }

        [Fact]
        public void NotReturnDuplicateConfigurations()
        {
            var result = _sut.GetPossibleConfigurations(new[] { new Wardrobe(50, 100) });

            Assert.Single(result);
        }


        [Fact]
        public void FindAllConfigurations()
        {
            var result = _sut.GetPossibleConfigurations(new[] { new Wardrobe(100, 200), new Wardrobe(50, 100) }).ToList();

            foreach (var r in result)
            {
                _testOutputHelper.WriteLine(string.Join(", ", r.Wardrobes.Select(w => w.Size)));
            }

            Assert.Equal(3, result.Count);

            Assert.Contains(result, r => r.Equals(new WardrobeConfiguration(new[]
            {
                new Wardrobe(100, 200),
                new Wardrobe(100, 200),
                new Wardrobe(50, 100)
            })));

            Assert.Contains(result, r => r.Equals(new WardrobeConfiguration(new[]
            {
                new Wardrobe(100, 200),
                new Wardrobe(50, 100),
                new Wardrobe(50, 100),
                new Wardrobe(50, 100)
            })));

            Assert.Contains(result, r => r.Equals(new WardrobeConfiguration(new[]
            {
                new Wardrobe(50, 100),
                new Wardrobe(50, 100),
                new Wardrobe(50, 100),
                new Wardrobe(50, 100),
                new Wardrobe(50, 100)
            })));
        }
    }
}