namespace LoggingKata
{  
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

          
            var cells = line.Split(',');

            
            if (cells.Length < 3)
            {          
                logger.LogError($"Lines: {cells[0]}");
                return null;
            }
            var latitide = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            var Tacobell = new TacoBell();

            var coords = new Point()
            {
                Latitude = latitide,
                Longitude = longitude,
            };

            Tacobell.Name = name;
            Tacobell.Location = coords;

            return Tacobell;
        }
    }
}