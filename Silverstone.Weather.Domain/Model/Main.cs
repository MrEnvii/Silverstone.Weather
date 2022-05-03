namespace Silverstone.Weather.Domain.Model
{ 

    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

}