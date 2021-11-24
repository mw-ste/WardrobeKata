using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    public class WardrobeConfiguration : IEquatable<WardrobeConfiguration>
    {
        public IEnumerable<Wardrobe> Wardrobes => _wardrobes.OrderBy(w => w.Size).Reverse();
        private readonly List<Wardrobe> _wardrobes = new List<Wardrobe>();

        public WardrobeConfiguration(IEnumerable<Wardrobe> wardrobes)
        {
            _wardrobes.AddRange(wardrobes);
        }

        public WardrobeConfiguration WithAdditionalWardrobes(params Wardrobe[] wardrobes)
        {
            return new WardrobeConfiguration(_wardrobes.Concat(wardrobes).ToList());
        }

        public int Size => _wardrobes.Select(w => w.Size).Sum();
        public int Cost => _wardrobes.Select(w => w.Cost).Sum();

        public override string ToString()
        {
            return $"overall size: {Size}, " +
                   $"overall cost: {Cost}, " +
                   "wardrobes: " + string.Join(", ", Wardrobes.Select(w => w.Size));
        }

        public bool Equals(WardrobeConfiguration other)
        {
            if (other == null)
            {
                return false;
            }

            if (_wardrobes.Count != other.Wardrobes.Count())
            {
                return false;
            }

            return Wardrobes.SequenceEqual(other.Wardrobes);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as WardrobeConfiguration);
        }

        public override int GetHashCode()
        {
            return _wardrobes != null
                ? _wardrobes.GetHashCode()
                : 0;
        }
    }
}