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
            return Stuff(new WardrobeConfiguration(new List<Wardrobe>()), list);
        }

        private IEnumerable<WardrobeConfiguration> Stuff(WardrobeConfiguration soFar, List<Wardrobe> remaining)
        {
            var list = new List<WardrobeConfiguration>();
            
            var remainingSpace = WallSize - soFar.Size;

            if (remainingSpace == 0)
            {
                list.Add(soFar);
                return list;
            }
            
            if (!remaining.Any() || remainingSpace < 0)
            {
                return list;
            }

            var rec = remaining.SelectMany(r =>
            {
                var newSoFar = new WardrobeConfiguration(soFar.Wardrobes.Append(r));
                var newRemaining = remaining.Where(x => x.Size <= r.Size).ToList();
                return Stuff(newSoFar, newRemaining);
            });


            list.AddRange(rec);

            return list;
        }
    }
}