namespace Silverstone.Weather.Domain.Model
{
    public class GeoLocation
    {
        public string Name { get; set; }
        public LocalNames LocalNames { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}