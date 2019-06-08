using System;
using System.Configuration;
using System.Linq;

namespace CustomConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var section = ConfigurationManager.GetSection("customSection") as CustomConfigSection;

            foreach (var pair in section.PropertyPairs.Cast<PropertyPair>())
            {
                var txt = $"ID: {pair.Id}, P1: {pair.PropertyOne}, P2: {pair.PropertyTwo}";
                Console.WriteLine(txt);
            }

            Console.ReadLine();
        }
    }
}
