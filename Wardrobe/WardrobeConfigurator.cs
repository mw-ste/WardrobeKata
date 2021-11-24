using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    public class WardrobeConfigurator
    {
        private int WallSize { get; }

        public WardrobeConfigurator(int wallSize)
        {
            WallSize = wallSize;
        }

        public IEnumerable<WardrobeConfiguration> GetPossibleConfigurations(IEnumerable<Wardrobe> availableWardrobes)
        {
            var list = availableWardrobes.Distinct().ToList();
            return GetPossibleConfigurationsRecursive(new WardrobeConfiguration(new List<Wardrobe>()), list);
        }

        private IEnumerable<WardrobeConfiguration> GetPossibleConfigurationsRecursive(
            WardrobeConfiguration wardrobeConfigrationSoFar,
            IReadOnlyList<Wardrobe> remainingWardrobes)
        {
            var remainingSpace = WallSize - wardrobeConfigrationSoFar.Size;

            if (remainingSpace == 0)
            {
                return new List<WardrobeConfiguration> { wardrobeConfigrationSoFar };
            }

            if (!remainingWardrobes.Any() || remainingSpace < 0)
            {
                return Enumerable.Empty<WardrobeConfiguration>();
            }

            return remainingWardrobes.SelectMany(wardrobe =>
            {
                var newWardrobeConfiguration = wardrobeConfigrationSoFar.WithAdditionalWardrobes(wardrobe);
                var newRemainingWardrobes = remainingWardrobes.Where(x => x.Size <= wardrobe.Size).ToList();
                return GetPossibleConfigurationsRecursive(newWardrobeConfiguration, newRemainingWardrobes);
            });
        }
    }
}