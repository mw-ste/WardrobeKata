using System;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            const int wallSize = 250;
            var wardrobeSizes = new [] { 50, 75, 100, 120 };
            var wardrobes = wardrobeSizes.Select(size => new Wardrobe(size));

            var wardrobeConfigurator = new WardrobeConfigurator(wallSize);
            var possibleConfigurations = wardrobeConfigurator.GetPossibleConfigurations(wardrobes).ToList();

            Console.WriteLine($"Found {possibleConfigurations.Count} possible configurations");
            possibleConfigurations.ForEach(configuration => Console.WriteLine(string.Join(", ", configuration.Wardrobes)));
        }
    }
}
