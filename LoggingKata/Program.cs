using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {

            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");


            if (lines == null || lines.Length == 0)
            {
                logger.LogError($"Lines: {lines[0]}");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning($"Lines: {lines[1]}");
            }

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();
       
            ITrackable TrackA = null;
            ITrackable TrackB = null;
          
            double distance = 0;
         

            foreach (var locA in locations)
            {
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                foreach (var locB in locations)
                {
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if (distance < corA.GetDistanceTo(corB))
                    {
                        distance = corA.GetDistanceTo(corB);
                        TrackA = locA;
                        TrackB = locB;
                    }
                }
            }

            var distances = distance * 0.0006213712;

            Console.WriteLine($"The two furthest TacoBells from each other are {TrackA.Name} and {TrackB.Name}.\n" +
                             $"These two stores are {Math.Round(distances, 2)} miles apart from each other\n");


        }
    }
}




