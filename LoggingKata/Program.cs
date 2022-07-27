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
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
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

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.            
            ITrackable TrackA = null;
            ITrackable TrackB = null;
            // Create a `double` variable to store the distance
            double distance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
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




