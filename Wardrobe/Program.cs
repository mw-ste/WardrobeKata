using System;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            const int wallSize = 250;
            var wardrobeData = new [] { (50, 59), (75, 62), (100, 90), (120, 111)};
            var wardrobes = wardrobeData.Select(data => new Wardrobe(data.Item1, data.Item2));

            var wardrobeConfigurator = new WardrobeConfigurator(wallSize);
            var possibleConfigurations = wardrobeConfigurator.GetPossibleConfigurations(wardrobes).ToList();

            Console.WriteLine($"Found {possibleConfigurations.Count} possible configurations");
            possibleConfigurations
                .OrderBy(c => c.Cost)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
