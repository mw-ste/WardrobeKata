using System;

namespace Wardrobe
{
    public record Wardrobe
    {
        public Wardrobe(int size)
        {
            Size = GetCheckedValue(size);
        }

        private static int GetCheckedValue(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Value must be larger than 0, but was {value}!");
            }

            return value;
        }

        public int Size { get; init; }
        
    }
}