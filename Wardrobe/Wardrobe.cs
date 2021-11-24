using System;

namespace Wardrobe
{
    public record Wardrobe
    {
        public int Size { get; init; }
        public int Cost { get; init; }

        public Wardrobe(int size, int cost)
        {
            Size = GetCheckedValue(size, nameof(Size));
            Cost = GetCheckedValue(cost, nameof(Cost));
        }

        private static int GetCheckedValue(int value, string property)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Value for {property} must be larger than 0, but was {value}!");
            }

            return value;
        }

        public static Wardrobe operator +(Wardrobe some, Wardrobe other) => new Wardrobe(
            some.Size + other.Size,
            some.Cost + other.Cost);

        public void Deconstruct(out int size, out int cost)
        {
            size = Size;
            cost = Cost;
        }
    }
}