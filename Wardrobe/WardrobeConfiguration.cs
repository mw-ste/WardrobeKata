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
            AddRange(wardrobes);
        }

        public void Add(Wardrobe wardrobe)
        {
            _wardrobes.Add(wardrobe);
        }

        public void AddRange(IEnumerable<Wardrobe> wardrobes)
        {
            _wardrobes.AddRange(wardrobes);
        }

        public int Size => _wardrobes.Select(w => w.Size).Sum();
        
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
    }
}